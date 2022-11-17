namespace Klinger.ExtensionsTools.Tools
{
    public static class DataExtension
    {
        /* Description
         * Data menor que tantos anos
         */
        public static bool DateLessThanYear(this DateTime date, int over = 1) =>
            DateTime.Now.AddYears(-over).Date <= date.Date;


        /* Description
         * Data menor que tantos meses
         */
        public static bool DateLessThanMonths(this DateTime date, int over = 1) =>
            DateTime.Now.AddMonths(-over).Date <= date.Date;

        /* Description
         * Data menor que tantos dias
         */
        public static bool DateLessThanDays(this DateTime date, int over = 1) =>
            DateTime.Now.AddDays(-over).Date <= date.Date;

        /* Description
         * Data menor que tantos anos
         */
        public static bool DateGreaterThanYears(this DateTime date, int over = 1)
        {
            var r = DateTime.Now.AddYears(over).Date;
            return r >= date.Date;
        }

        /* Description
         * Data menor que tantos meses
         */
        public static bool DateGreaterThanMonths(this DateTime date, int over = 1) =>
        DateTime.Now.AddMonths(over).Date >= date.Date;

        /* Description
         * Data menor que tantos dias
         */
        public static bool DateGreaterThanDays(this DateTime date, int over = 1) =>
            DateTime.Now.AddDays(over).Date >= date.Date;

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
