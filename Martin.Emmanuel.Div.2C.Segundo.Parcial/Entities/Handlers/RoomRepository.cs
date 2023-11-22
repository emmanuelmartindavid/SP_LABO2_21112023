using Entities.Handlers.RoomExceptions;
using Entities.Models;
using Entities.SQLLogic;
using System.Data;
using System.Data.SqlClient;

namespace Entities.Handlers
{
    /// <summary>
    /// Clase que se encarga de la logica de la base de datos de las habitaciones
    /// </summary>
    public class RoomRepository : IDataBaseGenericRepository<Room>
    {
        private readonly ContextDb _contextDb;
        public RoomRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        ///<summary>
        ///Agrega una habitacion a la base de datos
        ///</summary>
        ///<param name="room"></param>
        ///<returns></returns>
        public async Task Add(Room room)
        {
            try
            {
                string query = "INSERT INTO Habitaciones (Numero, Disponible, Tipo)" +
                               "values(@number, @available, @type)";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("number", room.Number);
                    command.Parameters.AddWithValue("available", room.Available);
                    command.Parameters.AddWithValue("type", (int)room.Type);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new RoomNotAddedException(ex);
            }
        }
        ///<summary>
        ///Borra una habitacion de la base de datos
        ///</summary>
        ///<param name="number"></param>
        ///<returns></returns>
        public async Task Delete(int number)
        {
            try
            {
                string query = "DELETE Habitaciones WHERE Numero = @number";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("number", number);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new RoomNotDeletedException(ex);
            }

        }
        /// <summary>
        /// Obtiene todas las habitaciones de la base de datos
        /// </summary>
        ///<returns>Devuelve una lista de todas las habitaciones de la base de datos</returns>
        public async Task<List<Room>> GetAll()
        {
            try
            {
                var rooms = new List<Room>();
                string query = "SELECT * FROM Habitaciones";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    using (var table = await _contextDb.ExecuteReader(command))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            rooms.Add((Room)row);
                        }
                    }

                }
                return rooms;
            }
            catch (SqlException ex)
            {
                throw new RoomNotObtainedException(ex);
            }

        }
        /// <summary>
        ///  Obtiene una habitacion por su numero
        /// </summary>
        /// <param name="number"></param>
        /// <returns> Devuelve la habitacion seleccionada</returns>
        public async Task<Room> GetById(int number)
        {
            try
            {
                string query = "SELECT * FROM Habitaciones WHERE Numero = @number";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("number", number);
                    using (var table = await _contextDb.ExecuteReader(command))
                    {
                        return (Room)table.Rows[0];
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new RoomNotObtainedException(ex);
            }

        }
        /// <summary>
        ///  Actualiza una habitacion en la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(Room room)
        {
            try
            {
                string query = "UPDATE Habitaciones SET Numero = @number, Tipo = @type, Disponible = @available WHERE Numero = @number";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("number", room.Number);
                    command.Parameters.AddWithValue("available", room.Available);
                    command.Parameters.AddWithValue("type", (int)room.Type);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new RoomNotUpdatedException(ex);
            }

        }
    }
}
