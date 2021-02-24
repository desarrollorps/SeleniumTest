using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPSUIModelParser
{
    [JsonObject(IsReference = true)]
    public class EntityManagementVM
    {
        public string MainName { get; set; }
        public ComunicatorView View { get; set; }
        public ComunicatorViewModel VM { get; set; }
        public string EntityName { get; set; }
        public string Service { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class ComunicatorView
    {
        public ComunicatorView()
        {
            VMs = new List<ComunicatorViewModel>();
            Collections = new List<CollectionEditor>();
        }
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }        

        public State State { get; set; }
        public FormTemplate FormTemplate { get; set; }
        public FiltersTemplate FiltersTemplate { get; set; }
        public ResultTemplate ResultTemplate { get; set; }
        [JsonIgnore]
        public List<PropertyEditor> PropertyEditors { get; set; }
        [JsonIgnore]
        public List<CollectionEditor> Collections { get; set; }
        [JsonIgnore]
        public List<Sections> Sections { get; set; }
        [JsonIgnore]
        public List<ViewEditor> ViewEditor { get; set; }
        public void LoadCollectionViews(JToken root)
        {
            //a partir del contenido buscamos objetos con el type = RPS.UI.Model.CollectionEditor, RPSUIModel y serializamos el obleto en un collection view por cada uno
            
            var container = root as JContainer;
            var collections = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("$type")
                && o["$type"].Value<string>() == "RPS.UI.Model.CollectionEditor, RPSUIModel"
                ).Distinct().ToList();
            foreach(var c in collections)
            {
                var editor = c.ToObject<CollectionEditor>();
                editor.LoadViews(c);
                Collections.Add(editor);
            }
        }
        public void LoadViewEditors(JToken root)
        {
            this.ViewEditor = new List<ViewEditor>();
            
            var vmelements = this.GetViewEditors(root);
            foreach (var editor in vmelements)
            {
                var ed = editor.ToObject<ViewEditor>();
                this.ViewEditor.Add(ed);
            }
        }
        public void LoadVMElements(JToken root)
        {
            string[] avoidLoad = new string[]
            {
                "RPS.UI.Model.ViewEditor, RPSUIModel",
                "RPS.UI.Model.DescriptorView, RPSUIModel",
                "RPS.UI.Model.CollectionEditor, RPSUIModel"
            };
            PropertyEditors = new List<PropertyEditor>();
            Sections = new List<Sections>();
            
            var vmelements = this.GetVMElements(root);
            foreach (var vmelement in vmelements)
            {
               
                var control = JObject.Parse(vmelement.Parent.Parent.ToString());
                string type = control["$type"].Value<string>();
                string id = control["$id"].Value<string>();
                string name = control["Name"].Value<string>();
                bool isreadonly = false;
                if (!avoidLoad.Any(d => d == type))
                {
                    if (control.ContainsKey("IsReadOnly"))
                    {
                        isreadonly = control["IsReadOnly"].Value<bool>(); ;
                    }
                    string idproperty = "";
                    var vmelementjtoken = vmelement["VMElement"];
                    if (vmelementjtoken != null)
                    {
                        var jtoken = vmelementjtoken["$ref"];
                        if (jtoken != null)
                        {
                            idproperty = jtoken.Value<string>();
                            if (!this.Collections.Any(d => d.GridViews.Any(g => g.PropertyEditors.Any(p => p.id == id))))
                            {

                                PropertyEditor prop = new PropertyEditor() { id = id, Name = name, IsReadOnly = isreadonly, type = type, vmid = idproperty };
                                PropertyEditors.Add(prop);
                            }
                        }
                    }
                }
            }
            var sections = this.GetSections(root);
            foreach(var sec in sections)
            {
                var s = sec.ToObject<Sections>();
                this.Sections.Add(s);
            }
        }
        
        public List<JObject> GetVMElements(JToken root)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("VMElement")
                && (o.Parent as JProperty) != null ? (o.Parent as JProperty).Name == "Binding" : false
                ).Distinct().ToList();

            return refs;
        }
        public List<JObject> GetViewEditors(JToken root)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("$type")
                &&   o["$type"].Value<string>() == "RPS.UI.Model.ViewEditor, RPSUIModel"
                ).Distinct().ToList();

            return refs;
        }
        public List<JObject> GetSections(JToken root)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("$type")
                && o["$type"].Value<string>() == "RPS.UI.Model.Section, RPSUIModel"
                ).Distinct().ToList();

            return refs;
        }


        [JsonIgnore]
        public List<ComunicatorViewModel> VMs { get; set; }
    }

    [JsonObject(IsReference = true)]
    public class GridView
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        [JsonIgnore]
        public List<PropertyEditor> PropertyEditors { get; set; }
        public void LoadVMElements(JToken root)
        {
            PropertyEditors = new List<PropertyEditor>();
           /* var root = JsonConvert.DeserializeObject<JToken>(content, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,

                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

            });*/
            var vmelements = this.GetVMElements(root);
            foreach (var vmelement in vmelements)
            {
                var control = JObject.Parse(vmelement.Parent.Parent.ToString());
                string type = control["$type"].Value<string>();
                string id = control["$id"].Value<string>();
                string name = control["Name"].Value<string>();
                bool isreadonly = false;
                if (control.ContainsKey("IsReadOnly"))
                {
                    isreadonly = control["IsReadOnly"].Value<bool>(); ;
                }
                string idproperty = "";
                idproperty = vmelement["VMElement"]["$ref"].Value<string>();



                PropertyEditor prop = new PropertyEditor() { id = id, Name = name, IsReadOnly = isreadonly, type = type, vmid = idproperty };
                PropertyEditors.Add(prop);
            }
        }

        public List<JObject> GetVMElements(JToken root)
        {
            List<TargetStateVM> states = new List<TargetStateVM>();
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("VMElement")
                && (o.Parent as JProperty) != null ? (o.Parent as JProperty).Name == "Binding" : false
                ).Distinct().ToList();

            return refs;
        }
    }
    [JsonObject(IsReference = true)]
    public class DescriptorView
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class PropertyEditor
    {
        public string type { get; set; }
        public string Name { get; set; }
        public string id { get; set; }
        public string vmid { get; set; }
        public bool IsReadOnly { get; set; }
        public Property vmProperty { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class ViewEditor
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class Sections
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class CollectionEditor
    {
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public RelatedModel RelatedModel { get; set; }
        [JsonIgnore]
        public List<GridView> GridViews { get; set; }
        [JsonIgnore]
        public List<DescriptorView> DescriptorViews { get; set; }
        public List<JObject> GetDescriptorViews(JToken root)
        {
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("$type")
                && o["$type"].Value<string>() == "RPS.UI.Model.DescriptorView, RPSUIModel"
                ).Distinct().ToList();
            return refs;
        }
        public List<JObject> GetGridViews(JToken root)
        {
            if (!(root is JContainer container))
                return null;
            var refs = container.Descendants().OfType<JObject>().Where(
                o => o.ContainsKey("$type")
                && o["$type"].Value<string>() == "RPS.UI.Model.GridView, RPSUIModel"
                ).Distinct().ToList();
            return refs;
        }
        public void LoadViews(JToken root)
        {
            DescriptorViews = new List<DescriptorView>();
            GridViews = new List<GridView>();
            /*var root = JsonConvert.DeserializeObject<JToken>(content, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,

                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

            });*/
            //empezamos por los gridviews del contenido del collection editor
            var descriptors = GetDescriptorViews(root);
            foreach(var d in descriptors)
            {
                var desc =d.ToObject<DescriptorView>();
                DescriptorViews.Add(desc);
            }
            var grids = GetGridViews(root);
            foreach(var g in grids)
            {

                var grid = g.ToObject<GridView>();
                grid.LoadVMElements(g);
                GridViews.Add(grid);

            }
            //buscamos y serializamos los "RPS.UI.Model.GridView, RPSUIModel"
        }
    }
    [JsonObject(IsReference = true)]
    public class RelatedModel
    {
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string RelatedEntity { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class ComunicatorViewModel
    {
        public ComunicatorViewModel()
        {
            Children = new List<ComunicatorViewModel>();
        }
        [JsonProperty("$ref")]
        public string reference { get; set; }
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public string RelatedEntity { get; set; }
        public List<Property> Elements { get; set; }
        public ComunicatorViewModel MainModel { get; set; }
        public State CurrentState { get; set; }

        public ComunicatorView View { get; set; }
        /*[JsonIgnore]
        public string Content
        {
            get { return content; }
            set
            {
                content = value;

            }
        }
        private string content;*/
        [JsonIgnore]
        public ComunicatorViewModel Parent { get; set; }

        [JsonIgnore]
        public List<ComunicatorViewModel> Children { get; set; }
    }
        [JsonObject(IsReference =true)]
        public class Property
        {
            [JsonProperty("$ref")]
            public string reference { get; set; }
            public string ID { get; set; }
            [JsonProperty("$type")]
            public string sType { get; set; }
            public string Name { get; set; }
            public Link ChildLink { get; set; }
            public State TargetState { get; set; }
            public bool IsMultiLine { get; set; }
        public bool IsRequired { get; set; }
            [JsonIgnore]
            public ComunicatorViewModel VM { get; set; }
            [JsonIgnore]
            public ComunicatorViewModel VMToNavigate { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class Link
    {
        [JsonProperty("$ref")]
        private string reference { set { ID = value; } }
        public string ID { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class State
        {

        [JsonProperty("$ref")]
        private string reference{ set { ID = value; } }
        public string ID { get; set; }
        }
 
  
    [JsonObject(IsReference = true)]
    public class FiltersTemplate
        {
            public string ID { get; set; }
        }
    [JsonObject(IsReference = true)]
    public class ResultTemplate
    {
        public string ID { get; set; }
    }
    [JsonObject(IsReference = true)]
    public class FormTemplate
        {
            public string ID { get; set; }
        }
    [JsonObject(IsReference = true)]
    public class TargetStateVM
        {
        private string _ref;
        [JsonProperty("$ref")]
        public string reference { set {
                ID = value;
                _ref = value;
            }
            get
            {
                return _ref;
            }
        }
        public string ID { get; set; }
            public TargetStateViewModel ViewModel { get; set; }
        }
    [JsonObject(IsReference = true)]
    public class TargetStateViewModel
        {
            [JsonProperty("$ref")]
            public string reference { set { ID = value; } }
            public string ID { get; set; }
        }
    }


