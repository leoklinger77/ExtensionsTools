using Klinger.ExtensionsTools.Exceptions;

namespace Klinger.ExtensionsTools.Validations
{
    public static class DomainValidation
    {
        public static void ValidateIfEqual(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfdifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainToolsException(message);
            }
        }
        public static void CharactersValidate(string value, int max, string message)
        {
            var length = value.Trim().Length;
            if (length > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void CharactersValidate(string value, int max, int min, string message)
        {
            var length = value.Trim().Length;
            if (length < min || length > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateMinMax(double value, double min, double max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateMinMax(float value, float min, float max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateMinMax(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateMinMax(long value, long min, long max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateMinMax(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfLessThan(long value, long min, string message)
        {
            if (value < min)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfLessThan(double value, double min, string message)
        {
            if (value < min)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfLessThan(float value, float min, string message)
        {
            if (value < min)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfTrue(bool v, object nUMBER_REPIT_ERRO_MSG)
        {
            throw new NotImplementedException();
        }
        public static void ValidateIfLessThan(int value, int min, string message)
        {
            if (value < min)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfLessThan(decimal value, decimal min, string message)
        {
            if (value < min)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfFalse(bool boolvalue, string message)
        {
            if (!boolvalue)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfTrue(bool boolvalue, string message)
        {
            if (boolvalue)
            {
                throw new DomainToolsException(message);
            }
        }
        public static void ValidateIfContains(string contais, string value, string message)
        {
            if (contais.Contains(value))
            {
                throw new DomainToolsException(message);
            }
        }
    }
}
