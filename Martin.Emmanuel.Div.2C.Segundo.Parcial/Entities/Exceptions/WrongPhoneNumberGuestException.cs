using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class WrongPhoneNumberGuestException : Exception
    {
        public WrongPhoneNumberGuestException()
        {
        }

        public WrongPhoneNumberGuestException(string? message) : base(message)
        {
        }

        public WrongPhoneNumberGuestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongPhoneNumberGuestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}