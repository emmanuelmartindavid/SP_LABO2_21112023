using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.ReservationExceptions
{
    [Serializable]
    public class ReservationNotUpdatedException : Exception
    {
        private SqlException ex;

        public ReservationNotUpdatedException()
        {
        }

        public ReservationNotUpdatedException(SqlException ex)
        {
            this.ex = ex;
        }

        public ReservationNotUpdatedException(string? message) : base(message)
        {
        }

        public ReservationNotUpdatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationNotUpdatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}