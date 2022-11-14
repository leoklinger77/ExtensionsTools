namespace Klinger.ExtensionsTools
{
    public static class DataExtension
    {
        public static bool DataOverYears(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddYears(over);
        public static bool DataOverMonths(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddMonths(over);
        public static bool DataOverDays(this DateTime date, int over = 1) =>
            date.Date <= DateTime.Now.AddDays(over);
        public static bool IsUnderage(this DateTime dateTime)
        {
            int age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now.DayOfYear < dateTime.DayOfYear)
            {
                age--;
            }
            return age <= 18;
        }
        public static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
