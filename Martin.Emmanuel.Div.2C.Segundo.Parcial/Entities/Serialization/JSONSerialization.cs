using Entities.Utilities;

namespace Entities.Serialization
{
    public class JSONSerialization : JSONManagment
    {
        public static void SerializeBillings(string billings)
        {
            string json = Serialize(billings);

            string path = "C:\\Users\\Cuerpos\\billings.json";
            File.WriteAllText(path, json);

        }

        public static List<Billing> DeserializeBillings()
        {
            string json = File.ReadAllText(@"C:\Users\Usuario\source\repos\Hotel-Management-App\Hotel-Management-App\billings.json");
            return Deserialize<List<Billing>>(json);
        }


    }


}
