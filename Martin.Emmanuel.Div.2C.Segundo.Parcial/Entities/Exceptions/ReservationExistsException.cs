using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class ReservationExistsException : Exception
    {
        public ReservationExistsException()
        {
        }

        public ReservationExistsException(string? message) : base(message)
        {
        }

        public ReservationExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ReservationExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}