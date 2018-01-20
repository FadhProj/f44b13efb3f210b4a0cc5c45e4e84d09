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
            /*
            string value;
            PropertyItem PI = originalImage.Image.PropertyItems[0];
            PI.Id = 0X320;
            PI.Type = 2;
            value = key;
            PI.Len = key.Length;
            PI.Value = new byte[PI.Len];
            for (int i = 0; i < value.Length; i++)
            {
                PI.Value[i] = Convert.ToByte(value[i]);
            }
            originalImage.Image.SetPropertyItem(PI);*/
            int c = ColorTranslator.ToWin32(originalImage.ValPadW[0]);
            Console.WriteLine( c );
            Console.WriteLine(ColorTranslator.FromWin32(c));

            int value;

            PropertyItem PI = OI.PropertyItems[0];
            PI.Id = 0X5011;
            PI.Type = 7;
            PI.Len = 10;
            PI.Value = new byte[PI.Len];
            OI.SetPropertyItem(PI);
            PI = OI.PropertyItems[0];
            OI.Save("D:\\as123da23.jpg");
            Console.WriteLine(PI.Id);
            Console.WriteLine(PI.Len);
            Console.WriteLine(PI.Type);



        }
    }
}
