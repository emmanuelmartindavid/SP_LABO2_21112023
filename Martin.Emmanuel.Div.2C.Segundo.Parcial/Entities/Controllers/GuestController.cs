using Entities.Handlers;
using Entities.Models;

namespace Entities.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GuestController
    {
        private readonly GuestHandler _guestHandler;

        public GuestController()
        {
            _guestHandler = new();
        }
        /// <summary>
        /// Devuelve una lista de todos los Huespedes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Guest>> GetAllGuests()
        {
         
            return await _guestHandler.GetAll();
        }

        /// <summary>
        /// Devuelve un huesped por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<Guest> GetGuestByDni(int dni)
        {
            return await _guestHandler.GetById(dni);
        }

        /// <summary>
        /// Agrera un huesped a la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task AddGuest(Guest guest)
        {
            await _guestHandler.Add(guest);
        }

        /// <summary>
        /// Actualiza un huesped en la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task UpdateGuest(Guest guest)
        {
            await _guestHandler.Update(guest);
        }

        /// <summary>
        /// Borra un huesped de la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task DeleteGuest(Guest guest)
        {
            await _guestHandler.Delete(guest.Dni);
        }
        /// <summary>
        /// Verifica si un huesped existe en la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task<bool> GuestExists(int dni)
        {
            Guest guest = await _guestHandler.GetById(dni);

            return guest != null;
        }
    }
}
