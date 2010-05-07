using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace NoName.Utility
{
    public class TripleDesUtil
    {
        private static byte[] seciv = { 0xEF, 0xAB, 0x56, 0x78, 0x90, 0x34, 0xCD, 0x12 };
        // EncryptString
        //    Encrypts a configuration section and returns the encrypted
        // XML as a string.
        public static string EncryptString(string encryptValue,string key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] valBytes = Encoding.Default.GetBytes(encryptValue);
            byte[] seckey = Encoding.Default.GetBytes(key);
            ICryptoTransform transform = des.CreateEncryptor(seckey,seciv);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();
            return Convert.ToBase64String(returnBytes);
        }

        public static string EncryptString(string encryptValue, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] valBytes = Encoding.Default.GetBytes(encryptValue);
            ICryptoTransform transform = des.CreateEncryptor(key, seciv);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();
            return Convert.ToBase64String(returnBytes);
        }
        //
        // DecryptString
        //    Decrypts an encrypted configuration section and returns the
        // unencrypted XML as a string.
        //

        public static string DecryptString(string encryptedValue, string key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] seckey = Encoding.Default.GetBytes(key);
            byte[] valBytes = Convert.FromBase64String(encryptedValue);

            ICryptoTransform transform = des.CreateDecryptor(seckey,seciv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();
            return Encoding.Default.GetString(returnBytes);
        }

        public static string DecryptString(string encryptedValue, byte[] key)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            byte[] valBytes = Convert.FromBase64String(encryptedValue);

            ICryptoTransform transform = des.CreateDecryptor(key, seciv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(valBytes, 0, valBytes.Length);
            cs.FlushFinalBlock();
            byte[] returnBytes = ms.ToArray();
            cs.Close();
            return Encoding.Default.GetString(returnBytes);
        }
    }
}
