using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RPSUIModelParser
{
    public class UIModel
    {
        public UIModel(string path)
        {
            this.FullPath = path;
            UIComponents = GetUIComponetns(path);
            List<string> splitted = path.Split('\\').ToList();
            int versionIndex = splitted.FindIndex(d => d.ToUpper().Contains("VERSION"));
            int sourceIndex = splitted.FindIndex(d => d.ToUpper().Contains("SOURCE"));
            if (versionIndex >= 0)
            {
                Version = splitted[versionIndex];
                
            }
            Customer = "";
            if (sourceIndex > 1)
            {
                var indexed = splitted.Skip(versionIndex+1).Take((sourceIndex -1) - versionIndex);
                Customer = String.Join(".", indexed);
            }
            string CustomerFolderPath = string.Join("\\", splitted.Take(sourceIndex));
            DirectoryInfo dir = new DirectoryInfo(CustomerFolderPath);
            var clientInfo = dir.GetFiles("ClientInfo.json", SearchOption.AllDirectories);
            if (clientInfo.Count() > 0)
            {
                var file = clientInfo[0];
                string json = File.ReadAllText(file.FullName);
                var data = (JObject)JsonConvert.DeserializeObject(json);
                this.Package = data["PackageName"].Value<string>();
            }

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
        internal List<ComunicatorView> GetUIComponetns(string path)
        {
            var model = File.ReadAllText(path);

            var root = JsonConvert.DeserializeObject<JToken>(model, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,

                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

            });

            // Replace {"ref": "...") objects with their references.
            JsonExtensions.ResolveRefererences(root);
            var states = GetTartetStates(root);
            var viewmodels = root["ViewModels"].ToList();
            var name = root["Name"].ToString();
            this.Service = root["Service"].ToString();
            this.ScreenName = name;
            List<ComunicatorViewModel> viewmodelList = new List<ComunicatorViewModel>();
            List<ComunicatorView> viewlist = new List<ComunicatorView>();
            viewmodels.ForEach(vm =>
            {
                string svm = vm.ToString();
                var obj = JsonConvert.DeserializeObject<ComunicatorViewModel>(svm, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None,

                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

                });
                obj.Content = svm;
                obj.Elements.ForEach(d => { d.VM = obj; });
                viewmodelList.Add(obj);
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
            var views = screenDef["Views"].ToList();
            views.ForEach(v =>
            {
                string sv = v.ToString();
                var obj = JsonConvert.DeserializeObject<ComunicatorView>(sv, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None,

                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

                });
                obj.Content = sv;
                viewlist.Add(obj);
            });
            
            //List<EntityManagementVM> managementlist = new List<EntityManagementVM>();
            viewlist.ForEach(v =>
            {
                v.LoadCollectionViews();
                v.LoadVMElements();
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
            });
            string[] ids = viewmodelList.Select(d => d.ID).ToArray();
            foreach(var v in viewmodelList)
            {
                var parent = GetFirstParent(root, v.ID, ids);
                if (parent != null)
                {
                    var parentvm = viewmodelList.Where(d => d.ID == parent).FirstOrDefault();
                    v.Parent = parentvm;
                    parentvm.Children.Add(v);
                }
            }
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
                var state = JsonConvert.DeserializeObject<TargetStateVM>(r.ToString());
                states.Add(state);
            }
            return states;
        }

    }
}
