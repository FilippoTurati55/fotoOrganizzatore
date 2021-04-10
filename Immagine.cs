using System;
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
        string nomeFile = "";
        public Immagine()
        {
            Image = null;
        }
        public bool leggiImmagineDaFile(string path)
        {
            bool res = false;
            nomeFile = path;
            PropertyItem propItem4 = null;
            DateTime dt = new DateTime();
            try
            {
                if (File.Exists(nomeFile))
                {
                    // Image = (Bitmap)System.Drawing.Image.FromFile(path);
                    FileStream stream = new FileStream(nomeFile, FileMode.Open, FileAccess.Read);
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
                    // leggi momento scatto
                    try
                    {
                        PropertyItem propItem1 = Image.GetPropertyItem(0x132);
                        PropertyItem propItem2 = null;
                        PropertyItem propItem3 = null;
                        //PropertyItem propItem4 = null;
                        try
                        {
                            propItem2 = Image.GetPropertyItem(0x9003);
                            propItem3 = Image.GetPropertyItem(0x9004);
                            propItem4 = Image.GetPropertyItem(0x112);
                        }
                        catch { };
                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                        string data1 = encoding.GetString(propItem1.Value);
                        string data2 = "";
                        string data3 = "";
                        if (propItem2 != null)
                            data2 = encoding.GetString(propItem2.Value);
                        if (propItem3 != null)
                            data3 = encoding.GetString(propItem3.Value);
                        if ((data1 != data2) && (data1 != data3))
                        {
                            // temporaneo Variabili.DiversitaInRicercaDataScatto++;
                        }
                        int anni = System.Int32.Parse(data1.Substring(0, 4));
                        dt.AddYears(anni);
                        int mesi = System.Int32.Parse(data1.Substring(5, 2));
                        int giorni = System.Int32.Parse(data1.Substring(8, 2));
                        DateTime dattim = new DateTime(anni, mesi, giorni);
                        dt = dattim;
                    }
                    catch { }
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
        public void ruotaImmagine()
        {
            PropertyItem propItem4 = null;
            int[] elencoProprieta = Image.PropertyIdList;
            List<int> ep = elencoProprieta.ToList();
            if (ep.Contains(0x112))
            {
                propItem4 = Image.GetPropertyItem(0x112);
                //EncoderParameters<EncoderParameter> epa = Image.GetEncoderParameterList();
                switch (propItem4.Value[0])
                {
                    case 1:  // in origine è orizzontale
                        Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        Size = new System.Drawing.Size(183, 92);
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        Image.Save(nomeFile, ImageFormat.Jpeg);
                        //Image.Save(nomeFile,Image.RawFormat\, Image.GetEncoderParameterList());
                        break;
                }
            }
        }
    }
}
