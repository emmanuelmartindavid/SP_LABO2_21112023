using Entities.Models;
using System.Text.Json;

namespace Entities.Serialization
{
    public class JSONSerialization : JSONManagment
    {
        /// <summary>
        /// Metodo para serializar una cuenta JSOn
        /// </summary>
        /// <param name="billing"></param>
        /// <exception cref="NotSerializeJsonException"></exception>
        public static void SerializeBillings(Billing billing)
        {
            try
            {
                string json = Serialize(billing);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "billings.json");
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new NotSerializeJsonException("Error", ex.Message);
            }
        }
        /// <summary>
        /// Metodo para serializar una lista de cuentas
        /// </summary>
        /// <param name="billing"></param>
        /// <exception cref="NotSerializeJsonException"></exception>
        public static void SerializeBillings(List<Billing> billing)
        {
            try
            {
                string json = Serialize(billing);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "billings.json");
                File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {

                throw new NotSerializeJsonException("Error", ex.Message);
            }
        }
        /// <summary>
        /// Metodo para deserializar una lista de cuentas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotDeserializeJsonException"></exception>
        public static List<Billing> DeserializeBillings()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "billings.json");
                string json = File.ReadAllText(path);
                return Deserialize<List<Billing>>(json);
            }
            catch (Exception ex)
            {

                throw new NotDeserializeJsonException("Error", ex.Message);
            }
        }
    }
}
