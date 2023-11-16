using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.GuestExceptions
{
    [Serializable]
    public class GuestNotAddedException : Exception
    {
        private SqlException ex;

        public GuestNotAddedException()
        {
        }

        public GuestNotAddedException(SqlException ex)
        {
            this.ex = ex;
        }

        public GuestNotAddedException(string? message) : base(message)
        {
        }

        public GuestNotAddedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GuestNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}