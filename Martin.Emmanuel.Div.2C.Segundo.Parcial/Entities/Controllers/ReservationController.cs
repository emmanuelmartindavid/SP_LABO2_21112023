using Entities.Handlers;
using Entities.Models;
using Entities.SQLLogic;

namespace Entities.Controllers
{
    public class ReservationController
    {
        private ReservationHandler _reservationHandler;

        private IManagementDataBase<Reservation> _managementDataBase;

        public ReservationController()
        {
            this._reservationHandler = new();
        }

        public ReservationController(IManagementDataBase<Reservation> managementDataBase)
        {
            this._managementDataBase = managementDataBase;
        }

         public async Task<List<Reservation>> GetAllReservationsconI()
        {
            return await this._managementDataBase.GetAll();
        }
        /// <summary>
        /// Devuelve una lista de todas las reservaciones
        /// </summary>
        /// <returns></returns>
        public async Task<List<Reservation>> GetAllReservations()
        {
            return await this._reservationHandler.GetAll();
        }
        /// <summary>
        /// Devuelve una reservacion por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<Reservation> GetReservationByDni(int dni)
        {
            return await this._reservationHandler.GetById(dni);
        }


        /// <summary>
        /// Agrega una reservacion a la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task Add(Reservation reservation)
        {
            await this._reservationHandler.Add(reservation);
        }

        /// <summary>
        /// Actualiza una reservacion en la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task UpdateReservation(Reservation reservation)
        {
            await this._reservationHandler.Update(reservation);
        }

        /// <summary>
        /// Borra una reservacion de la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task Delete(Reservation reservation)
        {
            await this._reservationHandler.Delete(reservation.DniGuest);
        }
    }
}
