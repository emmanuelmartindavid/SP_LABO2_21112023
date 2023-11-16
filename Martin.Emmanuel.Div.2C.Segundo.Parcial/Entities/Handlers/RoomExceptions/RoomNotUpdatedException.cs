using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.RoomExceptions
{
    [Serializable]
    public class RoomNotUpdatedException : Exception
    {
        private SqlException ex;

        public RoomNotUpdatedException()
        {
        }

        public RoomNotUpdatedException(SqlException ex)
        {
            this.ex = ex;
        }

        public RoomNotUpdatedException(string? message) : base(message)
        {
        }

        public RoomNotUpdatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomNotUpdatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}