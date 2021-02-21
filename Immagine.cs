﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    class Immagine : PictureBox
    {
        public Immagine()
        {
            Image = null;
        }
        public bool leggiImmagineDaFile(string path)
        {
            bool res = false;
            PropertyItem propItem4 = null;
            try
            {
                if (File.Exists(path))
                {
                    // Image = (Bitmap)System.Drawing.Image.FromFile(path);
                    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    //Image myImage = Image.FromStream(stream);
                    //creo il bitmap dallo stream
                    //System.Drawing.Image bmpStream = System.Drawing.Image.FromStream(stream);
                    //creo un nuovo bitmap ridimensionandolo
                    // Bitmap img = new Bitmap(bmpStream, new Size(Width, Height));
                    Image = Image.FromStream(stream);
                    res = true;
                    try
                    {
                        propItem4 = Image.GetPropertyItem(0x112);
                        switch (propItem4.Value[0])
                        {
                            case 0: break;
                            case 6:
                                Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                                Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                                break;
                            case 8:
                                break;
                            case 3:
                                Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            default:
                                break;
                        }
                    }
                    catch { };
                    stream.Close();
                }
            }
            catch
            {
                Image = null;
            }
            if (Image != null)
            {
                Size = new System.Drawing.Size(183, 92);
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            return res;
        }
    }
}
