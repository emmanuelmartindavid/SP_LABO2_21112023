using System.Data;

namespace Entities.Models
{
    public class Reservation
    {
        private int _dniGuest;
        private DateTime _chekIn;
        private DateTime _checkOut;
        private int _roomNumber;

        /// <summary>
        /// Propiedad DniGuest.
        /// </summary>
        public int DniGuest { get => _dniGuest; set => _dniGuest = value; }
        /// <summary>
        /// Propiedad ChekIn.
        /// </summary>
        public DateTime ChekIn { get => _chekIn; set => _chekIn = value; }
        /// <summary>
        /// Propiedad CheckOut.
        /// </summary>
        public DateTime CheckOut { get => _checkOut; set => _checkOut = value; }
        /// <summary>
        /// Propiedad RoomNumber.
        /// </summary>
        public int RoomNumber { get => _roomNumber; set => _roomNumber = value; }

        /// <summary>
        /// Constructor de la clase Reservation.
        /// </summary>
        /// <param name="dniGuest"></param>
        /// <param name="chekIn"></param>
        /// <param name="checkOut"></param>
        /// <param name="roomNumber"></param>
        public Reservation(int dniGuest, DateTime chekIn, DateTime checkOut, int roomNumber)
        {
            this._dniGuest = dniGuest;
            this._chekIn = chekIn;
            this._checkOut = checkOut;
            this._roomNumber = roomNumber;
        }

        /// <summary>
        /// Constructor vacio de la clase Reservation.
        /// </summary>
        public Reservation()
        {
        }

        /// <summary>
        /// Convierte un DataRow en un objeto Reservation.
        /// </summary>
        /// <param name="line"></param>
        public static explicit operator Reservation(DataRow row)
        {
            var dniGuest = Convert.ToInt32(row["DniHuesped"].ToString());
            var chekIn = Convert.ToDateTime(row["CheckIn"].ToString());
            var checkOut = Convert.ToDateTime(row["CheckOut"].ToString());
            var roomNumber = Convert.ToInt32(row["NumeroHabitacion"].ToString());

            Reservation reservation = new(dniGuest, chekIn, checkOut, roomNumber);

            return reservation;
        }

        /// <summary>
        /// Sobreescritura del metodo ToString().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{DniGuest} - {ChekIn} - {CheckOut} - {RoomNumber}";
        }

    }
}
