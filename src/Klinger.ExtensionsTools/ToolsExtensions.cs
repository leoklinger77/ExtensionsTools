namespace Klinger.ExtensionsTools
{
    public static class ToolsExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> itemAction)
        {
            foreach (var item in items)
            {
                itemAction(item);
            }
        }
        public static bool IsEnum<T>(this int value)
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static bool IsEnum<T>(this Enum value)
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static bool IsDomainValid(this string email, string domain)
        {
            var result = email.ToUpper().Split('@');

            if (result[1] != domain)
            {
                return false;
            }
            return true;
        }        
        public static bool IsNumPhone(this string number)
        {
            number = number.OnlyNumbers();
            if (number.Length == 11 && number.Substring(2, 1) == "9")
                return true;

            return false;
        }
        public static bool IsNumFixo(this string number)
        {
            number = number.OnlyNumbers();
            if (number.Length == 10)
                return true;

            return false;
        }
        public static bool IsNumFixoOrCommercial(this string number)
        {
            number = number.OnlyNumbers();
            if (number.IsNumFixo())
                return true;
            else
                return number.IsNumPhone();
        }
        public static double BytesToKilobyte(this int bytes) => Math.Pow(bytes, 10);
        public static double BytesToMegabyte(this int bytes) => Math.Pow(bytes, 20);
        public static double BytesToGigabyte(this int bytes) => Math.Pow(bytes, 20);
    }
}
