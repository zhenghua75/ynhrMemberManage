using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Collections.Specialized;

namespace ynhrMemeberManage.Security
{
    [ConfigurationElementType(typeof(CustomSymmetricCryptoProviderData))]
    public class MyCustomEncryptionProvider : ISymmetricCryptoProvider
    {
        public MyCustomEncryptionProvider(NameValueCollection attributes)
        { }

        #region ISymmetricCryptoProvider 成员
        private const string ENCRYPT_KEY = "A^8&o}*z"; //必须是8位
        public byte[] Decrypt(byte[] ciphertext)
        {
            //throw new Exception("The method or operation is not implemented.");
            string strKey = ENCRYPT_KEY + ENCRYPT_KEY;
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            //byte[] inputByteArray = new Byte[strCrypto.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(strKey.Substring(0, 16));
            RijndaelManaged RMCrypto = new RijndaelManaged();
            //inputByteArray = Convert.FromBase64String(strCrypto);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, RMCrypto.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(ciphertext, 0, ciphertext.Length);
            cs.FlushFinalBlock();

            System.Text.Encoding encoding = new System.Text.UTF8Encoding();
            return ms.ToArray();
        }

        public byte[] Encrypt(byte[] plaintext)
        {
            //throw new Exception("The method or operation is not implemented.");
            string strKey = ENCRYPT_KEY + ENCRYPT_KEY;
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            byKey = System.Text.Encoding.UTF8.GetBytes(strKey.Substring(0, 16));
            RijndaelManaged RMCrypto = new RijndaelManaged();
            //byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, RMCrypto.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(plaintext, 0, plaintext.Length);
            cs.FlushFinalBlock();

            return ms.ToArray();
        }

        #endregion
    }
}
