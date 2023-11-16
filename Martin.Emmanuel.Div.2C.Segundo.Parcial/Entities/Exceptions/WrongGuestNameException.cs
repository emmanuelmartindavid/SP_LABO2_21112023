using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class WrongGuestNameException : Exception
    {
        public WrongGuestNameException()
        {
        }

        public WrongGuestNameException(string? message) : base(message)
        {
        }

        public WrongGuestNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongGuestNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}