﻿using System;
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

        public void embedPadding(int[] valPadW, int[] valPadH, ref Bitmap image)
        {
            byte[] byteW = new byte[valPadW.Length ];
            byte[] byteH = new byte[valPadH.Length ];
            byte[] bytePadding = new byte[valPadH.Length + valPadW.Length + 1];
            byte[] mapPadding = new byte[valPadH.Length + valPadW.Length + 2];
            byte[] mapW = new byte[valPadW.Length ];
            byte[] mapH = new byte[valPadH.Length ];
            

            /* Convert from int[] to byte[] */
            int i = 0;
            Console.WriteLine("len val {0} len byte W {1} "+valPadW.Length + " " + byteW.Length);
            Console.Write("val byte W : ");
            foreach (var val in valPadW) 
            {
                if (val == 0)
                {
                    byteW[i] = Convert.ToByte((val + 1).ToString());
                    mapW[i] = Convert.ToByte(1);                    
                }
                else
                {
                    byteW[i] = Convert.ToByte(val.ToString());
                    mapW[i] = Convert.ToByte(2);
                }
                Console.Write(val + " - ");
                i++;
            }
            Console.WriteLine();      
            Console.WriteLine("len val {0} len byte H {1} "+valPadH.Length + " " + byteH.Length);
            i = 0;
            Console.Write("val byte H : ");
            foreach (var val in valPadH)
            {
                if (val == 0)
                {
                    byteH[i] = Convert.ToByte((val + 1).ToString());
                    mapH[i] = Convert.ToByte(1);
                }
                else
                {
                    byteH[i] = Convert.ToByte(val.ToString());
                    mapH[i] = Convert.ToByte(2);
                }
                Console.Write(val + " - ");
                i++;
            }
            Console.WriteLine();
           
           

            

            //==============================================================
            byteW.CopyTo(bytePadding, 0);
            byteH.CopyTo(bytePadding, byteW.Length);
            Console.Write("val byte bytePadding : ");
            foreach (var val in bytePadding)
            {
                Console.Write(val + " - ");
            }
            Console.WriteLine();

            //===============================================================
            mapW.CopyTo(mapPadding, 0);
            mapPadding[mapW.Length] = 3;
            mapH.CopyTo(mapPadding, mapW.Length + 1);

            PropertyItem itemm = PI[0];
            Console.WriteLine("Encoding : ");
            //string sTmp = itemD + " ";
            var itemData = bytePadding;
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 305; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            Console.WriteLine(itemData.Length + " " + itemm.Len);
            itemm.Value = itemData; // The byte array
            image.SetPropertyItem(itemm); // Assign / add to the bitmap


            itemm = PI[0];
            Console.WriteLine("Encoding : ");
            //string sTmp = itemD + " ";
             itemData = mapPadding;
            itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
            itemm.Type = 2; //String (ASCII)
            itemm.Id = 33432; // Author(s), 315 is mapped to the "Authors" field
            itemm.Len = itemData.Length; // Number of items in the byte array
            Console.WriteLine(itemData.Length + " " + itemm.Len);
            itemm.Value = mapPadding; // The byte array
            image.SetPropertyItem(itemm); // Assign / add to the bitmap


        }


    }
}
