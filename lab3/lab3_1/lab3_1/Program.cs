using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3_1
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

        public static byte[] ComputeHashSha1(byte[] toBeHashed)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(toBeHashed);
            }
        }

        public static byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public static byte[] ComputeHashSha384(byte[] toBeHashed)
        {
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(toBeHashed);
            }
        }

        public static byte[] ComputeHashSha512(byte[] toBeHashed)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(toBeHashed);
            }
        }


        static void Main(string[] args)
        {
            const string strForHashFirst = "Hi World!";
            const string strForHashSecond = "How are you?";
            const string strForHashThird = "I am fine";

            var md5ForStrFirst = ComputeHashMd5(Encoding.Unicode.GetBytes(strForHashFirst));
            var md5ForStrSecond = ComputeHashMd5(Encoding.Unicode.GetBytes(strForHashSecond));
            var md5ForStrThird = ComputeHashMd5(Encoding.Unicode.GetBytes(strForHashThird));

            Guid guidForMD_First = new Guid(md5ForStrFirst),
            guidForMD_Second = new Guid(md5ForStrSecond),
            guidForMD_Third = new Guid(md5ForStrThird);


            Console.WriteLine("MD5:");
            Console.WriteLine(strForHashFirst);
            Console.WriteLine(strForHashSecond);
            Console.WriteLine(strForHashThird);
            Console.WriteLine(Convert.ToBase64String(md5ForStrFirst));
            Console.WriteLine(Convert.ToBase64String(md5ForStrSecond));
            Console.WriteLine(Convert.ToBase64String(md5ForStrThird));


            var sha1ForStrFirst = ComputeHashSha1(Encoding.Unicode.GetBytes(strForHashFirst));
            var sha1ForStrSecond = ComputeHashSha1(Encoding.Unicode.GetBytes(strForHashSecond));
            var sha1ForStrThird = ComputeHashSha1(Encoding.Unicode.GetBytes(strForHashThird));


            Console.WriteLine("SHA1:");
            Console.WriteLine(strForHashFirst);
            Console.WriteLine(strForHashSecond);
            Console.WriteLine(strForHashThird);
            Console.WriteLine(Convert.ToBase64String(sha1ForStrFirst));
            Console.WriteLine(Convert.ToBase64String(sha1ForStrSecond));
            Console.WriteLine(Convert.ToBase64String(sha1ForStrThird));

            var sha256ForStrFirst = ComputeHashSha256(Encoding.Unicode.GetBytes(strForHashFirst));
            var sha256ForStrSecond = ComputeHashSha256(Encoding.Unicode.GetBytes(strForHashSecond));
            var sha256ForStrThird = ComputeHashSha256(Encoding.Unicode.GetBytes(strForHashThird));

            Console.WriteLine("SHA256:");
            Console.WriteLine(strForHashFirst);
            Console.WriteLine(strForHashSecond);
            Console.WriteLine(strForHashThird);
            Console.WriteLine(Convert.ToBase64String(sha256ForStrFirst));
            Console.WriteLine(Convert.ToBase64String(sha256ForStrSecond));
            Console.WriteLine(Convert.ToBase64String(sha256ForStrThird));

            var sha384ForStrFirst = ComputeHashSha384(Encoding.Unicode.GetBytes(strForHashFirst));
            var sha384ForStrSecond = ComputeHashSha384(Encoding.Unicode.GetBytes(strForHashSecond));
            var sha384ForStrThird = ComputeHashSha384(Encoding.Unicode.GetBytes(strForHashThird));

            Console.WriteLine("SHA384:");
            Console.WriteLine(strForHashFirst);
            Console.WriteLine(strForHashSecond);
            Console.WriteLine(strForHashThird);
            Console.WriteLine(Convert.ToBase64String(sha384ForStrFirst));
            Console.WriteLine(Convert.ToBase64String(sha384ForStrSecond));
            Console.WriteLine(Convert.ToBase64String(sha384ForStrThird));

            var sha512ForStrFirst = ComputeHashSha512(Encoding.Unicode.GetBytes(strForHashFirst));
            var sha512ForStrSecond = ComputeHashSha512(Encoding.Unicode.GetBytes(strForHashSecond));
            var sha512ForStrThird = ComputeHashSha512(Encoding.Unicode.GetBytes(strForHashThird));

            Console.WriteLine("SHA512:");
            Console.WriteLine(strForHashFirst);
            Console.WriteLine(strForHashSecond);
            Console.WriteLine(strForHashThird);
            Console.WriteLine(Convert.ToBase64String(sha512ForStrFirst));
            Console.WriteLine(Convert.ToBase64String(sha512ForStrSecond));
            Console.WriteLine(Convert.ToBase64String(sha512ForStrThird));

        }
    }
}