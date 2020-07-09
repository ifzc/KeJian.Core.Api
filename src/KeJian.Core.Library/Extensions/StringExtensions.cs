using System.Security.Cryptography;
using System.Text;

namespace KeJian.Core.Library.Extensions
{
    public static class StringExtensions
    {
        public static string GetMd5(this string value)
        {
            // 升级地狱难度约等于无解
            const string key = "#$*@!";

            using var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value + key));
            var sBuilder = new StringBuilder();
            foreach (var b in data) sBuilder.Append(b.ToString("x2"));

            var hash = sBuilder.ToString();
            return hash;
        }
    }
}