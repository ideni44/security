using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] dData = File.ReadAllBytes("text.txt").ToArray();
            foreach (byte indx in dData)
            {
                Console.Write(indx);
                Console.Write("   ");
            }
            Console.WriteLine();

            var generatePassword = new RNGCryptoServiceProvider();
            byte[] ourPassword = new byte[dData.Length];
            generatePassword.GetBytes(ourPassword);
            foreach (byte indx in ourPassword)
            {
                Console.Write(indx);
                Console.Write("   ");
            }
            Console.WriteLine();
            Console.WriteLine();

            byte[] eData = new byte[dData.Length];
            for (int i = 0; i < dData.Length; i++)
            {
                eData[i] = (byte)(dData[i] ^ ourPassword[i]);
            }

            File.WriteAllBytes("encdata.dat", eData);

            byte[] ourText = File.ReadAllBytes("encdata.dat").ToArray();
            byte[] dText = new byte[ourText.Length];
            for (int indx = 0; indx < ourText.Length; indx++)
            {
                dText[indx] = (byte)(ourText[indx] ^ ourPassword[indx]);
            }

            Console.Write(Encoding.UTF8.GetString(dText));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}