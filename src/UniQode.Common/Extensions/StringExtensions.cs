using System.Text;

namespace UniQode.Common.Extensions
{
    public static class StringExtensions
    {
        public static string SanitizeTitle(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            var whitelisted = "abcdefghijklmnopqrstuvwxyz-_";
            var builder = new StringBuilder();

            input = input.ToLower();
            input = input.Replace(" ", "-");

            for (var i = 0; i < input.Length; ++i)
            {
                if (whitelisted.Contains(input[i].ToString()))
                {
                    builder.Append(input[i]);
                }
            }

            return builder.ToString();
        }
    }
}