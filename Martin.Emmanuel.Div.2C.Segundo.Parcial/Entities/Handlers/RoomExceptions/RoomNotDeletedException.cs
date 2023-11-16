using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.RoomExceptions
{
    [Serializable]
    public class RoomNotDeletedException : Exception
    {
        private SqlException ex;

        public RoomNotDeletedException()
        {
        }

        public RoomNotDeletedException(SqlException ex)
        {
            this.ex = ex;
        }

        public RoomNotDeletedException(string? message) : base(message)
        {
        }

        public RoomNotDeletedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}