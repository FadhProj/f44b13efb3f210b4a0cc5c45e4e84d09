﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Text;
using System.IO;


namespace MyProgram
{
    public partial class Form1 : Form
    {
        DateTime date;
        Save ss;
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

        private void btChooseEI_Click(object sender, EventArgs e)
        {
            Bitmap OI = null;
            string key =  tbKey.Text;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            date = DateTime.Now;
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbEI.Image = new Bitmap(open.FileName);
                //ext = open.DefaultExt;
                OI = (Bitmap)pbEI.Image;
            }

            Iimage originalImage = new Iimage(OI);
            StreamChipper oStream = new StreamChipper(key);

            originalImage.addPadding(false);
            oStream.PRGA(ref originalImage);

            originalImage.closePadding(true);

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
            Console.WriteLine(pi.Type);



        }

        private void btMeta_Click(object sender, EventArgs e)
        {
            Bitmap OI = null;
            //RichTextBox rb = new RichTextBox();
            //rtbMeta.AppendText("asdasda" + Environment.NewLine);
            //rtbMeta.AppendText("asdasdads" + Environment.NewLine);
            
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Image Files(*.jpg;*.bmp;*.jpeg;*.png)|*.jpg;*.bmp;*.jpeg;*.png";
            date = DateTime.Now;
            tbDate.Text = date.ToString();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pbMeta.Image = new Bitmap(open.FileName);
                //ext = open.DefaultExt;
                OI = (Bitmap)pbMeta.Image;
            }

           
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
    }
}
