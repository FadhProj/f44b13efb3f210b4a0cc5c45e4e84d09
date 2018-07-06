using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;

namespace MyProgram
{
    class Iimage
    {
        public struct Pos
        {
            int m;
            int n;

            public Pos(int m, int n)
            {
                this.m = m;
                this.n = n;
            }

            public int M { get => m; set => m = value; }
            public int N { get => n; set => n = value; }
        }

        private Bitmap image;
        private int blok;
        private Pos[] defBlok;
        List<Pos> def;
        private int nPadW, nPadH;
        private int[] valPadW, valPadH;

        public Bitmap Image { get => image; }
        public int Blok { get => blok; }
        internal Pos[] DefBlok { get => defBlok; }
        public int PadW { get => nPadW; set => nPadW = value; }
        public int PadH { get => nPadH; set => nPadH = value; }
        public int[] ValPadW { get => valPadW; set => valPadW = value; }
        public int[] ValPadH { get => valPadH; set => valPadH = value; }

        public Iimage(Bitmap image)
        {
            this.image = image;
            def = new List<Pos>();
            setDefBlok(this.image);


        }


        public void setDefBlok(Bitmap image)
        {

            int b = 0;
            for (int i = 0; i < image.Height; i += 3)
            {
                for (int j = 0; j < image.Width; j += 3)
                {
                    def.Add(new Pos(j, i));
                    b++;

                }
            }
            blok = b;
            defBlok = def.ToArray();

        }

        public void addPadding()
        {
            int x = image.Width, y = image.Height;
            if (image.Width % 3 != 0 && image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
                y = image.Height + nPadH;
            }
            else if (image.Width % 3 != 0)
            {
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
            }
            else if (image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                y = image.Height + nPadH;
            }
            if (image.Width % 3 != 0 || image.Height % 3 != 0)
            {
                Bitmap result = new Bitmap(x, y);
                using (Graphics graph = Graphics.FromImage(result))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, x, y);
                    graph.FillRectangle(Brushes.Black, ImageSize);
                }
                for (int i = 0; i < image.Height; i++)
                {
                    for (int j = 0; j < image.Width; j++)
                    {
                        result.SetPixel(j, i, image.GetPixel(j, i));
                    }
                }
                this.image = result;
            }
            
            setDefBlok(this.image);
        }

        public void addPadding(byte[] B,byte[] M)
        {
            int x = image.Width, y = image.Height;
            if (image.Width % 3 != 0 && image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
                y = image.Height + nPadH;
            }
            else if (image.Width % 3 != 0)
            {
                this.nPadW = 3 - (image.Width % 3);
                x = image.Width + nPadW;
            }
            else if (image.Height % 3 != 0)
            {
                this.nPadH = 3 - (image.Height % 3);
                y = image.Height + nPadH;
            }
            if (image.Width % 3 != 0 || image.Height % 3 != 0)
            {
                Bitmap result = new Bitmap(x, y);
                using (Graphics graph = Graphics.FromImage(result))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, x, y);
                    graph.FillRectangle(Brushes.Black, ImageSize);
                }
                for (int i = 0; i < image.Height; i++)
                {
                    for (int j = 0; j < image.Width; j++)
                    {
                        result.SetPixel(j, i, image.GetPixel(j, i));
                    }
                }
                this.image = result;
            }
            
            int split=0;
            for (int j = 0; j < M.Length-1; j++)
            {
                if (M[j] == 3)
                    split = j;
            }

          
            this.valPadW = new int[split];
            this.valPadH = new int[M.Length - split - 1];
            for (int i = 0; i < split; i++)
            {
                int z = B[i];
                if (M[i] == 1)
                {
                    ValPadW[i] = z - 1;
                }
                else
                    ValPadW[i] = z;
                
            }
            int l = 0;

            for (int i = split; i < B.Length - 1; i++)
            {
                int z = B[i];
                if (M[i+1] == 1)
                    valPadH[l] = z - 1;
                else
                    valPadH[l] = z;
                l++;
            }

            copyToImage();
            
            setDefBlok(this.image);
        }

        public void copyToArray()
        {
            int w = 0, h = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = image.Width - nPadW; x < image.Width; x++)
                {
                    valPadW[w] = image.GetPixel(x, y).R;
                    //valPadW[w+1] = image.GetPixel(x, y).G;
                    //valPadW[w+2] = image.GetPixel(x, y).B;
                    w+=1;
                    //w += 3;
                }

                if (y >= image.Height - nPadH)
                {

                    for (int x = 0; x < image.Width; x++)
                    {
                        valPadH[h] = image.GetPixel(x, y).R;
                        //valPadH[h+1] = image.GetPixel(x, y).G;
                        //valPadH[h+2] = image.GetPixel(x, y).B;
                        h+=1;
                        //h += 3;

                    }
                }
            }
        }

        public void copyToImage()
        {
            int w = 0, h = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = image.Width - nPadW; x < image.Width; x++)
                {
                    image.SetPixel(x, y, Color.FromArgb(valPadW[w], valPadW[w], valPadW[w]));
                    w+=1;
                    //w += 3;

                }
                if (y >= image.Height - nPadH)
                {
                    
                    for (int x = 0; x < image.Width; x++)
                    {
                        image.SetPixel(x, y, Color.FromArgb(valPadH[h], valPadH[h], valPadH[h]));
                        h+=1;
                       // h += 3;

                    }
                }
            }
        }

        public void closePadding(bool e)
        {
            if (e)
            {
                this.valPadW = new int[PadW * image.Height];// * 3 ];
                this.valPadH = new int[PadH * image.Width];// * 3 ];

                copyToArray();
            }

            Bitmap result = new Bitmap(image.Width - nPadW, image.Height - nPadH);
            using (Graphics graph = Graphics.FromImage(result))
            {
                Rectangle ImageSize = new Rectangle(0, 0, result.Width, result.Height);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }

            for (int i = 0; i < result.Height; i++)
            {
                for (int j = 0; j < result.Width; j++)
                {
                    result.SetPixel(j, i, image.GetPixel(j, i));
                }
            }
            this.image = result;

        }
    }
}
