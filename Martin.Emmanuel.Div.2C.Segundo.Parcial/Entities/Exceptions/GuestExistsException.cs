using System.Runtime.Serialization;

namespace Entities.Exceptions
{
    [Serializable]
    public class GuestExistsException : Exception
    {
        public GuestExistsException()
        {
        }

        public GuestExistsException(string? message) : base(message)
        {
        }

        public GuestExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GuestExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}