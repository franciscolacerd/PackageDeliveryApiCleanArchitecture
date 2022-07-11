﻿namespace PackageDelivery.Domain.Extensions
{
    public static class RandomValuesExtensions
    {
        private static readonly Random Random = new Random();

        public static string ToRandomString(this int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(Chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string ToRandomStringOfInts(this int length)
        {
            const string Chars = "0123456789";
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static int ToRandomInt(this int length)
        {
            const string Chars = "0123456789";
            var result = Enumerable.Repeat(Chars, length).Select(s => s[Random.Next(s.Length)]).ToArray();
            return int.Parse(new string(result));
        }

        public static decimal ToRandomDecimal(this int length)
        {
            const string Chars = "0123456789";
            var result = Enumerable.Repeat(Chars, length).Select(s => s[Random.Next(s.Length)]).ToArray();
            return decimal.Parse(new string(result));
        }
    }
}
