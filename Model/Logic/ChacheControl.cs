using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace CursProjects_GIt.Model.Logic
{
    public class ChacheControl
    {
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        //Preconfigured Encryption Parameters
        public static readonly int BlockBitSize = 128;
        public static readonly int KeyBitSize = 256;

        //Preconfigured Password Key Derivation Parameters
        public static readonly int SaltBitSize = 64;
        public static readonly int Iterations = 10000;
        public static readonly int MinPasswordLength = 12;

        public void ChacheSession(string role)
        {
            string pathName = @"Chache\\session.chacs";

            if (File.Exists(pathName))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(pathName);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            FileStream fs = File.Create(pathName);
            if (File.Exists(pathName))
            {
                MessageBox.Show("ChacheOk");
            }
            //string originalText =
            //File.WriteAllText(pathName, originalText);

        }

        public static byte[] NewKey()
        {
            var key = new byte[KeyBitSize / 8];
            Random.GetBytes(key);
            return key;
        }

        public static string SimpleEncrypt(string secretMessage, byte[] cryptKey, byte[] authKey,
                       byte[] nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(secretMessage))
                throw new ArgumentException("Secret Message Required!", "secretMessage");

            //var plainText = Encoding.UTF8.GetBytes(secretMessage);
            var cipherText = SimpleEncrypt(secretMessage, cryptKey, authKey, nonSecretPayload);
            return cipherText;
        }


        public static string SimpleDecrypt(string encryptedMessage, byte[] cryptKey, byte[] authKey,
                       int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptedMessage))
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            
            var plainText = SimpleDecrypt(encryptedMessage, cryptKey, authKey, nonSecretPayloadLength);
            return plainText;
        }



    }


    
}
