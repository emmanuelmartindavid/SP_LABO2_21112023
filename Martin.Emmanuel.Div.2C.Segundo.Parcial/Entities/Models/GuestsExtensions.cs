
namespace Entities.Models
{
    public static class GuestsExtensions
    {
        /// <summary>
        /// Ordena los huespedes por apellido
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public static List<Guest> OrderGuestByLastName(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            return guests;
        }
        /// <summary>
        /// Ordena los huespedes por DNI
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public static List<Guest> OrderGuestByDNI(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.Dni.ToString(), y.Dni.ToString()));
            return guests;
        }
        /// <summary>
        /// Ordena los huespedes por nombre
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public static List<Guest> OrderGuestByFirstName(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.Name, y.Name));
            return guests;
        }
        /// <summary>
        /// Ordena los huespedes por telefono
        /// </summary>
        /// <param name="guests"></param>
        /// <returns></returns>
        public static List<Guest> OrderGuestByPhoneNumber(this List<Guest> guests)
        {
            var sortedGuests = new List<Guest>(guests);
            guests.Sort((x, y) => string.Compare(x.PhoneNumber.ToString(), y.PhoneNumber.ToString()));
            return guests;
        }

    }
}
