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
    class Extraction
    {
        private string L;

        public Extraction(ref Iimage img, string L, ref string msg)
        {
            this.L = L;
            extrac(ref img, ref msg);
            //extrac1X2(ref img, ref msg);

            histShiffting(ref img);
        }

        public string L1 { get => L; set => L = value; }

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
                    int pixelValue = (R + G + B) / 3;
                    int n = 0;
                    if (pixelValue == 254 && L[n].Equals("1"))
                    {
                        img.Image.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        n++;
                    }
                    else if (pixelValue == 1 && L[n].Equals("1"))
                    {
                        img.Image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        n++;
                    }
                    else if ((pixelValue == 1) || (pixelValue == 254))
                    {
                        n++;
                    }
                }
            }
        }
       

        public string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length - (data.Length % 8); i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public void extrac(ref Iimage img, ref string msg)
        {
            int diff, R, G, B, n = 0;
            int valM, valN, Cbi, Cb1;
            string binMsg = "";
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

                        if (!(i == 0 && j == 0))
                        {
                            if (diff == 0 || diff == -1)
                            {
                                binMsg += "0";
                            }
                            else if (diff == 1 || diff == -2)
                            {
                                binMsg += "1";
                            }
                           


                            if (diff > 0)
                            {
                                R -= 1; G -= 1; B -= 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                            else if (diff < -1)
                            {
                                R += 1; G += 1; B += 1;
                                img.Image.SetPixel(valM + j, valN + i, Color.FromArgb(R, G, B));
                            }
                        }
                    }
                }
            }
            binMsg = binMsg.Substring(binMsg.IndexOf("11111111") + 8);
            msg = BinaryToString(binMsg);


        }

        public void extrac1X2(ref Iimage img, ref string msg)
        {
            int diff, R, G, B, n = 0;
            int valM, valN, Cbi, Cb1;
            string binMsg = "";

            for (int i = 0; i < img.Image.Height - 1; i++)
            {
                for (int j = 0; j < img.Image.Width - 1; j += 2)
                {

                    R = img.Image.GetPixel(1 + j, i).R;
                    G = img.Image.GetPixel(1 + j, i).G;
                    B = img.Image.GetPixel(1 + j, i).B;
                    Cbi = (R + G + B) / 3;
                    Cb1 = (img.Image.GetPixel(j, i).R + img.Image.GetPixel(j, i).G + img.Image.GetPixel(j, i).B) / 3;
                    diff = Cbi - Cb1;


                    if (diff == 0 || diff == -1)
                    {
                        binMsg += "0";
                    }
                    else if (diff == 1 || diff == -2)
                    {
                        binMsg += "1";
                    }
                   


                    if (diff > 0)
                    {
                        R -= 1; G -= 1; B -= 1;
                        img.Image.SetPixel(1 + j, i, Color.FromArgb(R, G, B));
                    }
                    else if (diff < -1)
                    {
                        R += 1; G += 1; B += 1;
                        img.Image.SetPixel(1 + j, i, Color.FromArgb(R, G, B));
                    }

                }
            }

            binMsg = binMsg.Substring(binMsg.IndexOf("11111111") + 8);
            msg = BinaryToString(binMsg);


        }
    }
}
