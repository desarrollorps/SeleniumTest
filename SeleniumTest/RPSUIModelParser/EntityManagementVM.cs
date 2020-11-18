using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPSUIModelParser
{
    public class EntityManagementVM
    {
        public string MainName { get; set; }
        public ComunicatorView View { get; set; }
        public ComunicatorViewModel VM { get; set; }
        public string EntityName { get; set; }
        public string Service { get; set; }
    }
    public class ComunicatorView
    {
        public ComunicatorView()
        {
            VMs = new List<ComunicatorViewModel>();
        }
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Content
        {
            get { return content; }
            set
            {
                content = value;

            }
        }
        private string content;

        public State State { get; set; }
        public FormTemplate FormTemplate { get; set; }
        public FiltersTemplate FiltersTemplate { get; set; }
        public ResultTemplate ResultTemplate { get; set; }
        [JsonIgnore]
        public List<PropertyEditor> PropertyEditors { get; set; }
        public void LoadCollectionViews()
        {
            //a partir del contenido buscamos objetos con el type = RPS.UI.Model.CollectionEditor, RPSUIModel y serializamos el obleto en un collection view por cada uno

        }
        public void LoadVMElements()
        {
            PropertyEditors = new List<PropertyEditor>();
            var root = JsonConvert.DeserializeObject<JToken>(content, new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,

                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,

            });
            var vmelements = this.GetVMElements(root);
            foreach (var vmelement in vmelements)
            {
                var control = JObject.Parse(vmelement.Parent.Parent.ToString());
                string type = control["$type"].Value<string>();
                string id = control["$id"].Value<string>();
                bool isreadonly = false;
                if (control.ContainsKey("IsReadOnly"))
                {
                    isreadonly = control["IsReadOnly"].Value<bool>(); ;
                }
                string idproperty = "";
                idproperty = vmelement["VMElement"]["$id"].Value<string>();



                PropertyEditor prop = new PropertyEditor() { id = id, IsReadOnly = isreadonly, type = type, vmid = idproperty };
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
        [JsonIgnore]
        public List<ComunicatorViewModel> VMs { get; set; }
    }
    public class CollectionView
    {
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
    }
    public class GridView : CollectionView
    {

    }
    public class PropertyEditor
    {
        public string type { get; set; }
        public string id { get; set; }
        public string vmid { get; set; }
        public bool IsReadOnly { get; set; }
        public Property vmProperty { get; set; }
    }
    public class CollectionEditor
    {
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public RelatedModel RelatedModel { get; set; }
        [JsonIgnore]
        public List<CollectionView> Views { get; set; }
        public void LoadViews(string content)
        {
            //empezamos por los gridviews del contenido del collection editor
            //buscamos y serializamos los "RPS.UI.Model.GridView, RPSUIModel"
        }
    }
    public class RelatedModel
    {
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string RelatedEntity { get; set; }
    }
    public class ComunicatorViewModel
    {
        public ComunicatorViewModel()
        {
            Children = new List<ComunicatorViewModel>();
        }
        public string ID { get; set; }
        [JsonProperty("$type")]
        public string type { get; set; }
        public string Name { get; set; }
        public string RelatedEntity { get; set; }
        public List<Property> Elements { get; set; }

        public State CurrentState { get; set; }

        public ComunicatorView View { get; set; }
        [JsonIgnore]
        public string Content
        {
            get { return content; }
            set
            {
                content = value;

            }
        }
        private string content;
        [JsonIgnore]
        public ComunicatorViewModel Parent { get; set; }

        [JsonIgnore]
        public List<ComunicatorViewModel> Children { get; set; }
    }

        public class Property
        {
            public string ID { get; set; }
            [JsonProperty("$type")]
            public string sType { get; set; }
            public string Name { get; set; }
            [JsonIgnore]
            public ComunicatorViewModel VM { get; set; }
        }
        public class State
        {

            public string ID { get; set; }
        }
        public class FiltersTemplate
        {
            public string ID { get; set; }
        }
    public class ResultTemplate
    {
        public string ID { get; set; }
    }
    public class FormTemplate
        {
            public string ID { get; set; }
        }
        public class TargetStateVM
        {
            public string ID { get; set; }
            public TargetStateViewModel ViewModel { get; set; }
        }
        public class TargetStateViewModel
        {
            public string ID { get; set; }
        }
    }


