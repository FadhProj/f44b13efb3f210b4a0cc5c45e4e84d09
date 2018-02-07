using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace MyProgram
{
    public partial class Form1 : Form
    {
        DateTime date;
        Save ss;

        Iimage shifftingImage;
        ArrayList L;
        string K;
        List<int> ke1, ke2;
        Bitmap test;
        public Form1()
        {
            InitializeComponent();
            date = DateTime.Now;
            tbDate.Text = date.ToString();
            int[] a = { 1, 2, 3, 4, 5 };
            string s = a.ToString();
            Console.WriteLine(s);
            ss = new Save(date);
        }

        //================================================================================================================
        //  Encryption Process
        //================================================================================================================
        private void btChooseEI_Click(object sender, EventArgs e)
        {
            Bitmap OI = null;
          
                string key = tbKey.Text;
            K = key;
            try
            {
                if (key == null)
                    throw new ArgumentNullException();
            }
            catch (Exception)
            {

                MessageBox.Show("Key Can't be NULL");
            }



            OpenFileDialog open = new OpenFileDialog
            {

                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            //date = DateTime.Now;
            tbDate.Text = date.ToString();
            OI = NewMethod(OI, open);

            //Save s = new Save(date);
            ss.saveImage(OI, "OriginalImage.png");

            Iimage originalImage = new Iimage(OI);
            StreamChipper oStream = new StreamChipper(key);

            originalImage.addPadding(false);
            ss.saveImage(originalImage.Image, "OriginalImage2.png");
            oStream.PRGA(ref originalImage);
            ss.saveImage(originalImage.Image, "StreamImage.png");
            Permutation pr = new Permutation(ref originalImage);

            ke1 = oStream.Ke;
            test = new Bitmap(originalImage.Image);
            ss.saveImage(originalImage.Image, "EncryptedImage.png");
           
            

            //originalImage.closePadding(true);

           /* 
            PropertyItem pi = OI.PropertyItems[0];
            pi.Id = 0X320;
            pi.Type = 2;
            pi.Len = key.Length + originalImage.ValPadW.Length + originalImage.ValPadW.Length + 3 ;
            pi.Value = new byte[pi.Len];

            int i;
            for (i = 0 ; i < key.Length; i++)
            {
                pi.Value[i] = Convert.ToByte(key[i]);
            }
            pi.Value[i] = Convert.ToByte(null);
            i++;
            for (int k = 0; k < pi.Value.Length; k++)
            {
                Console.Write(pi.Value[k] + " ");
            }
            Console.WriteLine("");
            //Console.WriteLine(pi.Value);
            int j = 0 ;
            for (j = i; j < originalImage.ValPadW.Length ; j++)
            {
                pi.Value[j] = Convert.ToByte(originalImage.ValPadW[j]);
            }
            i = j ;
            pi.Value[i] = Convert.ToByte(null);
            i++;
            for (int k = 0; k < pi.Value.Length; k++)
            {
                Console.Write(pi.Value[k] + " ");
            }
            Console.WriteLine("");
            for (int k = i; k < originalImage.ValPadH.Length; k++)
            {
                pi.Value[k] = Convert.ToByte(originalImage.ValPadH[k]);
            }

            for (int k = 0; k < pi.Value.Length; k++)
            {
                Console.Write(pi.Value[k] + " ");
            }
            originalImage.Image.SetPropertyItem(pi);
            //pi = originalImage.Image.PropertyItems[0];
            //pi.Id = 0X321;
           // pi.Type = 2;
            //pi.Len = 10;
            //pi.Value = new byte[pi.Len];
            //originalImage.Image.SetPropertyItem(pi);
            originalImage.Image.Save("E:\\" + date.ToString("MMM. dd, yyyy H-mm-ss") + ".jpg");
            //OI.Save("D:\\678678.jpg");
            Console.WriteLine(pi.Id);
            Console.WriteLine(pi.Len);
            Console.WriteLine(pi.Type);*/



        }

        private Bitmap NewMethod(Bitmap OI, OpenFileDialog open)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEI.Image = new Bitmap(open.FileName);
                //ext = open.DefaultExt;
                OI = (Bitmap)pbEI.Image;
            }

            return OI;
        }

        //================================================================================================================
        //  histogram Shiffting proccess
        //================================================================================================================

        private void btOpenEMM_Click(object sender, EventArgs e)
        {
            Bitmap EI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            //date = DateTime.Now;
            tbDate.Text = date.ToString();
            EI = openImage(EI, open);

            //Save s = new Save(date);
            ss.saveImage(EI, "EncryptedImageBefEmbed.png");

            shifftingImage = new Iimage(EI);

           

            Embeding em = new Embeding(ref shifftingImage);
            L = em.L1;
            pbEMM.Image = shifftingImage.Image;
            ss.saveImage(shifftingImage.Image, "ShifftedImage.png");
            

        }

        private Bitmap openImage(Bitmap Image, OpenFileDialog open)
        {
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEMM.Image = new Bitmap(open.FileName);
                //ext = open.DefaultExt;
                Image = (Bitmap)pbEMM.Image;
            }

            return Image;
        }

        //================================================================================================================
        //  Embeding Message Process
        //================================================================================================================
        private void btEmbed_Click(object sender, EventArgs e)
        {
            Console.WriteLine(string.Join("\n",rtbEMM.Text.Split('\n')));
            string[] allLines = rtbEMM.Text.Split('\n');
            foreach (var item in allLines)
            {
                Console.WriteLine(item);
            }

            string msg = rtbEMM.Text;
            shifftingImage = new Iimage(shifftingImage.Image);//(Bitmap)pbEMM.Image);

            Embeding em = new Embeding(ref shifftingImage, msg);
            //TESTING
            //L = em.L1;

            ss.saveImage(shifftingImage.Image, "EmbendedImage.png");


        }

        //================================================================================================================
        //  Decryption Image;
        //================================================================================================================
        private void btChooseDI_Click(object sender, EventArgs e)
        {
            Bitmap EMI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbDI.Image = new Bitmap(open.FileName);
                EMI = (Bitmap)pbDI.Image;
            }

            ss.saveImage(EMI, "ImageBefDecrypted.png");
            Iimage encryptedMarkedImage = new Iimage(EMI);
            for (int y = 0; y < test.Height; y++)
            {
                for (int x = 0; x < test.Width; x++)
                {
                    if (test.GetPixel(x,y) != encryptedMarkedImage.Image.GetPixel(x,y))
                    {
                        Console.WriteLine("tes {0} {1}", test.GetPixel(x, y), encryptedMarkedImage.Image.GetPixel(x, y));
                    }
                }
            }

            Permutation pr = new Permutation(ref encryptedMarkedImage,true);
            StreamChipper sc = new StreamChipper(K);
            sc.PRGA(ref encryptedMarkedImage);
            ke2 = sc.Ke;

            

            ss.saveImage(encryptedMarkedImage.Image, "DecryptedImage.png");
        }

        //================================================================================================================
        //  Extract Message
        //================================================================================================================
        private void btExtract_Click(object sender, EventArgs e)
        {
            Bitmap EMI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEM.Image = new Bitmap(open.FileName);
                EMI = (Bitmap)pbEM.Image;
            }
            string massage = "";
            Iimage markedImage = new Iimage(EMI);
            Extraction ex = new Extraction(ref markedImage, L, ref massage);
            rtbEM.Text = massage;

            ss.saveImage(markedImage.Image, "EncryptedImageAfExtraction.png");

        }
        //================================================================================================================
        //  Decrypt Image After Extraction
        //================================================================================================================
        private void btDecryp_Click(object sender, EventArgs e)
        {
            Bitmap EXI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEM.Image = new Bitmap(open.FileName);
                EXI = (Bitmap)pbEM.Image;
            }

            ss.saveImage(EXI, "ImageBefDecrypted.png");
            Iimage extractionImage = new Iimage(EXI);

            ss.saveImage(EXI, "ExtractionImage.png");

            Permutation pr = new Permutation(ref extractionImage, true);
            StreamChipper sc = new StreamChipper(K);
            sc.PRGA(ref extractionImage);
            ke2 = sc.Ke;



            ss.saveImage(extractionImage.Image, "RecoverImage.png");
        }

        //================================================================================================================
        //  Read MetaData
        //================================================================================================================
        private void btMeta_Click(object sender, EventArgs e)
        {
            Bitmap OI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            //date = DateTime.Now;
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbMeta.Image = new Bitmap(open.FileName);
                //ext = open.DefaultExt;
                OI = (Bitmap)pbMeta.Image;
            }

            rtbMeta.Text = "";
            PropertyItem[] PI = OI.PropertyItems;
            foreach (var item in PI)
            {
                char c = ' ' ; string s = " ";
                rtbMeta.AppendText("Id = " + item.Id.ToString() + " Len =  " + item.Len.ToString() + " Type = " + item.Type.ToString() + " " +Environment.NewLine);
                for (int I = 0; I < item.Value.Length; I++)
                {
                    if (item.Type == 2)
                    {
                        c += (char)(item.Value[I]);
                    }
                    else
                    {
                        s += System.Convert.ToString(item.Value[I], 16).ToUpper() + " ";
                    }
                }
                
                if (item.Type == 2)
                    rtbMeta.AppendText("type 2" + Environment.NewLine);
                else
                {
                    rtbMeta.AppendText(s + Environment.NewLine);
                }

                
            }
            /*PropertyItem pi = OI.PropertyItems[0];
            pi.Id = 0X320;
            pi.Type = 2;
            pi.Len = 10;
            pi.Value = new byte[pi.Len];
            OI.SetPropertyItem(pi);
            pi = OI.PropertyItems[0];
            pi.Id = 0X321;
            pi.Type = 2;
            pi.Len = 10;
            pi.Value = new byte[pi.Len];
            OI.SetPropertyItem(pi);
            OI.Save("D:\\test.jpg");
            Console.WriteLine(pi.Id);
            Console.WriteLine(pi.Len);
            Console.WriteLine(pi.Type);*/

        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            int R1, G1, B1, R2, G2, B2, valImage1, valImage2, same = 0, diff = 0;
            Bitmap image1=null , image2 = null;

            OpenFileDialog open = new OpenFileDialog();

            open.Multiselect = true;
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string s="";
                string[] files = open.FileNames;
                Console.WriteLine(files.Length);
                Bitmap a;
                image1 = new Bitmap(files[0]);
                image2 = new Bitmap(files[1]);

                pbCC1.Image = image1;
                pbCC2.Image = image2;
                if (image1.Width < image2.Width)
                {
                    a = image1;
                }
                else
                    a = image2;
                for (int y = 1; y < a.Height; y++)
                {
                    for (int x = 1; x < a.Width; x++)
                    {
                        valImage1 = ((image1.GetPixel(x - 1, y - 1).R + image1.GetPixel(x - 1, y - 1).B + image1.GetPixel(x - 1, y - 1).B) / 3) - ((image1.GetPixel(x, y).R + image1.GetPixel(x, y).B + image1.GetPixel(x, y).B) / 3);
                        valImage2 = ((image2.GetPixel(x - 1, y - 1).R + image2.GetPixel(x - 1, y - 1).B + image2.GetPixel(x - 1, y - 1).B) / 3) - ((image2.GetPixel(x, y).R + image2.GetPixel(x, y).B + image2.GetPixel(x, y).B) / 3);
                        Console.WriteLine("{0} {1} {2} {3} ",x,y, valImage1, valImage2);
                        if (valImage1 == valImage2)
                            same += 1;
                        else
                            diff += 1;
                    }
                    //Console.WriteLine("");
                }
                rtbCC.Text = "Sama : " + same + Environment.NewLine + "Beda : " + diff;
            }
        }

        private void btDate_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            ss = new Save(date);
        }

        
    }
}
