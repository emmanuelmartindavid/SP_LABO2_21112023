using Entities.Handlers;
using Entities.Models;

namespace Entities.Controllers
{
    public class RoomController
    {
        private RoomHandler _roomHandler;

        public RoomController()
        {
            this._roomHandler = new();
        }

        ///<summary>
        /// Crea lista de todas las habitaciones
        ///</summary>
        /// <returns>Devuelve lista de habitaciones</returns>
        public async Task<List<Room>> GetAllRooms()
        {
            return await this._roomHandler.GetAll();
        }
        /// <summary>
        /// Obtiene una habitacion por su numero
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Devuelve habitacion buscada</returns>
        public async Task<Room> GetRoomByNumber(int number)
        {
            return await this._roomHandler.GetById(number);
        }

        ///<summary>
        /// Agrega una habitacion a la base de datos
        ///</summary>
        ///<param name="appointments"></param>
        public async Task AddRoom(Room room)
        {
            await this._roomHandler.Add(room);
        }

        /// <summary>
        /// Actualiza una habitacion en la base de datos
        // </summary>
        /// <param name="appointments"></param>
        public async Task UpdateRoom(Room room)
        {
            await this._roomHandler.Update(room);
        }

        /// <summary>
        /// Actualiza la disponibilidad de una habitacion en la base de datos
        /// </summary>
        /// <param name="number"></param>
        /// <param name="available"></param>
        /// <returns></returns>
        public async Task UpdateRoomAvailability(int number, bool available)
        {
            await this._roomHandler.UpdateStatus(number, available);
        }

        /// <summary>
        /// Borra una habitacion de la base de datos
        ///</summary>
        /// <param name="appointments"></param>
        public async Task DeleteRoom(int number)
        {
            await this._roomHandler.Delete(number);
        }

        /// <summary>
        /// Obtiene todas las habitaciones disponibles
        /// </summary>
        /// <returns>Devuelve las habitaciones disponibles</returns>
        public async Task<List<Room>> GetAvailableRooms()
        {
            return await this._roomHandler.GetAvailable();
        }
    }
}
