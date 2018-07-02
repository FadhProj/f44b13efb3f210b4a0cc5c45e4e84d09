using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Numerics;
using System.Windows.Forms;


namespace MyProgram
{
    class Permutation
    {
        
        int toBig = 0;

        int P, G;
        BigInteger Yi;
        List<int> factor;

        public Permutation(ref Iimage image)
        {
            factor = new List<int>();
            P = primeNumber(image.Blok);
            FindFactors(P-1);

            Console.WriteLine("Width : {0} Height : {1} blok : {2}", image.Image.Width, image.Image.Height,image.Blok);

            G = gNumber();
            Console.WriteLine(G);
            for (int i = 0; i < image.Blok; i++)
            {
                Yi = (BigInteger.Pow(G,i)) % P;
                Console.WriteLine("{0}      {1}" ,i,Yi);
                if (Yi < image.Blok)
                {
                    swapBlok(i, (int)Yi, ref image);
                }
                //MessageBox.Show(string.Format("blok {0} from {1} ", i, image.Blok));

            }

        }

        public Permutation(ref Iimage image, bool t)
        {
            factor = new List<int>();
            P = primeNumber(image.Blok);
            FindFactors(P - 1);

            G = gNumber();
            for (int i = image.Blok - 1; i >= 0; i--)
            {
                Yi = (BigInteger.Pow(G, i)) % P;
                if (Yi < image.Blok)
                {
                    swapBlok(i, (int)Yi, ref image);
                }


            }
        }

        public Permutation(ref Iimage image, int[] key)
        {
            for (int i = 0; i < image.Blok; i++)
            {
                Console.WriteLine("{0} {1}", i, key[i % key.Length]);
                swapBlok(i, key[i % key.Length], ref image);
            }
        }

        public Permutation(ref Iimage image, int[] key, bool t)
        {
            for (int i = image.Blok; i >= 0 ; i--)
            {
                Console.WriteLine("{0} {1}", i, key[i % key.Length]);
                swapBlok(i, key[i % key.Length], ref image);
            }
        }



        public void swapBlok(int blok1, int blok2, ref Iimage image)
        {
            Color tmp;

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 0);
            image.Image.SetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 0, image.Image.GetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 0));
            image.Image.SetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 0, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 1);
            image.Image.SetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 1, image.Image.GetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 1));
            image.Image.SetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 1, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 2);
            image.Image.SetPixel(image.DefBlok[blok1].M + 0, image.DefBlok[blok1].N + 2, image.Image.GetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 2));
            image.Image.SetPixel(image.DefBlok[blok2].M + 0, image.DefBlok[blok2].N + 2, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 1);
            image.Image.SetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 1, image.Image.GetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 1));
            image.Image.SetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 1, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 0);
            image.Image.SetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 0, image.Image.GetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 0));
            image.Image.SetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 0, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 2);
            image.Image.SetPixel(image.DefBlok[blok1].M + 1, image.DefBlok[blok1].N + 2, image.Image.GetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 2));
            image.Image.SetPixel(image.DefBlok[blok2].M + 1, image.DefBlok[blok2].N + 2, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 0);
            image.Image.SetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 0, image.Image.GetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 0));
            image.Image.SetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 0, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 1);
            image.Image.SetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 1, image.Image.GetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 1));
            image.Image.SetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 1, tmp);

            tmp = image.Image.GetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 2);
            image.Image.SetPixel(image.DefBlok[blok1].M + 2, image.DefBlok[blok1].N + 2, image.Image.GetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 2));
            image.Image.SetPixel(image.DefBlok[blok2].M + 2, image.DefBlok[blok2].N + 2, tmp);

        }

        //Get Prime Number
        public int primeNumber(int number)
        {
            for (int i = number; i > 0; i++)
            {
                if (this.isPrime(i))
                {
                    return i;
                }
            }
            return -1; //????
        }

        //Check Is prime
        public bool isPrime(int number)
        {
            for (int i = 2; i < (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Return the number's prime factors.
        private void FindFactors(int num)
        {
            //List<int> result = new List<int>();
            // Take out the 2s.
            while (num % 2 == 0)
            {
                factor.Add(2);
                num /= 2;
            }
            // Take out other primes.
            int fac = 3;
            while (fac * fac <= num)
            {
                if (num % fac == 0)
                {
                    // This is a factor.
                    factor.Add(fac);
                    num /= fac;
                }
                else
                {
                    // Go to the next odd number.
                    fac += 2;
                }
            }
            // If num is not 1, then whatever is left is prime.
            if (num > 1) factor.Add(num);

            //factor = result;
        }

        //Get G number
        public int gNumber()
        {
            bool check = false;
            int G = 3;
            while (!check)
            {
                //Console.Write("{0} adalah ", G);
                check = checkGNumber();
                G++;
            }
            return G - 1;
        }

        //Checl G number for some prime number
        public bool checkGNumber()
        {
            int freq = 1;
            for (int i = 0; i < factor.Count; i++)
            {
                if (i != 0 && (factor[i] == factor[i - 1]))
                {
                    freq++;
                }
                else
                {
                    freq = 1;
                }
                int O = P - 1, qi = (int)(Math.Pow(factor[i], freq));
                int w = (int)Math.Pow(G, (O / qi)) % P;
                if (w == 1)
                    return false;

            }
            return true;
        }
    }
}
