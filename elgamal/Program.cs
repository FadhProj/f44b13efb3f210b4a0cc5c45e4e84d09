using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;
using System.IO;

namespace elgamal
{
    class Program
    {
        public static bool isPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                //Console.Write(i + " ");
                if(num % i == 0)
                    return false;
            }
            return true;
        }
        public static int primeNumber(int num)
        {
            for (int i = num; i < num + 200; i++)
            {
                //Console.Write(i + " : " );
                if(isPrime(i))
                    return i;
                //Console.WriteLine();
            }
            return -1;
        }

        // Return the number's prime factors.
        private static List<long> FindFactors(long num)
        {
            List<long> result = new List<long>();
            // Take out the 2s.
            while (num % 2 == 0)
            {
                result.Add(2);
                num /= 2;
            }
            // Take out other primes.
            long factor = 3;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    // This is a factor.
                    result.Add(factor);
                    num /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }
            // If num is not 1, then whatever is left is prime.
            if (num > 1) result.Add(num);

            return result;
        }
        
        public static bool checkGNumber(List<long> factor,int G,int P)
        {
            int freq = 1;
            for (int i = 0; i < factor.Count; i++)
            {
                if (i != 0 && (factor[i]==factor[i-1]))
                {
                    freq++;
                } else
                {
                    freq = 1;
                }
                int O = P-1, qi = (int)(Math.Pow(factor[i],freq));
                //Console.WriteLine(O +" "+ qi);
                int w = (int)Math.Pow(G,(O/qi)) % P;
                //Console.WriteLine("{0} ^ {1}/{2} mod {3} = {4}",G,O,qi,P,w);
                if( w == 1)
                    return false;

            }
            return true;
        }

        static Random _r = new Random();
        static void F(int numm)
        {
            int n = _r.Next(numm);
            // Can return 0, 1, 2, 3, or 4
            Console.WriteLine(n);
        }
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            


            Console.Write("Input number : ");
            int number = System.Convert.ToInt32(Console.ReadLine());
            watch.Start();
            int prime = primeNumber(number);            

            Console.WriteLine("First Prime Number : " + Convert.ToString(prime));
            Console.Write("Factor {0} : ",prime);
            List<long> factor = FindFactors(prime-1);
            foreach (var item in factor)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            //Console.Write("Input G : ");
            //int G = System.Convert.ToInt32(Console.ReadLine());
            
            bool check = false;
            int G = 2, i = 0;
            while(i<10)
            {
                Console.Write("{0} adalah ",G);
                check = checkGNumber(factor,G,prime);
                if(check)
                    Console.WriteLine("Generator Number");
                else
                    Console.WriteLine("Bukan Generator Number");
                G++;i++;
            }
            //bool check = checkGNumber(factor,G,prime);
            
                
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            F(number);
            F(number);
            F(number);
            F(number);
            F(number);
            F(number);

            Console.WriteLine();
            // ... Create new Random object.
            Random a = new Random();
            // ... Get three random numbers.
            //     Always 5, 6, 7, 8 or 9.
            string s = "{ ";
            for (int j = 0; j < 116964; j++)
            {
                      s += a.Next(0, 116964).ToString() + ", ";
                      Console.WriteLine(j+" ");
                     
            }

            s += "} ";
            //Console.WriteLine(s);
            File.AppendAllText(System.IO.Path.Combine(Directory.GetCurrentDirectory(),"key.txt"),s );
        }
    }
}
