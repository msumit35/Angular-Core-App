using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Core.Webapi.Helpers
{
    public class Hasher
    {
        private const string key = "ThisissecretkeyThisissecretkeyThisissecretkeyThisissecretkey";
        public static string GetHash(string value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(key),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public static bool Verify(string value1, string value2)
        {
            return GetHash(value1) == value2;
        }
    }
}
