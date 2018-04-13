using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram
{
    class Metadata
    {
        PropertyItem[] PI;

        public Metadata(PropertyItem[] pi)
        {
            PI = pi ;
        }

        public void embedKeyStream(string key,ref Bitmap image)
        {
            PropertyItem itemm = PI[0];
            string sTmp = key+" ";
            var itemData = System.Text.Encoding.UTF8.GetBytes(sTmp);
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            Console.WriteLine(itemData);
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 315; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            itemm.Value = itemData; // The byte array
            image.SetPropertyItem(itemm); // Assign / add to the bitmap
        }

        public void embedLMap(string itemD, ref Bitmap image)
        {
            PropertyItem itemm = PI[0];
            Console.WriteLine(itemD);
            string sTmp = itemD + " ";
            var itemData = System.Text.Encoding.UTF8.GetBytes(sTmp);
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            Console.WriteLine(itemData.Length);
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 800; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            itemm.Value = itemData; // The byte array
            image.SetPropertyItem(itemm); // Assign / add to the bitmap
            /*Console.WriteLine(itemData);
            foreach (var item in itemData)
            {
                Console.Write(item);

            }*/
           
        }

        public void embedPadding(int[] valPadW, int[] valPadH)//, ref Bitmap image)
        {
            byte[] byteW = new byte[valPadW.Length + 1];
            byte[] byteH = new byte[valPadH.Length + 1];
            /* Convert from int[] to byte[] */
            int i = 0;
            Console.WriteLine(valPadW.Length + " " + byteW.Length);
            foreach (var val in valPadW) 
            {
               
                byteW[i] = BitConverter.GetBytes(val);
                Console.Write(val + " - ");
                i++;
            }
            Console.WriteLine();
            foreach (var val in valPadH)
            {
                byteH = BitConverter.GetBytes(val);
            }

            foreach (var val in byteW)
            {
                Console.Write(val + " || ");
            }
            Console.WriteLine();


            PropertyItem itemm = PI[0];
            Console.WriteLine("Encoding : " + Encoding.UTF8.GetString(byteW));
            /*string sTmp = itemD + " ";
            var itemData = System.Text.Encoding.UTF8.GetBytes(sTmp);
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            Console.WriteLine(itemData.Length);
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 800; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            itemm.Value = itemData; // The byte array
            image.SetPropertyItem(itemm); // Assign / add to the bitmap
              */                            

        }


    }
}
