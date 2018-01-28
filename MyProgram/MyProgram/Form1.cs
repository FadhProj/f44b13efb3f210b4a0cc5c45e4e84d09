using System;
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
            //originalImage.Image.Save("D:\\55555.jpg");
            /*
            string value;
            PropertyItem PI = originalImage.Image.PropertyItems[0];
            PI.Id = 0X320;
            PI.Type = 2;
            value = key;
            PI.Len = key.Length;
            PI. x `````````````````````````
            for (int i = 0; i < value.Length; i++)
            {
                PI.Value[i] = Convert.ToByte(value[i]);
            }
            originalImage.Image.SetPropertyItem(PI);*/
            int c = ColorTranslator.ToWin32(originalImage.ValPadW[0]);
            Console.WriteLine( c );
            Console.WriteLine(ColorTranslator.FromWin32(c));


            int value;
            
            //originalImage.Image.Save("D:\\QWEQWEQ123123.jpg");
            OI = new Bitmap("D:\\test.jpg");
            PropertyItem[] PI = OI.PropertyItems;
            foreach (var item in PI)
            {
                Console.WriteLine("Id = " + item.Id.ToString() + " Len =  " + item.Len.ToString() + " Type = " + item.Type.ToString() + " ");
                for (int I = 0; I < item.Value.Length; I++)
                {
                    if (item.Type == 2)
                    {
                        Console.Write((char)(item.Value[I]));
                    }
                    else
                    {
                        Console.Write(System.Convert.ToString(item.Value[I], 16).ToUpper() + " ");
                    }
                }
                Console.WriteLine();
            }
            /*PropertyItem pi = OI.PropertyItems[0];
            pi.Id = 0X5034;
            pi.Type = 2;
            pi.Len = 10;
            pi.Value = new byte[pi.Len];
            OI.SetPropertyItem(pi);
            pi = OI.PropertyItems[0];
            pi.Id = 0X5038;
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
