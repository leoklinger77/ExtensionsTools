using System.Runtime.Serialization;

namespace Klinger.ExtensionsTools.Exceptions
{
    public class DomainToolsException : Exception
    {

        public DomainToolsException(string? message) : base(message)
        {
        }

        public DomainToolsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DomainToolsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
