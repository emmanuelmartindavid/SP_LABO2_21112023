using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.RoomExceptions
{
    [Serializable]
    public class RoomNotAddedException : Exception
    {
        private SqlException ex;

        public RoomNotAddedException()
        {
        }

        public RoomNotAddedException(SqlException ex)
        {
            this.ex = ex;
        }

        public RoomNotAddedException(string? message) : base(message)
        {
        }

        public RoomNotAddedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}