﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StimulTest.Utility
{
    class CodingFunction
    {
        private static string Key = "MajidMehdipour1365";

        public static string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                System.Configuration.AppSettingsReader settingsReader =
                    new AppSettingsReader();

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    hashmd5.Clear();
                }
                else
                {
                    keyArray = UTF8Encoding.UTF8.GetBytes(Key);
                }

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;

                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                    toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return "ERROR";
            }
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                System.Configuration.AppSettingsReader settingsReader =
                    new AppSettingsReader();

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(Key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;

                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray =
                    cTransform.TransformFinalBlock(toEncryptArray, 0,
                        toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                return "ERROR";
            }
        }
    }
}
