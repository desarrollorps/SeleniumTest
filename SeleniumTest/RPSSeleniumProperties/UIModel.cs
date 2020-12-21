using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RPSUIModelParser
{
    public class UIModel:IDisposable
    {
        public  UIModel(string path, string customer)
        {
            this.FullPath = path;
            UIComponents = GetUIComponetns(path).Result;
            List<string> splitted = path.Split('\\').ToList();
            //int versionIndex = splitted.FindIndex(d => d.ToUpper().Contains("VERSION"));
            //int sourceIndex = splitted.FindIndex(d => d.ToUpper().Contains("SOURCE"));
            /*if (versionIndex >= 0)
            {
                Version = splitted[versionIndex];
                
            }*/
            Version = GetType().Assembly.GetName().Version.ToString();
            Customer = customer;
            /*if (sourceIndex > 1)
            {
                var indexed = splitted.Skip(versionIndex+1).Take((sourceIndex -1) - versionIndex);
                Customer = String.Join(".", indexed);
            }*/
            //string CustomerFolderPath = string.Join("\\", splitted.Take(sourceIndex));
            /*DirectoryInfo dir = new DirectoryInfo(CustomerFolderPath);
            var clientInfo = dir.GetFiles("ClientInfo.json", SearchOption.AllDirectories);
            if (clientInfo.Count() > 0)
            {
                var file = clientInfo[0];
                string json = File.ReadAllText(file.FullName);
                var data = (JObject)JsonConvert.DeserializeObject(json);
                this.Package = data["PackageName"].Value<string>();
            }*/
            this.Package = "RPS";
            

        }
        public string Version { get; set; }
        public string Customer { get; set; }
        public string Package { get; set; }
        public string FullPath { get; set; }
        public string Service { get; set; }
        public string ScreenName { get; set; }
        public string Name { get { return System.IO.Path.GetFileNameWithoutExtension(FullPath); } }
        public string FullName { get { return $"{Service.ToLower()}.{ScreenName.ToLower()}"; } }
        public List<ComunicatorView> UIComponents { get; set; }
        internal async Task<List<ComunicatorView>> GetUIComponetns(string path)
        {
            var model = await File.ReadAllTextAsync(path);

            var root = JsonConvert.DeserializeObject<JToken>(model, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

            });

            // Replace {"ref": "...") objects with their references.
            Console.WriteLine("Reconstructing references");
            JsonExtensions jex = new JsonExtensions();
            //jex.ResolveRefererences(root["ViewModels"],root);
            //jex.ResolveRefererences(root["MainState"], root);
            Console.WriteLine("References reconstructed");
            var states = GetTartetStates(root);
            var querystates = states.ToList();
            for(int i = 0; i<querystates.Count; i++)
            {
                var st = querystates[i];
                if (!string.IsNullOrEmpty(st.reference))
                {
                    var token = jex.ResolveRefererences(st.reference, root);
                    states[i] = token.ToObject<TargetStateVM>(
                        new JsonSerializer
                        {
                            DateParseHandling = DateParseHandling.None,

                            MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                        }
                        );
                }
            }
            var viewmodels = root["ViewModels"].ToList().Select(d=>d.ToObject<ComunicatorViewModel>(new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,

                MetadataPropertyHandling = MetadataPropertyHandling.Ignore
            }
            )).ToList();
            var query = viewmodels.ToList();
            for(int i = 0; i<query.Count;i++)
            {
                var vm = query[i];
                if (!string.IsNullOrEmpty(vm.reference))
                {
                    var token = jex.ResolveRefererences(vm.reference, root);
                    viewmodels[i] = token.ToObject<ComunicatorViewModel>(
                        new JsonSerializer
                        {
                            DateParseHandling = DateParseHandling.None,

                            MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                        }
                        );
                    var queryElements = viewmodels[i].Elements.ToList();
                    for(int j = 0; j<queryElements.Count;j++)
                    {
                        var el = queryElements[j];
                        if(!string.IsNullOrEmpty(el.reference))
                        {
                            var tokel = jex.ResolveRefererences(el.reference, root);
                            viewmodels[i].Elements[j] = tokel.ToObject<Property>(
                                new JsonSerializer
                                {
                                    DateParseHandling = DateParseHandling.None,

                                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                                }
                                );
                        }
                    }
                }
            }
            var name = root["Name"].ToString();
            this.Service = root["Service"].ToString();
            this.ScreenName = name;
            List<ComunicatorViewModel> viewmodelList = new List<ComunicatorViewModel>();
            List<ComunicatorView> viewlist = new List<ComunicatorView>();
            viewmodels.ForEach(vm =>
            {
                /*string svm = vm.ToString();
                var obj = JsonConvert.DeserializeObject<ComunicatorViewModel>(svm, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None,

                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

                });*/
                /*var obj = vm.ToObject<ComunicatorViewModel>(new JsonSerializer
                {
                    DateParseHandling = DateParseHandling.None,
                    PreserveReferencesHandling = PreserveReferencesHandling.All,
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                }
                    );
                */

                vm.Elements.ForEach(d => { d.VM = vm; });
                viewmodelList.Add(vm);
            });
            states.Where(s => s.ViewModel != null).ToList().ForEach(s =>
            {
                var vm = viewmodelList.Where(d => d.ID == s.ViewModel.ID).FirstOrDefault();
                if (vm != null)
                {
                    vm.CurrentState = new State() { ID = s.ID };
                }
            });
            var screenDef = root["ScreenDefinition"];
            string[] ids = viewmodelList.Select(d => d.ID).ToArray();
            foreach (var v in viewmodelList)
            {
                var parent = GetFirstParent(root, v.ID, ids);
                if (parent != null)
                {
                    var parentvm = viewmodelList.Where(d => d.ID == parent).FirstOrDefault();
                    v.Parent = parentvm;
                    parentvm.Children.Add(v);
                }
            }
            //Clear the view modles from json
            //root["ViewModels"].Replace(JToken.Parse("[]"));

            var views = screenDef["Views"].ToList();
            views.ForEach(v =>
            {
                
                               
                var obj = v.ToObject<ComunicatorView>(new JsonSerializer
                {
                    DateParseHandling = DateParseHandling.None,

                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                }
                );
                obj.LoadCollectionViews(v);
                obj.LoadViewEditors(v);
                obj.LoadVMElements(v);
                viewlist.Add(obj);
            });
            
            //List<EntityManagementVM> managementlist = new List<EntityManagementVM>();
            viewlist.ForEach(v =>
            {
                
                var vm = viewmodelList.Where(d => d.CurrentState != null && d.CurrentState.ID == v.State.ID /*&& !string.IsNullOrEmpty(d.RelatedEntity)*/).FirstOrDefault();
                if (vm != null)
                {
                    vm.View = v;
                    v.VMs.Add(vm);
                    
                    /*EntityManagementVM management = new EntityManagementVM();
                    management.MainName = name;
                    management.View = v;
                    management.VM = vm;
                    management.Service = vm.RelatedEntity.Split('/')[0];
                    management.EntityName = vm.RelatedEntity.Split('/')[1];
                    managementlist.Add(management);*/
                }
                
                v.PropertyEditors.ForEach(prop =>
                {
                    foreach(var m in viewmodelList)
                    {
                        var p = m.Elements.Where(d => d.ID == prop.vmid).FirstOrDefault();
                        if (p != null)
                        {
                            prop.vmProperty = p;
                            break;
                        }
                    }
                });
                v.Collections.ForEach(col =>
                {
                    col.GridViews.ForEach(gv =>
                    {
                        gv.PropertyEditors.ForEach(prop =>
                        {
                            foreach (var m in viewmodelList)
                            {
                                var p = m.Elements.Where(d => d.ID == prop.vmid).FirstOrDefault();
                                if (p != null)
                                {
                                    prop.vmProperty = p;
                                    break;
                                }
                            }
                        });
                    });
                });
               
            });
            
            foreach(var view in viewlist)
            {
                foreach(var mo in view.VMs)
                {
                    if (mo.MainModel != null)
                    {
                        var vmodel = viewmodelList.Where(vm => vm.ID == mo.MainModel.ID).FirstOrDefault();
                        if (vmodel != null)
                        {
                            mo.MainModel = vmodel;
                        }
                    }
                }
            }
            return viewlist;
        }
        public string GetFirstParent(JToken root,string id, string[] parentids)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var token = container.Descendants().OfType<JObject>().Where(o => o.ContainsKey("$id") && o["$id"].ToString() == id).FirstOrDefault();
            var parent = token.Parent;
            while (parent != null)
            {
                if (parent as JObject == null)
                {
                    parent = parent.Parent;
                }
                else 
                {
                    JObject current = parent as JObject;
                    if (current.ContainsKey("$id"))
                    {
                        string parentid = current["$id"].Value<string>();
                        var myid = parentids.Where(d => d == parentid).FirstOrDefault();
                        if (myid != null)
                        {
                            return myid;
                        }
                        else
                        {
                            parent = parent.Parent;
                        }
                    }
                    else
                    {
                        parent = parent.Parent;
                    }
                }
            }
            return null;
            
        }
        public List<TargetStateVM> GetTartetStates(JToken root)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(o => o.ContainsKey("$type") && o["$type"].ToString() == "RPS.UI.Model.StateDefinition, RPSUIModel").ToList();
            foreach (var r in refs)
            {
                var state = r.ToObject<TargetStateVM>(
                    new JsonSerializer
                    {
                        DateParseHandling = DateParseHandling.None,

                        MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                    }
                    )
                    
                    ;// JsonConvert.DeserializeObject<TargetStateVM>(r.ToString());
                states.Add(state);
            }
            return states;
        }

        public void Dispose()
        {
            if (this.UIComponents != null)
            {
                this.UIComponents.Clear();
            }
            this.UIComponents = null;
            
        }
    }
}
