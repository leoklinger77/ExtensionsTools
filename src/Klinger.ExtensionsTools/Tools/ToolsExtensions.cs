using Microsoft.AspNetCore.Mvc.Rendering;

namespace Klinger.ExtensionsTools.Tools
{
    public static class ToolsExtensions
    {
        /* Description
         * ForEach apartir de um IEnumerable
         */
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> itemAction)
        {
            if (items is null) return;
            foreach (var item in items)
            {
                itemAction(item);
            }
        }

        /* Description
         * Verifica se int é um enum valido
         */
        public static bool IsEnum<T>(this int value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        /* Description
         * Verifica se Enum informado é valido
         */
        public static bool IsEnum<T>(this Enum value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        /* Description
         * Verifica dominio valido
         */
        public static bool IsDomainValid(this string email, string domain)
        {
            var result = email.ToUpper().Split('@');

            if (result[1] != domain)
            {
                return false;
            }
            return true;
        }

        /* Description
         * Verifica se Celular é valido
         */
        public static bool IsNumPhone(this string number)
        {
            number = number.OnlyNumbers();
            if (number.Length == 11 && number.Substring(2, 1) == "9")
                return true;

            return false;
        }

        /* Description
         * Verifica se Fixo é valido
         */
        public static bool IsNumFixo(this string number)
        {
            number = number.OnlyNumbers();
            if (number.Length == 10)
                return true;

            return false;
        }

        /* Description
         * Verifica se é Fixo ou Celular
         */
        public static bool IsNumFixoOrPhone(this string number)
        {
            number = number.OnlyNumbers();
            if (number.IsNumFixo())
                return true;
            else
                return number.IsNumPhone();
        }

        /* Description
         * Calculo Bytes para KiloBytes
         */
        public static double BytesToKilobyte(this int bytes) => Math.Pow(bytes, 10);

        /* Description
         * Calculo Bytes para MegaBytes
         */
        public static double BytesToMegabyte(this int bytes) => Math.Pow(bytes, 20);

        /* Description
         * Calculo Bytes para GigaBytes
         */
        public static double BytesToGigabyte(this int bytes) => Math.Pow(bytes, 20);

        public static string PageNavClass(this ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
