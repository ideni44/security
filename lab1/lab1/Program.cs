using System;
using System.Security.Cryptography;


namespace lab1
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0,4}", rnd.Next(-100, 100));
            Console.WriteLine("next");

            Random rnd1 = new Random();
            for (int i = 0; i < 10; i++)
                Console.WriteLine("{0,4}", rnd.Next(-100, 100));
            Console.WriteLine("next");
            for (int i = 0; i < 4; i++);
                string textWithRnd = Convert.ToBase64String(CryptoRnd());
                Console.WriteLine(textWithRnd);
        }
        static byte[] CryptoRnd(int length = 10)
        {
            var rndNum = new byte[length];
            var rndGen = new RNGCryptoServiceProvider();
            rndGen.GetBytes(rndNum);
            return rndNum;
        }
    }
}