using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;

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
            int G = 2;
            while(!check)
            {
                Console.Write("{0} adalah ",G);
                check = checkGNumber(factor,G,prime);
                if(check)
                    Console.WriteLine("Generator Number");
                else
                    Console.WriteLine("Bukan Generator Number");
                G++;
            }
            //bool check = checkGNumber(factor,G,prime);
            
                
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
