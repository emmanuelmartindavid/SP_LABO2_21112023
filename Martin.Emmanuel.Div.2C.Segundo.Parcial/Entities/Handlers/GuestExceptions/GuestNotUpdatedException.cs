using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.GuestExceptions
{
    [Serializable]
    public class GuestNotUpdatedException : Exception
    {
        private SqlException ex;

        public GuestNotUpdatedException()
        {
        }

        public GuestNotUpdatedException(SqlException ex)
        {
            this.ex = ex;
        }

        public GuestNotUpdatedException(string? message) : base(message)
        {
        }

        public GuestNotUpdatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GuestNotUpdatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}