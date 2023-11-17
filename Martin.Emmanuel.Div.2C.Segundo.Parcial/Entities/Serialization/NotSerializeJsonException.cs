using System.Runtime.Serialization;

namespace Entities.Serialization
{
    [Serializable]
    internal class NotSerializeJsonException : Exception
    {
        private string v;
        private string message;

        public NotSerializeJsonException()
        {
        }

        public NotSerializeJsonException(string? message) : base(message)
        {
        }

        public NotSerializeJsonException(string v, string message)
        {
            this.v = v;
            this.message = message;
        }

        public NotSerializeJsonException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotSerializeJsonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}