namespace Klinger.ExtensionsTools
{
    public static class DataExtension
    {
        /* Description
         * Data menor que tantos anos
         */
        public static bool LessThanYears(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddYears(over);

        /* Description
         * Data menor que tantos meses
         */
        public static bool LessThanMonths(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddMonths(over);

        /* Description
         * Data menor que tantos dias
         */
        public static bool LessThanDays(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddDays(over);

        /* Description
         * Idade menor que tantos anos
         */
        public static bool IsUnderage(this DateTime dateTime, int age)
        {
            int resultAge = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now.DayOfYear < dateTime.DayOfYear)
            {
                resultAge--;
            }
            return resultAge <= age;
        }

        /* Description
         * Http Delete as Json
         */
        public static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
