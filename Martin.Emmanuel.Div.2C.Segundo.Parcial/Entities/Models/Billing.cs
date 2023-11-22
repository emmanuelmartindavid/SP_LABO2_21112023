namespace Entities.Models
{
    public class Billing
    {

        private Guest _guest;
        private Room _room;
        private Reservation _reservation;

        /// <summary>
        /// Propiedad de Huesped
        /// </summary>
        public Guest Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        /// <summary>
        /// Propiedad de Habitacion
        /// </summary>
        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        /// <summary>
        /// Propiedad de Reserva
        /// </summary>
        public Reservation Reservation
        {
            get { return _reservation; }
            set { _reservation = value; }
        }

        /// <summary>
        /// Propiedad de Costo Total
        /// </summary>
        public decimal TotalCost
        {
            get { return CalculateTotalCost(); }
        }

        /// <summary>
        /// Propiedad Muestra datos de la Cuenta
        /// </summary>
        public string DisplayProperty
        {
            get
            {
                return $"{_guest.Name}, {_guest.LastName} - Habitacion: {_room.Number} - CheckIn: {_reservation.ChekIn.ToShortDateString()} - CheckOut: {_reservation.CheckOut.ToShortDateString()} - Costo: U$D {TotalCost}";
            }
        }

        /// <summary>
        /// Constructor de la clase Billing
        /// </summary>
        public Billing()
        {

        }

        /// <summary>
        /// Constructor de la clase Billing
        /// </summary>
        /// <param name="guest"></param>
        /// <param name="room"></param>
        /// <param name="reservation"></param>
        public Billing(Guest guest, Room room, Reservation reservation)
        {
            _guest = guest;
            _room = room;
            _reservation = reservation;

        }

        /// <summary>
        /// Calcula el costo total de la reserva
        /// </summary>
        /// <returns></returns>
        private decimal CalculateTotalCost()
        {

            int numberOfNights = (int)(_reservation.CheckOut - _reservation.ChekIn).TotalDays;
            decimal nightlyRate = GetNightlyRate(_room);

            return numberOfNights * nightlyRate;
        }

        /// <summary>
        /// Genera el costo por noche de la habitacion
        /// </summary>
        /// <param name="room"></param>
        /// <returns>Obtiene el costo por noche de la habitacion</returns>
        private decimal GetNightlyRate(Room room)
        {
            if (room.Type == ERoomType.Simple)
            {
                return 50;
            }
            return 90;
        }
    }
}
