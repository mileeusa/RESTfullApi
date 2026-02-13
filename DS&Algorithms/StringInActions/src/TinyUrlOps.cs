using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInActions.src
{
    public class TinyUrlOps
    {
        private const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();
        private int count = 1;

        public string Encode(string longUrl)
        {
            string key = GetString();
            _dict[key] = longUrl;
            count++;

            return "http://tinyurl.com/" + key;
        }

        public string Decode(string shortUrl)
        {
            string key = shortUrl.Replace("http://tinyurl.com/", "");

            if (_dict.TryGetValue(key, out var longUrl))
                return longUrl;

            return "";
        }

        private string GetString()
        {
            int c = count;
            var sb = new StringBuilder();

            while (c > 0)
            {
                c--;
                sb.Append(chars[c % 62]);
                c /= 62;
            }

            return sb.ToString();
        }
    }
}
