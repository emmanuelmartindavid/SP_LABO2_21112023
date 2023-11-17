using System.Runtime.Serialization;

namespace Entities.Serialization
{
    [Serializable]
    internal class NotDeserializeJsonException : Exception
    {
        private string v;
        private string message;

        public NotDeserializeJsonException()
        {
        }

        public NotDeserializeJsonException(string? message) : base(message)
        {
        }

        public NotDeserializeJsonException(string v, string message)
        {
            this.v = v;
            this.message = message;
        }

        public NotDeserializeJsonException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotDeserializeJsonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}