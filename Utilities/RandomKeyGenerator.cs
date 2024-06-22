using System;
using System.Security.Cryptography;

namespace BookStore.Utilities 
{
    public static class RandomKeyGenerator
    {
        public static string GenerateRandomKey(int keyLengthInBytes)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var randomBytes = new byte[keyLengthInBytes];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            var chars = new char[keyLengthInBytes];
            for (int i = 0; i < keyLengthInBytes; i++)
            {
                chars[i] = validChars[randomBytes[i] % validChars.Length];
            }

            return new string(chars);
        }
    }


}
