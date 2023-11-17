using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.Serialization
{
    public class JSONManagment
    {
        public static string Serialize<T>(T obj)
        {
            JsonSerializerOptions opciones = new();
            opciones.WriteIndented = true;

            return System.Text.Json.JsonSerializer.Serialize(obj, opciones);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
