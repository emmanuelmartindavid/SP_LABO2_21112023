using Entities.Models;
using System.Text.Json;

namespace Entities.Serialization
{
    public class JSONSerialization : JSONManagment
    {
        public static void SerializeBillings(Billing billing)
        {
            try
            {
                string json = Serialize(billing);

                string path = "C:\\Users\\Cuerpos\\billings.json";
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {

                throw new NotSerializeJsonException("Error", ex.Message);
            }
        }

        public static void SerializeBillings(List<Billing> billing)
        {
            try
            {
                string json = Serialize(billing);

                string path = "C:\\Users\\Cuerpos\\billings.json";
                File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {

                throw new NotSerializeJsonException("Error", ex.Message);
            }



        }

        public static List<Billing> DeserializeBillings()
        {
            try
            {
                string json = File.ReadAllText("C:\\Users\\Cuerpos\\billings.json");
                return Deserialize<List<Billing>>(json);
            }
            catch (Exception ex)
            {

                throw new NotDeserializeJsonException("Error", ex.Message);
            }


        }


    }


}
