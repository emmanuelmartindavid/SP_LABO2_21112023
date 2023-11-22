using System.Data.SqlClient;

namespace Entities.SQLLogic
{
    public class ConnectionDataBase
    {
        protected SqlConnection? _connection;
        private readonly static string _connectionString;

        static ConnectionDataBase()
        {
            _connectionString = "Server=.;Database=Hotel-Segundo-Parcial-Labo;Trusted_Connection=True;";
        }

        /// <summary>
        /// Abre la conexión con la base de datos   
        /// </summary>
        /// <returns></returns>
        public async Task Open()
        {
            _connection = new SqlConnection(_connectionString);
            await _connection.OpenAsync();
        }

        /// <summary>
        /// Cierre la conexión con la base de datos
        /// </summary>
        public void Close()
        {
            _connection?.Close();
        }
    }
}
