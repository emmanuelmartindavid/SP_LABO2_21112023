using Entities.Handlers;
using Entities.Models;
using Entities.SQLLogic;

namespace Entities.Controllers
{
    public class GuestController
    {
        private readonly IDataBaseGenericRepository<Guest> _guestRepository;

        public GuestController()
        {
            this._guestRepository = new GuestRepository(new ContextDb());
        }

        public GuestController(IDataBaseGenericRepository<Guest> guestRepository)
        {
            this._guestRepository = guestRepository;
        }
        /// <summary>
        /// Obtiene Huespedes de la base de datos
        /// </summary>
        /// <returns>Devuelve una lista de todos los Huespedes</returns>
        public async Task<List<Guest>> GetAllGuests()
        {

            return await this._guestRepository.GetAll();
        }
        /// <summary>
        /// Obtiene un huesped por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve un huesped por su dni</returns>
        public async Task<Guest> GetGuestByDni(int dni)
        {
            return await this._guestRepository.GetById(dni);
        }

        /// <summary>
        /// Agrega un huesped a la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task AddGuest(Guest guest)
        {
            await this._guestRepository.Add(guest);
        }

        /// <summary>
        /// Actualiza un huesped en la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task UpdateGuest(Guest guest)
        {
            await this._guestRepository.Update(guest);
        }

        /// <summary>
        /// Borra un huesped de la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task DeleteGuest(Guest guest)
        {
            await this._guestRepository.Delete(guest.Dni);
        }
        /// <summary>
        /// Verifica si un huesped existe en la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve true si existe huesped, false caso contrario</returns>
        public async Task<bool> GuestExists(int dni)
        {
            Guest guest = await this._guestRepository.GetById(dni);

            return guest != null;
        }
    }
}
