using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;


namespace hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            //opg 2
            int summen = 0;
            //opg 4            
            string pw = "Secret1234";
            string hashed;
            int compare = 3;
            int lengthtocompare = 2;
            int attempts = 0;
            //opg 5
            string linje;
            string hashfrompdf = "cff47fe5d92c58d654b08b2624bbb62aa5034530e3e5eff1f4a7186cba2e03fa";
            StreamReader stream = new StreamReader("rockyou-1000.txt");
            Stopwatch stopwatch = new Stopwatch();
            //opg 6
            Int64 sum = 0;
            //opg 8
            string bcrypthash = "$2b$14$eAmP5DGJsS1ekQ2C5CfgxOEM9JVvWAm991MInc/CMeMh7M470Kdri";
            bool verification = false;
            //opg 9
            string password9 = "mitfancypassword";

            //-----------------------------------------------------
            //opg 1;
            //Console.WriteLine("Hello World!");



            //opg2
            /*
            
            for (int i = 0; i < 100; i++)
            {
                summen = summen + i;
            }

            Console.WriteLine("Her er summen " + summen);
            */


            //opg 4
            /*

            hashed = ComputeSha256Hash(pw);

            
            Console.WriteLine("Her er pw: {0}, \n her er hashværdien: {1}", pw,hashed);
            // compare hvis s1 == s2 returnerer den 0, hvis s1>s2 returnerer den 1, hvis s1<s2 returnerer den -1

            while (compare != 0)
            {
                attempts = attempts + 1;
                string password = GetRandomPassword(10);
                string hashedpassword = ComputeSha256Hash(GetRandomPassword(10));
                Console.WriteLine("Tilfældigt password {0} \n og dets hashværdi {1} \n Dette er forsøg nr {2}", password, hashedpassword, attempts);
                compare = string.Compare(hashed.Substring(0, lengthtocompare), hashedpassword.Substring(0, lengthtocompare));
            }
            

            //opg 5 (+6)
            

            
            stopwatch.Start();
            while ((linje = stream.ReadLine()) != null)
            {
                string hash = ComputeSha256Hash(linje);
                Console.WriteLine("Dette er linjen: {0}, \n Dette er hashværdien: {1}",linje,hash);
                int compare2 = string.Compare(hashfrompdf, hash);
                if (compare2 == 0)
                {
                    Console.WriteLine("Den matchende streng er fundet, det er {0} \n {1} \n {2}",linje,hash,hashfrompdf);
                    stopwatch.Stop();
                    Console.WriteLine("Tid taget: {0} millisekunder", stopwatch.ElapsedMilliseconds);
                    break;
                }

            }

            //opg 6
     
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    sum = sum + i + j;
                }
            }
            stopwatch.Stop();
            Console.WriteLine(sum);
            Console.WriteLine("Tid taget: {0} sekunder", stopwatch.Elapsed.TotalSeconds);
            

            // opg 7
            stopwatch.Reset();
            stopwatch.Start();
            hashed = BCrypt.Net.BCrypt.HashPassword(pw, workFactor: 14);
            stopwatch.Stop();
            Console.WriteLine("Bcrypt hash af pw: {0}",hashed);
            Console.WriteLine("Tid taget: {0} sekunder", stopwatch.Elapsed.TotalSeconds);
            
            */
            // opg 8
            stopwatch.Reset();
            stopwatch.Start();
            while ((linje = stream.ReadLine()) != null)
            {
                verification = BCrypt.Net.BCrypt.Verify(linje, bcrypthash);
                if (verification == true)
                {
                    stopwatch.Stop();
                    Console.WriteLine("Det rigtige password er {0}, det tog {1} sekunder", linje,stopwatch.Elapsed.TotalSeconds);
                    break;
                }

            } 
            

            // opg 9
            /*
            password9 = Multihash(password9, 20);
            Console.WriteLine("Her er pw9 " + password9);
            Console.ReadLine();
            */
        }
        //metode til hashing

        static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }


        static string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static string Multihash(string pass, int iterations)
        {
            
            for (int i = 0; i < iterations; i++)
            {
                pass = ComputeSha256Hash(pass);
            }

            return pass;
        }
    }
}
