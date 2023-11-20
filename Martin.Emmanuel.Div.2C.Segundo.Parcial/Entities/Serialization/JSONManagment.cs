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
        /// <summary>
        ///  Metodo para serializar un objeto a JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Devuelve el objeto serializado a JSON representado en STRING</returns>
        public static string Serialize<T>(T obj)
        {
            JsonSerializerOptions opciones = new();
            opciones.WriteIndented = true;
            return System.Text.Json.JsonSerializer.Serialize(obj, opciones);
        }
        /// <summary>
        /// Metodo para deserializar un objeto JSON a un objeto de tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns>Devuelve el objeto deserializado de JSON en su reprentacion elegida</returns>
        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
