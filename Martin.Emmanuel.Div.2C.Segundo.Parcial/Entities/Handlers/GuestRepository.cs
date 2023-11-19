using Entities.Handlers.GuestExceptions;
using Entities.Models;
using Entities.SQLLogic;
using System.Data;
using System.Data.SqlClient;

namespace Entities.Handlers
{
    public class GuestRepository : IDataBaseGenericRepository<Guest>
    {
        private readonly ContextDb _contextDb;

        public GuestRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        /// <summary>
        /// Agrega un huesped a la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task Add(Guest guest)
        {
            try
            {
                string query = "INSERT INTO Huespedes (Dni, Nombre, Apellido, NumeroTelefono)" +
                               "values(@dni, @name, @lastName, @phoneNumber)";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("dni", guest.Dni);
                    command.Parameters.AddWithValue("name", guest.Name);
                    command.Parameters.AddWithValue("LastName", guest.LastName);
                    command.Parameters.AddWithValue("phoneNumber", guest.PhoneNumber);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new GuestNotAddedException(ex);
            }
        }
        /// <summary>
        /// Borra un huesped de la base de datos
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        public async Task Delete(int dni)
        {
            try
            {
                string query = "DELETE Huespedes WHERE Dni = @dni";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("dni", dni);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new GuestNotDeletedException(ex);
            }
        }
        /// <summary>
        /// Obtiene un huesped de la base de datos por su dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve al huesped de la base de datos</returns>
        public async Task<Guest> GetById(int dni)
        {
            try
            {
                Guest guest;
                guest = null;
                string query = "SELECT * FROM Huespedes WHERE Dni = @dni";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("Dni", dni);
                    using (var table = await _contextDb.ExecuteReader(command))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            guest = (Guest)row;
                        }
                    }
                }
                return guest;
            }
            catch (SqlException ex)
            {
                throw new GuestNotObtainedException(ex);
            }
        }
        /// <summary>
        /// Obtiene todos los huespedes de la base de datos
        /// </summary>
        /// <returns>Devuelve lista de huesped de la base de datos</returns>
        public async Task<List<Guest>> GetAll()
        {
            try
            {
                var guests = new List<Guest>();
                string query = "SELECT * FROM Huespedes";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    using (var table = await _contextDb.ExecuteReader(command))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            guests.Add((Guest)row);
                        }
                    }
                }
                return guests;
            }
            catch (SqlException ex)
            {
                throw new GuestNotObtainedException(ex);
            }
        }
        /// <summary>
        /// Actualiza un huesped de la base de datos
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        public async Task Update(Guest guest)
        {
            try
            {
                string query = "UPDATE Huespedes SET Dni = @dni, Nombre = @name, Apellido = @lastName," +
                               "NumeroTelefono = @phoneNumber WHERE Dni = @dni";
                using (var command = await _contextDb.CreateCommand(query))
                {
                    command.Parameters.AddWithValue("dni", guest.Dni);
                    command.Parameters.AddWithValue("name", guest.Name);
                    command.Parameters.AddWithValue("LastName", guest.LastName);
                    command.Parameters.AddWithValue("phoneNumber", guest.PhoneNumber);
                    await _contextDb.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                throw new GuestNotUpdatedException(ex);
            }
        }
    }
}
