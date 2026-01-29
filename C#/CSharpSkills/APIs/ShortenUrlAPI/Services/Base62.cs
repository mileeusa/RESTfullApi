using System.Text;

namespace ShortenUrlAPI.Services
{
    internal static class Base62
    {
        private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Encode(ulong value)
        {
            if (value == 0UL)
            {
                return "0";
            }

            var sb = new StringBuilder();
            var baseLen = (ulong)Alphabet.Length;
            while (value > 0UL)
            {
                var idx = (int)(value % baseLen);
                sb.Insert(0, Alphabet[idx]);
                value /= baseLen;
            }

            return sb.ToString();
        }
    }
}
