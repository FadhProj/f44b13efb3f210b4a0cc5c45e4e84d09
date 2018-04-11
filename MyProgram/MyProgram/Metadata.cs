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

        public void embedLMap(byte[] itemD, ref Bitmap image)
        {
            PropertyItem itemm = PI[0];
            //string sTmp = key + " ";
            var itemData = itemD;
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            /*Console.WriteLine(itemData);
            foreach (var item in itemData)
            {
                Console.Write(item);

            }*/
            Console.WriteLine();
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 800; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            itemm.Value = itemData; // The byte array
            foreach (var item in itemm.Value)
            {
                Console.Write(item);

            }
            Console.WriteLine();
            Console.WriteLine(itemData.Length + " - " + itemm.Len);
            image.SetPropertyItem(itemm); // Assign / add to the bitmap
        }


    }
}
