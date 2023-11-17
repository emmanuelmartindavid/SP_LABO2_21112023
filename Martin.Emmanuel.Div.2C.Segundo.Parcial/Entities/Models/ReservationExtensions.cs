using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public static class ReservationExtensions
    {
        public static decimal CalculateTotalCost(this Reservation reservation, Room room)
        {
            int numberOfNights = (int)(reservation.CheckOut - reservation.ChekIn).TotalDays;
            decimal nightlyRate = GetNightlyRate(room);

            return numberOfNights * nightlyRate;
        }

        private static decimal GetNightlyRate(Room room)
        {
            if (room.Type == ERoomType.Simple)
            {
                return 50;
            }
            return 90;
        }


        public static string ToInvoiceString(this Reservation reservation, Guest guest, Room room)
        {
            decimal totalCost = reservation.CalculateTotalCost(room);
            /*    StringBuilder sb = new();

                sb.AppendLine($"Factura para {guest.Name}, {guest.LastName}:");
                sb.AppendLine($"Habitación: {room.Number}");
                sb.AppendLine($"Fecha de ingreso: {reservation.ChekIn.ToShortDateString()}");
                sb.AppendLine($"Fecha de salida: {reservation.CheckOut.ToShortDateString()}");
                sb.AppendLine($"Total a pagar: ${totalCost}");*/

            /*     return $"Factura para {guest.Name}, {guest.LastName} - Habitación: {room.Number} - Fecha de ingreso: {reservation.ChekIn.ToShortDateString()} - " +
                     $"Fecha de salida: {reservation.CheckOut.ToShortDateString()} - Total a pagar: ${totalCost}\n";*/

            var invoiceData = new
            {
                Huesped = $"{guest.Name}, {guest.LastName}",
                Habitacion = room.Number,
                CheckIn = reservation.ChekIn.ToShortDateString(),
                CheckOut = reservation.CheckOut.ToShortDateString(),
                CostoTotal = totalCost
            };

            return invoiceData.ToString();
        }
    }
}
