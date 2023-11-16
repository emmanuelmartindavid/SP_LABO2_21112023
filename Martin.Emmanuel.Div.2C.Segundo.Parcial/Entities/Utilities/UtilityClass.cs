using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Utilities
{
    public static class UtilityClass
    {
        /*public static List<T> GetList<T>(List<object> objs)
        {
            return objs.Select(o => (T)o).ToList();
        }*/

       public static List<Reservation> DeletedReservations = new List<Reservation>();

        public static void AddDeleteReservationsToList(Reservation reservation)
        {
            DeletedReservations.Add(reservation);
        }


      
    }
}
