using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Entities.Handlers.ReservationExceptions
{
    [Serializable]
    public class ReservationNotAddedException : Exception
    {
        private SqlException ex;

        public ReservationNotAddedException()
        {
        }

        public ReservationNotAddedException(SqlException ex)
        {
            this.ex = ex;
        }

        public ReservationNotAddedException(string? message) : base(message)
        {
        }

        public ReservationNotAddedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationNotAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}