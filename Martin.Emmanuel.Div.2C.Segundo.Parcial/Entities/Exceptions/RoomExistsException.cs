using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class RoomExistsException : Exception
    {
        public RoomExistsException()
        {
        }

        public RoomExistsException(string? message) : base(message)
        {
        }

        public RoomExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoomExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}