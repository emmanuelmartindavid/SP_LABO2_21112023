using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.RoomExceptions
{
    [Serializable]
    public class RoomNotObtainedException : Exception
    {
        private SqlException ex;

        public RoomNotObtainedException()
        {
        }

        public RoomNotObtainedException(SqlException ex)
        {
            this.ex = ex;
        }

        public RoomNotObtainedException(string? message) : base(message)
        {
        }

        public RoomNotObtainedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomNotObtainedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}