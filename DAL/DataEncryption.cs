using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DAL
{
    public class DataEncryption
    {
        /// <summary>
        /// turn plainText into ciphertext in MD5 encryption algorithm
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string PasswordEncryption(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.Unicode.GetBytes(plainText);
            byte[] targetData = md5.ComputeHash(fromData);
            string cipherText = string.Empty;
            for (int i = 0; i < targetData.Length; i++)
            {
                cipherText += targetData[i].ToString("x");
            }
            return cipherText;
        }
    }
}
