using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class WrongGuestDniException : Exception
    {
        public WrongGuestDniException()
        {
        }

        public WrongGuestDniException(string? message) : base(message)
        {
        }

        public WrongGuestDniException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongGuestDniException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}