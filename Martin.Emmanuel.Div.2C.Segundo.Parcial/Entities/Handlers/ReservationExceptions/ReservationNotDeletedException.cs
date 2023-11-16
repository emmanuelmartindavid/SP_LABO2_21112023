using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.ReservationExceptions
{
    [Serializable]
    public class ReservationNotDeletedException : Exception
    {
        private SqlException ex;

        public ReservationNotDeletedException()
        {
        }

        public ReservationNotDeletedException(SqlException ex)
        {
            this.ex = ex;
        }

        public ReservationNotDeletedException(string? message) : base(message)
        {
        }

        public ReservationNotDeletedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}