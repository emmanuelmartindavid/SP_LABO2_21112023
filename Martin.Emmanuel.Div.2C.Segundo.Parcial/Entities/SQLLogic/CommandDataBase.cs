using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SQLLogic
{
    public class CommandDataBase : ConnectionDataBase
    {
        /// <summary>
        /// Abre la conexión con la base de datos y crea un comando
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<SqlCommand> CreateCommand(string query)
        {
            await Open();
            var command = new SqlCommand(query, this._connection);
            return command;
        }

        /// <summary>
        /// Encapsula el ExecuteReaderAsync y crea la dataTable
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<DataTable> ExecuteReader(SqlCommand c)
        {
            var reader = await c.ExecuteReaderAsync();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();

            return dataTable;
        }

        /// <summary>
        /// Encapsula el ExecuteNonQueryAsync
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task ExecuteNonQuery(SqlCommand c)
        {
            await c.ExecuteNonQueryAsync();
        }
    }
}
