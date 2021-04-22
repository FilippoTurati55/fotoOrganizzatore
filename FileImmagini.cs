using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    public static class FileImmagini
    {
        // commento qui
        const string errorMessage = "Could not recognize image format.";

        private static Dictionary<byte[], Func<BinaryReader, System.Drawing.Size>> imageFormatDecoders = new Dictionary<byte[], Func<BinaryReader, System.Drawing.Size>>()
        {
            { new byte[]{ 0x42, 0x4D }, DecodeBitmap},
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, DecodeGif },
            { new byte[]{ 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 }, DecodeGif },
            { new byte[]{ 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, DecodePng },
            { new byte[]{ 0xff, 0xd8 },  DecodeJpg },
        };

        /// <summary>
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognized format.</exception>
        public static System.Drawing.Size GetDimensions(string path)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
            {
                try
                {
                    return GetDimensions(binaryReader);
                }
                catch (ArgumentException e)
                {
                    if (e.Message.StartsWith(errorMessage))
                    {
                        throw new ArgumentException(errorMessage, "path", e);
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the dimensions of an image.
        /// </summary>
        /// <param name="path">The path of the image to get the dimensions of.</param>
        /// <returns>The dimensions of the specified image.</returns>
        /// <exception cref="ArgumentException">The image was of an unrecognized format.</exception>    
        public static System.Drawing.Size GetDimensions(BinaryReader binaryReader)
        {
            int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;

            byte[] magicBytes = new byte[maxMagicBytesLength];

            for (int i = 0; i < maxMagicBytesLength; i += 1)
            {
                magicBytes[i] = binaryReader.ReadByte();

                foreach (var kvPair in imageFormatDecoders)
                {
                    if (magicBytes.StartsWith(kvPair.Key))
                    {
                        return kvPair.Value(binaryReader);
                    }
                }
            }

            throw new ArgumentException(errorMessage, "binaryReader");
        }

        public static bool IsImage(string path)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
            {
                try
                {
                    return IsImage(binaryReader);
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool IsImage(BinaryReader binaryReader)
        {
            int maxMagicBytesLength = imageFormatDecoders.Keys.OrderByDescending(x => x.Length).First().Length;

            byte[] magicBytes = new byte[maxMagicBytesLength];

            for (int i = 0; i < maxMagicBytesLength; i += 1)
            {
                magicBytes[i] = binaryReader.ReadByte();

                foreach (var kvPair in imageFormatDecoders)
                {
                    if (magicBytes.StartsWith(kvPair.Key))
                    {
                        return true;
                    }
                }
            }

            throw new ArgumentException(errorMessage, "binaryReader");
        }
        #region DATE_TIME
        public static bool CalcolaDataFoto(string fileName, ref DateTime dt)
        {
            bool res = false;
            if (!CalcolaDataFotoDaNomeFile(fileName, ref dt))
            {
                // calcola data da file
                res = CalcolaMomentoScattoFoto(fileName, ref dt);
            }
            return res;
        }
        static bool CalcolaDataFotoDaNomeFile(string fileName, ref DateTime dt)
        {
            bool res = false;
            try
            {
                string[] fotoScomposta = fileName.Split('\\');
                // no DateTime dt = File.GetCreationTime(fileName);
                string[] dataScomposta = fotoScomposta[fotoScomposta.Length - 1].Split('_');
                string anno = dataScomposta[1].Substring(0, 4);
                string mese = dataScomposta[1].Substring(4, 2);
                string giorno = dataScomposta[1].Substring(6, 2);
                int annoi = Int16.Parse(anno);
                int mesei = Int16.Parse(mese);
                int giornoi = Int16.Parse(giorno);
                if ((annoi > 1900) && (annoi < 2100) && (mesei < 13) && (giornoi < 32))
                {
                    dt = new DateTime(annoi, mesei, giornoi);
                    res = true;
                }
            }
            catch { }
            //risultato = new DateTime()
            return res;
        }
        static public bool CalcolaMomentoScattoFoto(string foto, ref DateTime dt)
        {
            bool res = false;
            if (IsImage(foto))
            {
                if (!CalcolaMomentoScattoDaProprietaFoto(foto, ref dt))
                    dt = CalcolaMomentoScattoDaInfoFile(foto);
                res = true;
            }
            return res;
        }
        static public DateTime CalcolaMomentoScattoDaInfoFile(string foto)
        {
            DateTime dt = new DateTime();
            FileInfo fi = new FileInfo(foto);
            // dt = fi.CreationTime;
            dt = fi.LastWriteTime;
            return dt;
        }
        static public bool CalcolaMomentoScattoDaProprietaFoto(string foto, ref DateTime dt)
        {
            bool result = false;
            ArrayList proprieta = new ArrayList();
            try
            {
                //System.Drawing.Image image = new Bitmap(foto);
                System.Drawing.Image image = System.Drawing.Image.FromFile(foto);
                try
                {
                    PropertyItem propItem20624;
                    PropertyItem propItem20625;
                    string data20624;
                    string data20625;
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    if (image.PropertyIdList.Contains(20624))
                    {
                        propItem20624 = image.GetPropertyItem(20624);
                        data20624 = encoding.GetString(propItem20624.Value);
                    }
                    if (image.PropertyIdList.Contains(20625))
                    {
                        propItem20625 = image.GetPropertyItem(20625);
                        data20625 = encoding.GetString(propItem20625.Value);
                    }

                    if (image.PropertyIdList.Contains(0x132))
                    {
                        PropertyItem propItem1 = image.GetPropertyItem(0x132);
                        PropertyItem propItem2 = null;
                        PropertyItem propItem3 = null;
                        PropertyItem propItem4 = null;
                        try
                        {
                            propItem2 = image.GetPropertyItem(0x9003);
                            propItem3 = image.GetPropertyItem(0x9004);
                            propItem4 = image.GetPropertyItem(0x112);
                        }
                        catch { };
                        //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
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
                        result = true;
                    }
                }
                catch { }
                image.Dispose();
            }
            catch { }
            return result;
        }

        static public bool VerificaDataFotoConPath(DateTime dataFoto, string percorso)
        {
            bool res = false;
            DateTime dt = new DateTime();
            string conclusione = "";
            string commento = "";
            if (Utility.CalcolaDateTimeDaStringa(percorso, ref dt, ref conclusione, ref commento)) ;
            {

            }
            return res;
        }

        #endregion
        private static bool StartsWith(this byte[] thisBytes, byte[] thatBytes)
        {
            for (int i = 0; i < thatBytes.Length; i += 1)
            {
                if (thisBytes[i] != thatBytes[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static short ReadLittleEndianInt16(this BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(short)];
            for (int i = 0; i < sizeof(short); i += 1)
            {
                bytes[sizeof(short) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt16(bytes, 0);
        }

        private static int ReadLittleEndianInt32(this BinaryReader binaryReader)
        {
            byte[] bytes = new byte[sizeof(int)];
            for (int i = 0; i < sizeof(int); i += 1)
            {
                bytes[sizeof(int) - 1 - i] = binaryReader.ReadByte();
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        private static System.Drawing.Size DecodeBitmap(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(16);
            int width = binaryReader.ReadInt32();
            int height = binaryReader.ReadInt32();
            return new System.Drawing.Size(width, height);
        }

        private static System.Drawing.Size DecodeGif(BinaryReader binaryReader)
        {
            int width = binaryReader.ReadInt16();
            int height = binaryReader.ReadInt16();
            return new System.Drawing.Size(width, height);
        }

        private static System.Drawing.Size DecodePng(BinaryReader binaryReader)
        {
            binaryReader.ReadBytes(8);
            int width = binaryReader.ReadLittleEndianInt32();
            int height = binaryReader.ReadLittleEndianInt32();
            return new System.Drawing.Size(width, height);
        }
        private static System.Drawing.Size DecodeJpg(BinaryReader binaryReader)
        {
            while (binaryReader.ReadByte() == 0xff)
            {
                byte marker = binaryReader.ReadByte();
                short chunkLength = binaryReader.ReadLittleEndianInt16();

                if (marker == 0xc0)
                {
                    binaryReader.ReadByte();

                    int height = binaryReader.ReadLittleEndianInt16();
                    int width = binaryReader.ReadLittleEndianInt16();
                    return new System.Drawing.Size(width, height);
                }

                binaryReader.ReadBytes(chunkLength - 2);
            }

            throw new ArgumentException(errorMessage);
        }
    }
}
