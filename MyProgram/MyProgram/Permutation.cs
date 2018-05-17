﻿using System;
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
        int p, a;
        BigInteger z, d;
        int toBig = 0;
        public Permutation(ref Iimage image)
        {
            p = primeNumber(image.Blok);
            for (int i = 0; i < image.Blok; i++)
            {
                z = BigInteger.Pow(5, (i + 69) % (p - 2));
                d = z % p;
                if (d < image.Blok)
                {
                    swapBlok(i, (int)d, ref image);
                }
                //MessageBox.Show(string.Format("blok {0} from {1} ", i, image.Blok));
                
            }

        }
        public Permutation(ref Iimage image, bool t)
        {
            p = primeNumber(image.Blok);
            for (int i = image.Blok - 1; i >= 0; i--)
            {
                z = BigInteger.Pow(5, (i + 69) % (p - 2));
                d = z % p;
                if (d < image.Blok)
                {
                    swapBlok(i, (int)d, ref image);
                }


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

        public int primeNumber(int number)
        {
            for (int i = number; i > 0; i--)
            {
                if (this.isPrime(i))
                {
                    return i;
                }
            }
            return 0; //????
        }

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
    }
}
