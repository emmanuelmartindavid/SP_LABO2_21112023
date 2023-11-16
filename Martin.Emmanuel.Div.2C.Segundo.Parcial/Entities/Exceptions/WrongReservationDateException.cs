using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class WrongReservationDateException : Exception
    {
        public WrongReservationDateException()
        {
        }

        public WrongReservationDateException(string? message) : base(message)
        {
        }

        public WrongReservationDateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongReservationDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}