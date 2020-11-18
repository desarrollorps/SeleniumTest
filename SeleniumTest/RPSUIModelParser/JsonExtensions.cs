using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace RPSUIModelParser
{
    public static partial class JsonExtensions
    {
        const string refPropertyName = "$ref";

        public static void ResolveRefererences(JToken root)
        {
            if (!(root is JContainer container))
                return;
            var refs = container.Descendants().OfType<JObject>().Where(o => IsRefObject(o)).ToList();
            var norefs = container.Descendants().OfType<JObject>().Where(o => !IsRefObject(o)).ToList();
            Console.WriteLine(JsonConvert.SerializeObject(refs));
            foreach (var refObj in refs)
            {
                var path = GetRefObjectValue(refObj);
                var original = ResolveRef(path, norefs);
                if (original != null)
                    refObj.Replace(original);
            }
        }

        static bool IsRefObject(JObject obj)
        {
            return GetRefObjectValue(obj) != null;
        }
        static string GetRefObjectID(JObject obj)
        {

            var refValue = obj["$id"];
            if (refValue != null && refValue.Type == JTokenType.String)
            {
                return (string)refValue;
            }

            return null;
        }

        static string GetRefObjectValue(JObject obj)
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

        static JToken ResolveRef(string path, List<JObject> norefs)
        {

            var refs = norefs.Where(o => path == GetRefObjectID(o)).FirstOrDefault();
            // TODO: determine whether it is possible for a property name to contain a '.' character, and if so, how the path will look.

            return refs;
            //return refs.FirstOrDefault();
        }
    }
}
