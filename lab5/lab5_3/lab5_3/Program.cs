using System;
using System.Security.Cryptography;
using System.Text;

namespace lab5_3
{
    public class SaltedHash
    {
        public static byte[] GenerateSalt()
        {
            const int saltLen = 32;

            using (var ranNumGen = new RNGCryptoServiceProvider())
            {
                var randomNum = new byte[saltLen];
                ranNumGen.GetBytes(randomNum);
                return randomNum;
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var rett = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, rett, 0, first.Length);
            Buffer.BlockCopy(second, 0, rett, first.Length, second.Length);
            return rett;
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Combine(toBeHashed, salt));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string pass = "KCML2015_2021as";
            byte[] salt = SaltedHash.GenerateSalt();
            Console.WriteLine("Pass - " + pass);
            Console.WriteLine("Salt - " + Convert.ToBase64String(salt));
            Console.WriteLine();
            var hashedPassword1 = SaltedHash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(pass), salt);
            Console.WriteLine("Hashed Password - " + Convert.ToBase64String(hashedPassword1));
            Console.ReadLine();
        }
    }
}