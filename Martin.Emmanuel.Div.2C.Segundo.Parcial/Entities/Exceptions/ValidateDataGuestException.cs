using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class ValidateDataGuestException : Exception
    {
        public ValidateDataGuestException()
        {
        }

        public ValidateDataGuestException(string? message) : base(message)
        {
        }

        public ValidateDataGuestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidateDataGuestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}