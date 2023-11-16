using Entities.Models;
using Entities.SQLLogic;
using System.Data;

namespace Entities.Handlers
{
    internal class RoomHandler : CommandDataBase, IManagementDataBase<Room>
    {
        ///<summary>
        ///Agrega una habitacion a la base de datos
        ///</summary>
        ///<param name="room"></param>
        ///<returns></returns>
        public async Task Add(Room room)
        {
            string query = "INSERT INTO Habitaciones (Numero, Disponible, Tipo)" +
                           "values(@number, @available, @type)";
            using (var command = await this.CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", room.Number);
                command.Parameters.AddWithValue("available", room.Available);
                command.Parameters.AddWithValue("type", (int)room.Type);
                await ExecuteNonQuery(command);
            }
        }

        ///<summary>
        ///Borra una habitacion de la base de datos
        ///</summary>
        ///<param name="number"></param>
        ///<returns></returns>
        public async Task Delete(int number)
        {
            string query = "DELETE Habitaciones WHERE Numero = @number";
            using (var command = await this.CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", number);
                await ExecuteNonQuery(command);
            }
        }

        /// <summary>
        /// Devuelve una lista de todas las habitaciones
        /// </summary>
        ///<returns></returns>
        public async Task<List<Room>> GetAll()
        {
            var rooms = new List<Room>();
            string query = "SELECT * FROM Habitaciones";
            using (var command = await CreateCommand(query))
            {
                using (var table = await ExecuteReader(command))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rooms.Add((Room)row);
                    }
                }
                return rooms;
            }
        }
        /// <summary>
        ///  Obtiene una habitacion por su numero
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<Room> GetById(int number)
        {
            string query = "SELECT * FROM Habitaciones WHERE Numero = @number";
            using (var command = await CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", number);
                using (var table = await ExecuteReader(command))
                {
                    return (Room)table.Rows[0];
                }
            }
        }

        /// <summary>
        ///  Actualiza una habitacion en la base de datos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(Room entity)
        {
            string query = "UPDATE Habitaciones SET Numero = @number, Tipo = @type, Disponible = @available WHERE Numero = @number";
            using (var command = await this.CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", entity.Number);
                command.Parameters.AddWithValue("available", entity.Available);
                command.Parameters.AddWithValue("type", (int)entity.Type);
                await ExecuteNonQuery(command);
            }
        }

        /// <summary>
        ///  Actualiza la disponibilidad de una habitacion en la base de datos
        /// </summary>
        /// <param name="room"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task UpdateStatus(Room room, bool status)
        {
            string query = "UPDATE Habitaciones SET Disponible = @available WHERE Numero = @number";
            using (var command = await this.CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", room.Number);
                command.Parameters.AddWithValue("available", status);
                await ExecuteNonQuery(command);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task UpdateStatus(int id, bool status)
        {
            string query = "UPDATE Habitaciones SET Disponible = @available WHERE Numero = @number";
            using (var command = await this.CreateCommand(query))
            {
                command.Parameters.AddWithValue("number", id);
                command.Parameters.AddWithValue("available", status);
                await ExecuteNonQuery(command);
            }

        }

        /// <summary>
        ///  Obtener todas las habitaciones disponibles
        /// </summary>
        /// <returns></returns>
        public async Task<List<Room>> GetAvailable()
        {
            var rooms = new List<Room>();
            string query = "SELECT * FROM Habitaciones WHERE Disponible = 1";
            using (var command = await CreateCommand(query))
            {
                using (var table = await ExecuteReader(command))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        rooms.Add((Room)row);
                    }
                }
                return rooms;
            }
        }       
    }
}
