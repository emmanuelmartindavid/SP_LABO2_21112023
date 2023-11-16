using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.GuestExceptions
{
    [Serializable]
    public class GuestNotObtainedException : Exception
    {
        private SqlException ex;

        public GuestNotObtainedException()
        {
        }

        public GuestNotObtainedException(SqlException ex)
        {
            this.ex = ex;
        }

        public GuestNotObtainedException(string? message) : base(message)
        {
        }

        public GuestNotObtainedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GuestNotObtainedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}