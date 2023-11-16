using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class ValidateDataRoomException : Exception
    {
        public ValidateDataRoomException()
        {
        }

        public ValidateDataRoomException(string? message) : base(message)
        {
        }

        public ValidateDataRoomException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidateDataRoomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}