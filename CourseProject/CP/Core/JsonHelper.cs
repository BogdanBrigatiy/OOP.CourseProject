using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Core
{
    public class JsonHelper
    {
        public static string Serialize<T>(T obj2conv)
        {
                return JsonConvert.SerializeObject(obj2conv, Formatting.Indented);
        }
        public static T Deserealize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
