
namespace Entities.Models
{
    public static class GuestsExtensions
    {
        public static List<Guest> OrderGuestByLastName(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            return guests;
        }

        public static List<Guest> OrderGuestByDNI(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.Dni.ToString(), y.Dni.ToString()));
            return guests;
        }

        public static List<Guest> OrderGuestByFirstName(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.Name, y.Name));
            return guests;
        }

        public static List<Guest> OrderGuestByPhoneNumber(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.PhoneNumber.ToString(), y.PhoneNumber.ToString()));
            return guests;
        }

    }
}
