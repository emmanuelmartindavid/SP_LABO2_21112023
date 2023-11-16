using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.ReservationExceptions
{
    [Serializable]
    public class ReservationNotObtainedException : Exception
    {
        private SqlException ex;

        public ReservationNotObtainedException()
        {
        }

        public ReservationNotObtainedException(SqlException ex)
        {
            this.ex = ex;
        }

        public ReservationNotObtainedException(string? message) : base(message)
        {
        }

        public ReservationNotObtainedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationNotObtainedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}