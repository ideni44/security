using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace lab8
{
    class Program
    {
        private readonly static string CspContainerName = "RSAKeyContainer";
        public static void AssignNewKey(string publicKeyPath)
        {
            CspParameters cspParameters = new CspParameters(1)
            {
                KeyContainerName = CspContainerName,

                ProviderName = "Microsoft Strong Cryptographic Provider"
            };
            var rsa = new RSACryptoServiceProvider(cspParameters)
            {
                PersistKeyInCsp = true
            };
            File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
        }
        public static byte[] EncryptData(string publicKeyPath, byte[] dataToEncrypt)
        {
            byte[] cipherbytes;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath));
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }
            return cipherbytes;
        }
        public static byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plainBytes;
            var cspParams = new CspParameters
            {
                KeyContainerName = CspContainerName,
            };
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                plainBytes = rsa.Decrypt(dataToDecrypt, false);
            }
            return plainBytes;
        }
        
        static void Main(string[] args)
        {
            string data = "Hi! I am Ilya. THello world!";
            AssignNewKey("BolshakovArtem.xml");
            var encrypted = EncryptData("BolshakovDenis.xml", Encoding.Unicode.GetBytes(data));
            File.WriteAllBytes("encryptMessage.dat", encrypted);
            Console.WriteLine(" Original Text = " + data);
            Console.WriteLine();
            Console.WriteLine(" Encrypted Text = " + Convert.ToBase64String(encrypted));
        }
    }
}