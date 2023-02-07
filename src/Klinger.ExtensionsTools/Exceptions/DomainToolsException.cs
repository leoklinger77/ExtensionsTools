using System.Runtime.Serialization;

namespace Klinger.ExtensionsTools.Exceptions
{
    public class DomainToolsException : Exception
    {

        public DomainToolsException(string message) : base(message)
        {
        }

        public DomainToolsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DomainToolsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static void ThrowIfNull(object? argument, string? paramName = null)
        {
            if (argument is null)
            {
                throw new DomainToolsException(paramName);
            }
        }
    }
}
