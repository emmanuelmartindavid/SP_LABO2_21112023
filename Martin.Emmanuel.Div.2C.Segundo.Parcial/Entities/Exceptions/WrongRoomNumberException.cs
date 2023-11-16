using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class WrongRoomNumberException : Exception
    {
        public WrongRoomNumberException()
        {
        }

        public WrongRoomNumberException(string? message) : base(message)
        {
        }

        public WrongRoomNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongRoomNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}