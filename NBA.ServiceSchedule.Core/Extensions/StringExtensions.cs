using System.Security.Cryptography;
using System.Text;

namespace NBA.ServiceSchedule.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);

        public static string GetHashValue(this string value)
        {
            var bytes = new UnicodeEncoding().GetBytes(value + "p@ssW0rD_XteNS10n");

            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(bytes);

                var sb = new StringBuilder();
                foreach (var b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
