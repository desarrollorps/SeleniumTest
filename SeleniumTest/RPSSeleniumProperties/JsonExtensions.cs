using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace RPSUIModelParser
{
    public  partial class JsonExtensions
    {
        const string refPropertyName = "$ref";
        public  ConcurrentDictionary<string, JToken> NoRefs = new ConcurrentDictionary<string, JToken>();
        public  void ResolveRefererences(JToken rootToken, JToken searchReferences)
        {
            NoRefs = new ConcurrentDictionary<string, JToken>();
            if (!(rootToken is JContainer container))
                return;
            if (!(searchReferences is JContainer references))
                return;
            var refs = container.Descendants().OfType<JObject>().Where(o => IsRefObject(o)).ToList();
            var norefs = references.Descendants().OfType<JObject>().Where(o => !IsRefObject(o) && o["$id"] != null).OrderBy(o=>o["$id"]).ToList();
            Parallel.ForEach(norefs, new Action<JObject>((nr) => {
                var id = GetRefObjectID(nr);
                if (!string.IsNullOrEmpty(id))
                {
                    if (!NoRefs.ContainsKey(id))
                    {
                        NoRefs.TryAdd(id, nr);
                    }
                    else
                    {

                    }
                }
            }));            
            norefs.Clear();
            ConcurrentDictionary<JObject, JToken> objectsToUpdate = new ConcurrentDictionary<JObject, JToken>();
            // Console.WriteLine(JsonConvert.SerializeObject(refs));
            Parallel.ForEach(refs, new Action<JObject>((refObj) =>
            {
                var path = GetRefObjectValue(refObj);
                var original = NoRefs.GetValueOrDefault(path, null); //ResolveRef(path, norefs);
                if (original != null)
                    objectsToUpdate.TryAdd(refObj, original);
                    
            }));
            Console.WriteLine("Updating references");
            foreach(var refObj in refs)
            {
                if (objectsToUpdate.ContainsKey(refObj))
                {
                    refObj.Replace(objectsToUpdate[refObj]);
                }
            }
            NoRefs.Clear();
        }
        public JToken ResolveRefererences(string id, JToken searchReferences)
        {
            NoRefs = new ConcurrentDictionary<string, JToken>();
           
            if (!(searchReferences is JContainer references))
                return null;           
            var norefs = references.Descendants().OfType<JObject>().Where(o => !IsRefObject(o) && o["$id"] != null && o["$id"].Value<string>()==id).FirstOrDefault();
            return norefs;
        }

        bool IsRefObject(JObject obj)
        {
            return GetRefObjectValue(obj) != null;
        }
        string GetRefObjectID(JObject obj)
        {

            var refValue = obj["$id"];
            if (refValue != null && refValue.Type == JTokenType.String)
            {
                return (string)refValue;
            }

            return null;
        }

        string GetRefObjectValue(JObject obj)
        {
            if (obj.Count == 1)
            {
                var refValue = obj[refPropertyName];
                if (refValue != null && refValue.Type == JTokenType.String)
                {
                    return (string)refValue;
                }
            }
            return null;
        }

        JToken ResolveRef(string path, List<JObject> norefs)
        {

            var refs = norefs.Where(o => path == GetRefObjectID(o)).FirstOrDefault();
            // TODO: determine whether it is possible for a property name to contain a '.' character, and if so, how the path will look.

            return refs;
            //return refs.FirstOrDefault();
        }
    }
}
