﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    static class Preferenze
    {
        static string NomeCartellaFotoOrganizzate = @"c:\foto";
        public static bool LeggiPreferenze()
        {
            bool res = false;
            string path;
            if (creaCartellaDatiPermanenti())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/fotografo/preferenze/preferenze.txt";

                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));
                    try
                    {
                        for (int n = 0; n < lines.Length; n++)
                        {
                            // s = sr.ReadLine();
                            string s = lines[n];
                            string[] sSplit = s.Split(';');
                            switch (sSplit[0])
                            {
                                case "cartella locale foto":
                                    NomeCartellaFotoOrganizzate = sSplit[1];
                                    break;
                            }
                        }
                        res = true;
                    }
                    catch { };
                }
            }
            return res;
        }
        public static bool ScriviPreferenze()
        {
            bool res = false;
            string path;
            if (creaCartellaDatiPermanenti())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/fotografo/preferenze/preferenze.txt";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("iso-8859-1"));
                sw.WriteLine("cartella locale foto;" + NomeCartellaFotoOrganizzate);
                sw.Close();

            }
            return res;
        }
        static bool creaCartellaDatiPermanenti()
        {
            bool res = false;
            bool errore = false;
            DirectoryInfo di;
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                if (!Directory.Exists(path + @"/fotografo"))
                {
                    di = Directory.CreateDirectory(path + @"/fotografo");
                    if (!di.Exists)
                        errore = true;
                }
                if (!Directory.Exists(path + @"/fotografo/preferenze"))
                {
                    di = Directory.CreateDirectory(path + @"/fotografo/preferenze");
                    if (!di.Exists)
                        errore = true;
                }
                if (!errore)
                    res = true;
            }
            catch
            {
            }
            return res;
        }
    }
}
