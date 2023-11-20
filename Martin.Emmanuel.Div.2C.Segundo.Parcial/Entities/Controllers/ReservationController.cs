using Entities.Handlers;
using Entities.Models;
using Entities.SQLLogic;

namespace Entities.Controllers
{
    /// <summary>
    /// Clase que controla las reservaciones con la base de datos.
    /// </summary>
    public class ReservationController
    {
        private readonly IDataBaseGenericRepository<Reservation> _reservationRepository;

        public ReservationController()
        {
            this._reservationRepository = new ReservationRepository(new ContextDb());
        }

        public ReservationController(IDataBaseGenericRepository<Reservation> reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }
        /// <summary>
        /// Obtiene todas las reservaciones de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de todas las reservaciones</returns>
        public async Task<List<Reservation>> GetAllReservations()
        {
            return await this._reservationRepository.GetAll();
        }
        /// <summary>
        /// Obtiene una reservacion por dni de huesped
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve una reservacion</returns>
        public async Task<Reservation> GetReservationByDni(int dni)
        {
            return await this._reservationRepository.GetById(dni);
        }


        /// <summary>
        /// Agrega una reservacion a la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task Add(Reservation reservation)
        {
            await this._reservationRepository.Add(reservation);
        }

        /// <summary>
        /// Actualiza una reservacion en la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task UpdateReservation(Reservation reservation)
        {
            await this._reservationRepository.Update(reservation);
        }

        /// <summary>
        /// Borra una reservacion de la base de datos
        /// </summary>
        /// <param name="reservation"></param>
        public async Task Delete(Reservation reservation)
        {
            await this._reservationRepository.Delete(reservation.DniGuest);
        }
    }
}
