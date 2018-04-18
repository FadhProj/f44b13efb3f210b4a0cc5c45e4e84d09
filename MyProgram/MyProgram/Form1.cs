using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;



namespace MyProgram
{
    public partial class Form1 : Form
    {
        DateTime date;
        Save ss;

        Iimage shifftingImage;
        string L;
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
            ss = new Save(date);
            Console.Write("");
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

        //================================================================================================================
        //  Encryption Process
        //================================================================================================================
        private void btChooseEI_Click(object sender, EventArgs e)
        {
            /* Create variable OI ( Original Image ) */
            Bitmap OI = null;

            tbDate.Text = date.ToString();

            /* Get Key from input user */
            string key = tbKey.Text; 
            
            if (key != null)
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

                    /* Convert image to Grayscale */
                    Console.WriteLine("Convert to Grayscale on Process");
                    OI = ConvertToGrayscale(OI);
                    ss.saveImage(OI, "1. GrayscaleImage.png");

                    /* initialitation PropertyItem from Image */
                    Metadata meta = new Metadata(pbEI.Image.PropertyItems); 

                    
                    /* Encryption Image */
                    Iimage originalImage = new Iimage(OI);
                    originalImage.addPadding();
                    
                    /* 1. Stream Encryption Using RC4 */
                    Console.WriteLine("Stream Encryption on Process");
                    StreamChipper oStream = new StreamChipper(key);
                    oStream.PRGA(ref originalImage);
                    ss.saveImage(originalImage.Image, "1.1 StreamImage.png");

                    /* 2. Permutation Block Image */
                    Console.WriteLine("Permutation Block Image on Process");
                    Permutation pr = new Permutation(ref originalImage);

                    /* Close Padding */
                    originalImage.closePadding(true);
                    
                    /* Embending Key to Metadata */
                    Bitmap img = originalImage.Image;
                    meta.embedKeyStream(key, ref img);
                    meta.embedPadding(originalImage.ValPadW, originalImage.ValPadH,ref img);
                    
                    /* Save Image */
                    ss.saveImage(img, "1.2 EncryptedImage.png");

                    /* show */

                }

            }
            else
                MessageBox.Show("Key can't be EMPTY");

           



        }

        

        //================================================================================================================
        //  histogram Shiffting proccess
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
                ss.saveImage(EI, "2. EncryptedImageBefEmbed.png");
                
                /* initialitation PropertyItem from Image */
                Metadata meta = new Metadata(pbEMM.Image.PropertyItems);

                /* Add Padding */
                Console.WriteLine("Histogram Shiffting on Process");
                shifftingImage = new Iimage(EI);
                shifftingImage.addPadding(pbEMM.Image.GetPropertyItem(305).Value,pbEMM.Image.GetPropertyItem(33432).Value);

                /* Shiffting process */
                Embeding em = new Embeding(ref shifftingImage);

                /* Embending L Map to Metadata */
                Bitmap image = shifftingImage.Image;
                meta.embedLMap(em.L1, ref image);

                /* Save Shiffted Image */
                pbEMM.Image = shifftingImage.Image;
                ss.saveImage(image, "2.1 ShifftedImage.png");

                foreach (var item in em.L1)
                {
                    Console.Write(item);
                }
            }

        }

        

        //================================================================================================================
        //  Embeding Message Process
        //================================================================================================================
        private void btEmbed_Click(object sender, EventArgs e)
        {
            
            /* get Message from User input */
            string[] allLines = rtbEMM.Text.Split('\n');
            string msg = rtbEMM.Text;
            shifftingImage = new Iimage(shifftingImage.Image);//(Bitmap)pbEMM.Image);

            /* Get Metadata */
            Metadata meta = new Metadata(pbEMM.Image.PropertyItems);

            /* Embeding Message */
            Console.WriteLine("Embeding message on Process");
            Embeding em = new Embeding(ref shifftingImage, msg);

            /* Close Padding */
            shifftingImage.closePadding(true);

            /* Embending Key to Metadata */
            Bitmap img = shifftingImage.Image;
            meta.embedPadding(shifftingImage.ValPadW, shifftingImage.ValPadH,ref img);
            

            /* Save Image */
            ss.saveImage(img, "3. EmbendedImage.png");


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
                K = Encoding.UTF7.GetString( pbDI.Image.GetPropertyItem(315).Value);
                K = K.Substring(0, K.Length - 1);
                Console.WriteLine(K);


                ss.saveImage(EMI, "4. ImageBefDecrypted.png");
                Iimage encryptedMarkedImage = new Iimage(EMI);

                /* Add Padding */
                Console.WriteLine();
                Console.WriteLine("Add Padding");
                Console.WriteLine();
                encryptedMarkedImage.addPadding(pbDI.Image.GetPropertyItem(305).Value, pbDI.Image.GetPropertyItem(33432).Value);

                /*for (int y = 0; y < test.Height; y++)
                {
                    for (int x = 0; x < test.Width; x++)
                    {
                        if (test.GetPixel(x, y) != encryptedMarkedImage.Image.GetPixel(x, y))
                        {
                            Console.WriteLine("tes {0} {1}", test.GetPixel(x, y), encryptedMarkedImage.Image.GetPixel(x, y));
                        }
                    }
                }*/

                Permutation pr = new Permutation(ref encryptedMarkedImage, true);
                
                StreamChipper sc = new StreamChipper(K);
                sc.PRGA(ref encryptedMarkedImage);

                /*close Padding*/
                Console.WriteLine();
                Console.WriteLine("Close Padding");
                Console.WriteLine();
                encryptedMarkedImage.closePadding(true);

                /*embed Padding */
                Bitmap img = encryptedMarkedImage.Image;
                meta.embedPadding(encryptedMarkedImage.ValPadW, encryptedMarkedImage.ValPadH, ref img);

                /* Show */
                pbDI.Image = img;
                ss.saveImage(img, "DecryptedImage.png");
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
                L = Encoding.UTF8.GetString(pbEM.Image.GetPropertyItem(800).Value);
                L = L.Substring(0, L.Length - 1);
                Extraction ex = new Extraction(ref markedImage, L, ref massage);
                rtbEM.Text = massage;

                /* Close Padding */
                markedImage.closePadding(true);

                /* embed Padding */
                Bitmap img = markedImage.Image;
                meta.embedPadding(markedImage.ValPadW, markedImage.ValPadH, ref img);

                ss.saveImage(img, "5. ShifftedImageAfExtraction.png");
            }
        }
        //================================================================================================================
        //  Shift back
        //================================================================================================================
        /*private void btDecryp_Click(object sender, EventArgs e)
        {
            Bitmap SI = null;

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png"
            };
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEM.Image = new Bitmap(open.FileName);
                SI = (Bitmap)pbEM.Image;

                //get from metadata
                L = Encoding.UTF7.GetString(pbEM.Image.GetPropertyItem(800).Value);
                L = K.Substring(0, L.Length - 1);
                Console.WriteLine(L);

                /*ss.saveImage(EXI, "ImageBefDecrypted.png");
                Iimage extractionImage = new Iimage(EXI);

                ss.saveImage(EXI, "ExtractionImage.png");

                Permutation pr = new Permutation(ref extractionImage, true);
                StreamChipper sc = new StreamChipper(K);
                sc.PRGA(ref extractionImage);
                ke2 = sc.Ke;


                
                ss.saveImage(extractionImage.Image, "RecoverImage.png");
            }
        }*/

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
                        Console.Write(mm+" - ");
                    }
                    Console.WriteLine("tes");
                }
                else
                {
                    rtbMeta.AppendText(s + Environment.NewLine);
                }
                rtbMeta.AppendText(Environment.NewLine);


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
            int R1, G1, B1, R2, G2, B2, valImage1, valImage2, same = 0, diff = 0, min1 = 0, satu = 0, nol = 0;
            Bitmap image1=null , image2 = null;

            OpenFileDialog open = new OpenFileDialog();

            open.Multiselect = true;
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                string s="";
                string[] files = open.FileNames;
                //Console.WriteLine(files.Length);
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
                        //Console.WriteLine("{0} {1} ", image1.GetPixel(x - 1, y - 1), image1.GetPixel(x, y));
                        //Console.WriteLine("{0} {1} ", image2.GetPixel(x - 1, y - 1), image2.GetPixel(x, y));
                        //Console.WriteLine("=================================================================");
                        if (valImage1 == valImage2)
                        {
                            if (valImage1 == 0)
                                nol += 1;
                            else if (valImage1 == -1)
                                min1 += 1;
                            else if (valImage1 == 1)
                                satu += 1;
                            same += 1;
                        }
                        else
                            diff += 1;
                    }
                    //Console.WriteLine("");
                }
                rtbCC.Text = "Sama : " + same + Environment.NewLine + "Beda : " + diff + Environment.NewLine + "0 : " + nol + Environment.NewLine + "1 : " + satu + Environment.NewLine + "-1 : " + min1;
            }
        }

        private void btDate_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            ss = new Save(date);
        }

        
    }
}
