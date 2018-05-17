using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyProgram
{
    class Save
    {
        string path;
        string path2;


        public Save(DateTime date)
        {
            //Directory.SetCurrentDirectory(@"E:\0TugasAkhir\Program\4281b5f1517561be4b655b48abecfb1d\TA");
            Path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", Path);
            Path = System.IO.Path.Combine(Path, "Hasil", date.ToString("MMM. dd, yyyy H-mm-ss"));
            try
            {
                if (Directory.Exists(Path))
                {
                    Console.WriteLine("That path exists already.");

                }
                else
                {
                    // Try to create the directory.
                    Directory.CreateDirectory(Path);
                    path2 = path;
                    //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(Path));
                }
            }
            catch (Exception ee)
            {

                Console.WriteLine("The process create folder hasil failed: {0}", ee.ToString());
            }

            //Console.WriteLine("The current directory is {0}", Path);
        }

        public string Path { get => path; set => path = value; }

        public void saveImage(Bitmap img, string fileName)
        {
            // Use Combine again to add the file name to the path.
            //path = System.IO.Path.Combine(path, fileName);
            // Verify the path that you have constructed.
            //Console.WriteLine("Path to my file: {0}\n", System.IO.Path.Combine(path, fileName));
            try
            {
                //check if not exist
                int i = 1;
                if (!File.Exists(System.IO.Path.Combine(path, fileName + ".png")))
                {
                    img.Save(System.IO.Path.Combine(path, fileName + ".png"), ImageFormat.Png);
                }
                else
                {
                    while (File.Exists(System.IO.Path.Combine(path, fileName + i.ToString() + ".png")))
                    {
                        i++;
                    }
                    img.Save(System.IO.Path.Combine(path, fileName +i.ToString() + ".png"), ImageFormat.Png);
                }
            }
            catch (Exception ee)
            {

                Console.WriteLine("The process failed: {0}", ee.ToString());
            }
        }

        public void saveTxt(string fileName,string item)
        {
            // Use Combine again to add the file name to the path.
            //path = System.IO.Path.Combine(path, fileName);
            // Verify the path that you have constructed.
            //Console.WriteLine("Path to my file: {0}\n", System.IO.Path.Combine(path, fileName));
            try
            {
                //check if not exist
                //if (!File.Exists(System.IO.Path.Combine(path2, fileName + ".txt")))
                //{
                //    File.CreateText(System.IO.Path.Combine(path2, fileName + ".txt"));
                //}
                //string var="\n";
                File.AppendAllText(System.IO.Path.Combine(path2, fileName + ".txt"), item + Environment.NewLine);
            }
            catch (Exception ee)
            {

                Console.WriteLine("The process failed: {0}", ee.ToString());
            }
        }



    }
}
