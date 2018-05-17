using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace MyProgram
{
    public partial class Form1 : Form
    {
        DateTime date;
        Save ss;
        Metadata met;
        byte[] cek, cek1;
        string L;
        string K;
        List<int> ke1, ke2;
        public Form1()
        {
            InitializeComponent();
            date = DateTime.Now;
            tbDate.Text = date.ToString();
            int[] a = { 1, 2, 3, 4, 5 };
            string s = a.ToString();
            ss = new Save(date);
        }
        //================================================================================================================
        //  GrayScale
        //================================================================================================================
        // Mengubah gambar menjadi warna Grayscale

        public Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int average = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    bm.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }

            return bm;
        }

        Thread th;
        //================================================================================================================
        //  Encryption Process
        //================================================================================================================
        private void btChooseEI_Click(object sender, EventArgs e)
        {
            string key = null;
            bool embeded = false;

            /* Create variable OI ( Original Image ) */
            Bitmap OI = null;
            tbDate.Text = date.ToString();

            /* Get Key from input user */
            /* or From metadata */


            key = tbKey.Text;

            if (key != "")
            {
                /* Open file dialog and get image from computer */
                OpenFileDialog open = new OpenFileDialog
                {

                    Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
                };

               
                
                if (open.ShowDialog() == DialogResult.OK)
                {
                    
                    pbEI.Image = new Bitmap(open.FileName);
                    OI = (Bitmap)pbEI.Image;
                    try
                    {
                        //get from metadata                       
                        string K = Encoding.UTF8.GetString(pbEI.Image.GetPropertyItem(800).Value);
                        embeded = true;
                        K = K.Substring(0, K.Length - 1);
                        key = K;
                    }
                    catch
                    {
                        /* Convert image to Grayscale */
                        Console.WriteLine("Convert to Grayscale on Process");
                        OI = ConvertToGrayscale(OI);
                        ss.saveImage(OI, "1. GrayscaleImage");
                        ss.saveTxt("detail","Key : " + key.ToString());
                    }



                    /* initialitation PropertyItem from Image */
                    Metadata meta = new Metadata(pbEI.Image.PropertyItems);


                    /* Encryption Image */
                    Iimage originalImage = new Iimage(OI);
                    if (embeded)
                    {
                        byte[] B = pbEI.Image.GetPropertyItem(305).Value;
                        byte[] M = pbEI.Image.GetPropertyItem(33432).Value;
                        originalImage.addPadding(B, M);
                    }
                    else
                        originalImage.addPadding();

                    /* 1. Stream Encryption Using RC4 */
                    Console.WriteLine("Stream Encryption on Process");
                    StreamChipper oStream = new StreamChipper(key);
                    oStream.PRGA(ref originalImage);
                    ss.saveImage(originalImage.Image, "1.1 StreamImage");

                    /* 2. Permutation Block Image */
                    Console.WriteLine("Permutation Block Image on Process");
                    Permutation pr = new Permutation(ref originalImage);

                    /* Close Padding */
                    originalImage.closePadding(true);

                    /* Embending Key to Metadata */
                    Bitmap img = originalImage.Image;
                    meta.embedKeyStream(key, ref img);
                    if (embeded)
                    {
                        meta.embedKeyStream(Encoding.UTF8.GetString(OI.GetPropertyItem(800).Value), ref img);
                        meta.embedLMap(Encoding.UTF8.GetString(OI.GetPropertyItem(315).Value), ref img);
                        meta.embedPadding(originalImage.ValPadW, originalImage.ValPadH, ref img);
                    }
                    else
                        meta.embedPadding(originalImage.ValPadW, originalImage.ValPadH, ref img);

                    /* Save Image */
                    ss.saveImage(img, "1.2 EncryptedImage");
                    /* show */
                    pbEI.Image = originalImage.Image;

                }

            }
            else
                MessageBox.Show("Key can't be EMPTY", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);





        }






        //================================================================================================================
        //  embeding  proccess
        //================================================================================================================
        private void btOpenEMM_Click(object sender, EventArgs e)
        {

            tbDate.Text = date.ToString();

            /* Create variable EI ( Encryption Image ) */
            Bitmap EI = null;

            /* Open file dialog and get image from computer */
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEMM.Image = new Bitmap(open.FileName);
                EI = (Bitmap)pbEMM.Image;

                /* initialitation PropertyItem from Image */
                Metadata meta = new Metadata(pbEMM.Image.PropertyItems);
                byte[] B, M;
                ss.saveImage((Bitmap)pbEMM.Image, "2. EncryptedImageBefEmbed");
                Iimage shifftingImage = new Iimage(EI);

                try
                {
                    B = pbEMM.Image.GetPropertyItem(305).Value;
                    M = pbEMM.Image.GetPropertyItem(33432).Value;

                    /* Add Padding */
                    Console.WriteLine("Histogram Shiffting on Process");
                    //    Iimage shifftingImage = new Iimage(EI);
                    shifftingImage.addPadding(B, M);
                }
                catch
                {
                    Console.WriteLine("Histogram Shiffting on Process");
                    //  Iimage shifftingImage = new Iimage(EI);
                    shifftingImage.addPadding();
                }

                /* Shiffting process */
                Embeding em = new Embeding(ref shifftingImage);

                /* Embending L Map to Metadata */
                Bitmap imageS = shifftingImage.Image;
                Console.WriteLine("=============================================");

                /* Save Shiffted Image */
                ss.saveImage(shifftingImage.Image, "21 ShifftedImage");
                //pbEMM.Image = shifftingImage.Image;

                /* get Message from User input */
                string[] allLines = rtbEMM.Text.Split('\n');
                string msg = rtbEMM.Text;

                /* Get Metadata */

                /* Embeding Message */
                Console.WriteLine("Embeding message on Process");
                if (tbStart.Text == "")
                    em.Start = 0;
                else
                    em.Start = Convert.ToInt16(tbStart.Text);
                em.embed(ref shifftingImage, msg);
                //em.embed1X2(ref shifftingImage, msg);
                tbMax.Text = em.Max.ToString();
                ss.saveTxt("detail", "Max : " + em.Max.ToString()+" bit");
                ss.saveTxt("detail", "Message : " + em.LenMsg.ToString() + " bit");

                /* Close Padding */
                shifftingImage.closePadding(true);

                /* Embending Padding to Metadata */
                Bitmap img = shifftingImage.Image;
                byte[] mapL = Encoding.UTF8.GetBytes(em.L1 + " ");
                try
                {
                    meta.embedKeyStream(Encoding.UTF8.GetString(EI.GetPropertyItem(800).Value), ref img);
                    meta.embedLMap(em.L1, ref img);
                    meta.embedPadding(shifftingImage.ValPadW, shifftingImage.ValPadH, ref img);
                }
                catch
                {
                    meta.embedLMap(em.L1, ref img);
                    meta.embedPadding(shifftingImage.ValPadW, shifftingImage.ValPadH, ref img);
                }


                /* Save Image */
                ss.saveImage(img, "3. EmbendedImage");


            }

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

                /* get Metadata */
                Metadata meta = new Metadata(pbDI.Image.PropertyItems);


                //get from metadata                
                K = Encoding.UTF7.GetString(pbDI.Image.GetPropertyItem(800).Value);
                K = K.Substring(0, K.Length - 1);


                ss.saveImage(EMI, "4. ImageBefDecrypted");
                Iimage encryptedMarkedImage = new Iimage(EMI);

                /* Add Padding */
                encryptedMarkedImage.addPadding(pbDI.Image.GetPropertyItem(305).Value, pbDI.Image.GetPropertyItem(33432).Value);


                Permutation pr = new Permutation(ref encryptedMarkedImage, true);

                StreamChipper sc = new StreamChipper(K);
                sc.PRGA(ref encryptedMarkedImage);

                /*close Padding*/
                encryptedMarkedImage.closePadding(true);



                /*embed Padding */
                Bitmap img = encryptedMarkedImage.Image;

                try
                {
                    meta.embedKeyStream(Encoding.UTF8.GetString(EMI.GetPropertyItem(800).Value), ref img);
                    meta.embedLMap(Encoding.UTF8.GetString(EMI.GetPropertyItem(315).Value), ref img);
                    meta.embedPadding(encryptedMarkedImage.ValPadW, encryptedMarkedImage.ValPadH, ref img);
                }
                catch
                {
                    //meta.embedLMap(Encoding.UTF8.GetString(EMI.GetPropertyItem(315).Value), ref img);
                    meta.embedPadding(encryptedMarkedImage.ValPadW, encryptedMarkedImage.ValPadH, ref img);
                }

             
                /* Show */
                pbDI.Image = img;
                ss.saveImage(img, "DecryptedImage");
            }
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

                /*get Metadata */
                Metadata meta = new Metadata(pbEM.Image.PropertyItems);

                string massage = "";
                Iimage markedImage = new Iimage(EMI);
                /* Add Padding */
                markedImage.addPadding(pbEM.Image.GetPropertyItem(305).Value, pbEM.Image.GetPropertyItem(33432).Value);

                //====================================
                L = Encoding.UTF8.GetString(pbEM.Image.GetPropertyItem(315).Value);
                L = L.Substring(0, L.Length - 1);
                //Console.WriteLine("");
                Extraction ex = new Extraction(ref markedImage, L, ref massage);
                Console.WriteLine(massage);
                Console.WriteLine(massage.Trim(new Char[] { '?', '*', '.' }));
                rtbEM.Text = massage;

                /* Close Padding */
                markedImage.closePadding(true);

                /* embed Padding */
                Bitmap img = markedImage.Image;
                try
                {
                    meta.embedKeyStream(pbEM.Image.GetPropertyItem(800).Value, ref img);
                    meta.embedPadding(markedImage.ValPadW, markedImage.ValPadH, ref img);
                }
                catch
                {
                    meta.embedPadding(markedImage.ValPadW, markedImage.ValPadH, ref img);

                }
                //img.RemovePropertyItem(800);
                ss.saveImage(img, "5. ShifftedImageAfExtraction");
            }
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
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbMeta.Image = new Bitmap(open.FileName);
                OI = (Bitmap)pbMeta.Image;


                rtbMeta.Text = "";
                PropertyItem[] PI = OI.PropertyItems;
                foreach (var item in PI)
                {
                    char c = ' '; string s = " ";
                    rtbMeta.AppendText("Id = " + item.Id.ToString() + " Len =  " + item.Len.ToString() + " Type = " + item.Type.ToString() + " " + Environment.NewLine);
                    for (int I = 0; I < item.Value.Length; I++)
                    {
                        if (item.Type != 2)
                        {
                            s += System.Convert.ToString(item.Value[I], 16).ToUpper() + " ";
                        }
                    }

                    if (item.Type == 2)
                    {
                        rtbMeta.AppendText("type 2 " + Encoding.UTF8.GetString(item.Value) + Environment.NewLine);
                        foreach (var mm in item.Value)
                        {
                            Console.Write(mm + " - ");
                        }
                    }
                    else
                    {
                        rtbMeta.AppendText(s + Environment.NewLine);
                    }
                    rtbMeta.AppendText(Environment.NewLine);


                }
            }


        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            int R1, G1, B1, R2, G2, B2, valImage1, valImage2, same = 0, diff = 0, min1 = 0, satu = 0, nol = 0;
            Bitmap image1 = null, image2 = null;

            OpenFileDialog open = new OpenFileDialog();

            open.Multiselect = true;
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";

            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string s = "";
                string[] files = open.FileNames;
                Bitmap a;
                image1 = new Bitmap(files[0]);
                image2 = new Bitmap(files[1]);

                pbOI.Image = image1; tbH1.Text = image1.Height.ToString(); tbW1.Text = image1.Width.ToString();
                pbNI.Image = image2; tbH2.Text = image2.Height.ToString(); tbW2.Text = image2.Width.ToString();
                double D = MSE(image1, image2);
                tbMSE.Text = D.ToString();
                tbPSNR.Text = PSNR(D).ToString();

            }
        }



        private double MSE(Bitmap OI, Bitmap NI)
        {
            /* MSE = [1 / ( W x H )] x  E E [ I - K ]^2 */
            int W = OI.Width, H = NI.Height;
            double I, K, tmp = 0;

            for (int j = 0; j < H - 1; j++)
            {
                for (int i = 0; i < W - 1; i++)
                {
                    I = (double)(OI.GetPixel(i, j).R + OI.GetPixel(i, j).G + OI.GetPixel(i, j).B) / 3;
                    K = (double)(NI.GetPixel(i, j).R + NI.GetPixel(i, j).G + NI.GetPixel(i, j).B) / 3;
                    tmp += System.Math.Pow(I - K, 2);
                }
            }

            return (1.0 / (W * H)) * tmp;
        }

       

        private double PSNR(double MSE)
        {

            //return 20 * System.Math.Log10(System.Math.Pow(255,2)) - 10 * System.Math.Log10(MSE);
            return 10 * System.Math.Log10(Math.Pow(255, 2) / MSE);
        }

        private void btDate_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            ss = new Save(date);

            pbDI.Image = null;
            pbEI.Image = null;
            pbEM.Image = null;
            pbEMM.Image = null;
            pbMeta.Image = null;
            pbOI.Image = null;
            pbNI.Image = null;
            rtbEM.Text = "";
            rtbEMM.Text = "";
            rtbMeta.Text = "";

            tbKey.Text = "";
            tbMax.Text = "";
            tbStart.Text = "";



        }


    }
}

