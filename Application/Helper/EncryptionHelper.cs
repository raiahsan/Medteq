﻿#region Imports

using System;
using System.IO;
using System.Security.Cryptography;
using static BCrypt.Net.BCrypt;

#endregion

namespace Application.Helper
{
    public static class EncryptionHelper
    {
        public static string WithBCrypt(this string text)
        {
            var result = HashPassword(text);
            return result;
        }

        public static bool VerifyWithBCrypt(this string hashedPassword, string plainText)
        {
            var result = Verify(plainText, hashedPassword);
            return result;
        }

        #region Custom encryption

        private static readonly byte[] Key = Convert.FromBase64String("AsISxq9OwdZag1163OJqwovXfSWG98m+sPjVwJecfe4=");

        private static readonly byte[] IV = Convert.FromBase64String("Aq0UThtJhjbuyWXtmZs1rw==");

        public static byte[] EncryptStringToBytes(string profileText)
        {
            byte[] encryptedAuditTrail;

            using (var newAes = Aes.Create())
            {
                newAes.Key = Key;
                newAes.IV = IV;

                var encryptor = newAes.CreateEncryptor(Key, IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(profileText);
                        }

                        encryptedAuditTrail = msEncrypt.ToArray();
                    }
                }
            }

            return encryptedAuditTrail;
        }

        public static string DecryptStringFromBytes(byte[] profileText)
        {
            string decryptText;

            using (var newAes = Aes.Create())
            {
                newAes.Key = Key;
                newAes.IV = IV;

                var decryptor = newAes.CreateDecryptor(Key, IV);

                using (var msDecrypt = new MemoryStream(profileText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }


            return decryptText;
        }

        #endregion
    }
}