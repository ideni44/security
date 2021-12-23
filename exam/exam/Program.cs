using System;
using System.Security.Cryptography;

namespace Project
{
    class Task
    {
        static void Main(string[] args)
        {
           
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            
            byte[] nums = new byte[15];
            
            rng.GetBytes(nums);
            
            for (int i = 0; i < nums.Length; i++)
            {
                
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }
    }
}