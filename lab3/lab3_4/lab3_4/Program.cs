using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3_4
{
    class Program
    {

        static byte[] ComputeHashSHA256(byte[] dataForHash)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(dataForHash);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("To reg enter login and password.");
            Console.WriteLine("Login: ");
            string login = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Password: ");
            string password = Convert.ToBase64String(ComputeHashSHA256(Encoding.Unicode.GetBytes(Convert.ToString(Console.ReadLine()))));

            Console.WriteLine("Registration complete!");

            Console.WriteLine("To log in, please, enter your credentials:");
            Console.WriteLine("Login: ");
            string userLogin = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Password: ");
            string userPassword = Convert.ToBase64String(ComputeHashSHA256(Encoding.Unicode.GetBytes(Convert.ToString(Console.ReadLine()))));

            if (login != userLogin)
            {
                Console.WriteLine("Login is incorrect!");
            }
            else if (password != userPassword)
            {
                Console.WriteLine("Password is incorrect!");
            }
            else
            {
                Console.WriteLine("Ccomplete!");
            }

        }
    }
}