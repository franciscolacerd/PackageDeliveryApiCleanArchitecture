namespace PackageDelivery.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperCaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return char.ToUpper(str[0]) + str.Substring(1);
        }

    }
}
