using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MyProgram
{
    class Embeding
    {
        private ArrayList L;

        public ArrayList L1 { get => L; }

        public Embeding(ref Iimage img, string msg)
        {
            L = new ArrayList();
            histShiffting(ref img);
            embed(ref img, msg);
        }

        public string tobin(string inp)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in inp.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();

        }

        public void histShiffting(ref Iimage img)
        {
            int R, G, B;
            for (int y = 0; y < img.Image.Height; y++)
            {
                for (int x = 0; x < img.Image.Width; x++)
                {
                    R = img.Image.GetPixel(x, y).R;
                    G = img.Image.GetPixel(x, y).G;
                    B = img.Image.GetPixel(x, y).B;
                    if (R == 0)
                    {
                        L.Add(1);
                        img.Image.SetPixel(x, y, Color.FromArgb(R + 1, G + 1, B + 1));
                    }
                    else if (R == 255)
                    {
                        L.Add(1);
                        img.Image.SetPixel(x, y, Color.FromArgb(R - 1, G - 1, B - 1));
                    }
                    else if (R == 1 || R == 254)
                    {
                        L.Add(0);
                    }
                }
            }
        }

        public void embed(ref Iimage img, string msg)
        {
            int b = 0, diff, R, G, B, n = 0;
            int valM, valN, Cbi, Cb1;
            string binMsg = tobin(msg);
            for (int blok = 0; blok < img.Blok; blok++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        valM = img.DefBlok[blok].M;
                        valN = img.DefBlok[blok].N;
                        R = img.Image.GetPixel(valM + j, valN + i).R;
                        G = img.Image.GetPixel(valM + j, valN + i).G;
                        B = img.Image.GetPixel(valM + j, valN + i).B;
                        Cbi = (R + G + B) / 3;
                        Cb1 = (img.Image.GetPixel(valM, valN).R + img.Image.GetPixel(valM, valN).G + img.Image.GetPixel(valM, valN).B) / 3;
                        diff = Cbi - Cb1;

                        if (n != binMsg.Length)
                            b = binMsg[n] - 48;
                        if (!(i == 0 && j == 0))
                        {
                            if (diff < -1)
                            {
                                R -= 1; G -= 1; B -= 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                            else if (diff == -1)
                            {
                                if (n < binMsg.Length)
                                {
                                    R -= b; G -= b; B -= b;
                                    img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                                    n++;
                                }
                            }
                            else if (diff == 0)
                            {
                                if (n < binMsg.Length)
                                {
                                    R += b; G += b; B += b;
                                    img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                                    n++;
                                }
                            }
                            else if (diff > 0)
                            {
                                R += 1; G += 1; B += 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                        }
                    }
                }
            }
           
            Console.WriteLine(binMsg);

        }
    }
}
