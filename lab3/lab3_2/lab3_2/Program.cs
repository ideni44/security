﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3_2
{
    class Program
    {
        static byte[] ComputeHashMd5(byte[] dataForHash)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(dataForHash);
            }

        }
        static void Main(string[] args)
        {
            Guid guid = new Guid("564c8da6-0440-88ec-d453-0bbad57c6036");
            string a = "po1MVkAE7IjUUwu61XxgNg==";
            string Hash;
            for (int i = 99999; i >= 0; i--)
            {
                string password = i.ToString();
                for (int qq = password.Length; qq < 6; qq++)
                {
                    password = "0" + password;
                }
                Hash = Convert.ToBase64String(ComputeHashMd5(Encoding.Unicode.GetBytes(password)));
                if (Hash == a)
                {
                    Console.WriteLine(Hash);
                    Console.WriteLine(password);
                    break;
                }
                Console.WriteLine(password);
            }

        }
    }
}