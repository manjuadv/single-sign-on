using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class CryptoHelper
    {
        private static int _saltSize = 32;
        //public static string SymmetricEncrypt(string text, string Password)
        //{
        //    int Rfc2898KeygenIterations = 100;
        //    int AesKeySizeInBits = 128;
        //    byte[] Salt = new byte[16];
        //    System.Random rnd = new System.Random();
        //    rnd.NextBytes(Salt);
        //    byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes(text);
        //    byte[] cipherText = null;
        //    using (Aes aes = new AesManaged())
        //    {
        //        aes.Padding = PaddingMode.PKCS7;
        //        aes.KeySize = AesKeySizeInBits;
        //        int KeyStrengthInBytes = aes.KeySize / 8;
        //        System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
        //            new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
        //        aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
        //        aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(rawPlaintext, 0, rawPlaintext.Length);
        //            }
        //            cipherText = ms.ToArray();
        //        }
        //    }
        //    return System.Text.Encoding.Unicode.GetString(cipherText);
        //}
        //public static string SymmetricDecrypt(string cipherTextStr, string Password)
        //{
        //    int Rfc2898KeygenIterations = 100;
        //    int AesKeySizeInBits = 128;
        //    byte[] Salt = new byte[16];
        //    System.Random rnd = new System.Random();
        //    rnd.NextBytes(Salt);
        //    byte[] cipherText = System.Text.Encoding.Unicode.GetBytes(cipherTextStr);
        //    byte[] plainText = null;
        //    using (Aes aes = new AesManaged())
        //    {
        //        aes.Padding = PaddingMode.PKCS7;
        //        aes.KeySize = AesKeySizeInBits;
        //        int KeyStrengthInBytes = aes.KeySize / 8;
        //        System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
        //            new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
        //        aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
        //        aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherText, 0, cipherText.Length);
        //            }
        //            plainText = ms.ToArray();
        //        }
        //    }
        //    return System.Text.Encoding.Unicode.GetString(plainText);
        //}
        public static string Encrypt(string plainText, string key)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException("plainText");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, _saltSize))
            {
                byte[] saltBytes = keyDerivationFunction.Salt;
                byte[] keyBytes = keyDerivationFunction.GetBytes(32);
                byte[] ivBytes = keyDerivationFunction.GetBytes(16);

                using (var aesManaged = new AesManaged())
                {
                    aesManaged.KeySize = 256;

                    using (var encryptor = aesManaged.CreateEncryptor(keyBytes, ivBytes))
                    {
                        MemoryStream memoryStream = null;
                        CryptoStream cryptoStream = null;

                        return WriteMemoryStream(plainText, ref saltBytes, encryptor, ref memoryStream, ref cryptoStream);
                    }
                }
            }
        }

        public static string Decrypt(string ciphertext, string key)
        {
            if (string.IsNullOrEmpty(ciphertext))
            {
                throw new ArgumentNullException("ciphertext");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var allTheBytes = Convert.FromBase64String(ciphertext);
            var saltBytes = allTheBytes.Take(_saltSize).ToArray();
            var ciphertextBytes = allTheBytes.Skip(_saltSize).Take(allTheBytes.Length - _saltSize).ToArray();

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, saltBytes))
            {
                var keyBytes = keyDerivationFunction.GetBytes(32);
                var ivBytes = keyDerivationFunction.GetBytes(16);

                return DecryptWithAES(ciphertextBytes, keyBytes, ivBytes);
            }
        }

        private static string WriteMemoryStream(string plainText, ref byte[] saltBytes, ICryptoTransform encryptor, ref MemoryStream memoryStream, ref CryptoStream cryptoStream)
        {
            try
            {
                memoryStream = new MemoryStream();

                try
                {
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                }
                finally
                {
                    if (cryptoStream != null)
                    {
                        cryptoStream.Dispose();
                    }
                }

                var cipherTextBytes = memoryStream.ToArray();
                Array.Resize(ref saltBytes, saltBytes.Length + cipherTextBytes.Length);
                Array.Copy(cipherTextBytes, 0, saltBytes, _saltSize, cipherTextBytes.Length);

                return Convert.ToBase64String(saltBytes);
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        private static string DecryptWithAES(byte[] ciphertextBytes, byte[] keyBytes, byte[] ivBytes)
        {
            using (var aesManaged = new AesManaged())
            {
                using (var decryptor = aesManaged.CreateDecryptor(keyBytes, ivBytes))
                {
                    MemoryStream memoryStream = null;
                    CryptoStream cryptoStream = null;
                    StreamReader streamReader = null;

                    try
                    {
                        memoryStream = new MemoryStream(ciphertextBytes);
                        cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                        streamReader = new StreamReader(cryptoStream);

                        return streamReader.ReadToEnd();
                    }
                    finally
                    {
                        if (memoryStream != null)
                        {
                            memoryStream.Dispose();
                            memoryStream = null;
                        }
                    }
                }
            }
        }
    }
}
