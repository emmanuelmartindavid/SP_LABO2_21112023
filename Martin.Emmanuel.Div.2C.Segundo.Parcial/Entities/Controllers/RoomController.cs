using Entities.Handlers;
using Entities.Models;
using Entities.SQLLogic;

namespace Entities.Controllers
{
    public class RoomController
    {
        private readonly IDataBaseGenericRepository<Room> _roomRepository;

        public RoomController()
        {
            this._roomRepository = new RoomRepository(new ContextDb());
        }

        public RoomController(IDataBaseGenericRepository<Room> roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        ///<summary>
        /// Crea lista de todas las habitaciones
        ///</summary>
        /// <returns>Devuelve lista de habitaciones</returns>
        public async Task<List<Room>> GetAllRooms()
        {
            return await this._roomRepository.GetAll();
        }
        /// <summary>
        /// Obtiene una habitacion por su numero
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Devuelve habitacion buscada</returns>
        public async Task<Room> GetRoomByNumber(int number)
        {
            return await this._roomRepository.GetById(number);
        }

        ///<summary>
        /// Agrega una habitacion a la base de datos
        ///</summary>
        ///<param name="appointments"></param>
        public async Task AddRoom(Room room)
        {
            await this._roomRepository.Add(room);
        }

        /// <summary>
        /// Actualiza una habitacion en la base de datos
        // </summary>
        /// <param name="appointments"></param>
        public async Task UpdateRoom(Room room)
        {
            await this._roomRepository.Update(room);
        }

        /// <summary>
        /// Borra una habitacion de la base de datos
        ///</summary>
        /// <param name="appointments"></param>
        public async Task DeleteRoom(int number)
        {
            await this._roomRepository.Delete(number);
        }

 
    }
}
