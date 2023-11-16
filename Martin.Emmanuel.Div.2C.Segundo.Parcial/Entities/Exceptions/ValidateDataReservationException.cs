using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class ValidateDataReservationException : Exception
    {
        public ValidateDataReservationException()
        {
        }

        public ValidateDataReservationException(string? message) : base(message)
        {
        }

        public ValidateDataReservationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidateDataReservationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}