using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.GuestExceptions
{
    [Serializable]
    public class GuestNotDeletedException : Exception
    {
        private SqlException ex;

        public GuestNotDeletedException()
        {
        }

        public GuestNotDeletedException(SqlException ex)
        {
            this.ex = ex;
        }

        public GuestNotDeletedException(string? message) : base(message)
        {
        }

        public GuestNotDeletedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GuestNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}