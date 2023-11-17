using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Billing
    {

        private Guest _guest;
        private Room _room;
        private Reservation _reservation;
        private decimal _totalCost;
        //properties

        public Guest Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        public Reservation Reservation
        {
            get { return _reservation; }
            set { _reservation = value; }
        }

        public decimal TotalCost
        {
            get { return CalculateTotalCost(); }
            set { _totalCost = value; }
        }

        public string DisplayProperty
        {
            get
            {
                return $"{_guest.Name}, {_guest.LastName} - Habitacion: {_room.Number} - CheckIn: {_reservation.ChekIn.ToShortDateString()} - CheckOut: {_reservation.CheckOut.ToShortDateString()} - Costo: U$D{TotalCost}";
            }
        }



        public Billing()
        {

        }
        public Billing(Guest guest, Room room, Reservation reservation)
        {
            _guest = guest;
            _room = room;
            _reservation = reservation;

        }
        private decimal CalculateTotalCost()
        {

            int numberOfNights = (int)(_reservation.CheckOut - _reservation.ChekIn).TotalDays;
            decimal nightlyRate = GetNightlyRate(_room);

            return numberOfNights * nightlyRate;
        }

        private decimal GetNightlyRate(Room room)
        {
            if (room.Type == ERoomType.Simple)
            {
                return 50;
            }
            return 90;
        }

        /* public override string ToString()
         {
             decimal totalCost = CalculateTotalCost();
             *//*StringBuilder sb = new();

             sb.AppendLine($"Factura para {this._guest.Name}, {this._guest.LastName}:");
             sb.AppendLine($"Habitación: {this._room.Number}");
             sb.AppendLine($"Fecha de ingreso: {this._reservation.ChekIn.ToShortDateString()}");
             sb.AppendLine($"Fecha de salida: {this._reservation.CheckOut.ToShortDateString()}");
             sb.AppendLine($"Total a pagar: ${totalCost}");*//*

             var invoiceData = new
             {
                 Huesped = $"{_guest.Name}, {_guest.LastName}",
                 Habitacion = _room.Number,
                 CheckIn = _reservation.ChekIn.ToShortDateString(),
                 CheckOut = _reservation.CheckOut.ToShortDateString(),
                 CostoTotal = totalCost
             };

             return invoiceData.ToString();
         }*/
    }
}
