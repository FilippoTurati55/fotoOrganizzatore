using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public partial class Form1 : Form
    {
        Image i;
        public Form1()
        {
            InitializeComponent();
            immagine1.Image = leggiImmagineDaFile(@"c:\foto\2018\01 01\\WP_20180101_10_08_18_Rich.jpg");
        }
        public static Image leggiImmagineDaFile(string path)
        {
            Bitmap myImage = null;
            PropertyItem propItem4 = null;
            try
            {
                if (File.Exists(path))
                {
                    myImage = (Bitmap)System.Drawing.Image.FromFile(path);
                    try
                    {
                        propItem4 = myImage.GetPropertyItem(0x112);
                        switch (propItem4.Value[0])
                        {
                            case 0: break;
                            case 6:
                                myImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                                myImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                                break;
                            case 8:
                                break;
                            case 3:
                                myImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            default:
                                    break;
                        }
                    }
                    catch { };
                }
            }
            catch
            {
                myImage = null;
                // VarGlo.tracciaEccezioni("leggiImmagineDaFile myImage = null" + path + "\r\n");
            }
            return myImage;
        }
    }
}
