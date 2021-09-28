using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    static class Preferenze
    {
        public static string NomeCartellaFotoOrganizzate = @"c:\foto";
        public static string NomeFileCalendarioComplessivo = @"c:\foto\calendarioComplessivo.txt";
        public static bool verboso = false;
        //public static string NomeCartellaFotoDoppie = NomeCartellaFotoOrganizzate + @"\doppie";
        //public static string NomeCestino = NomeCartellaFotoOrganizzate + @"\cestino";
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
                                    // NomeCestino = Preferenze.NomeCartellaFotoOrganizzate + @"\cestino";
                                    break;
                                case "disco esterno accreditato":
                                    Variabili.UnitaEsterneAccreditate.Add(sSplit[1], sSplit[2] + ";" + sSplit[3]);
                                    break;
                                case "disco esterno rifiutato":
                                    Variabili.UnitaEsterneRifiutate.Add(sSplit[1], "");
                                    break;
                                case "verboso":
                                    Preferenze.verboso = true;
                                    break;
                                case "non verboso":
                                    Preferenze.verboso = false;
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
                // scrivi dischi esterni accreditati
                if (Variabili.UnitaEsterneAccreditate.Count > 0)
                {
                    for (int n = 0; n < Variabili.UnitaEsterneAccreditate.Count; n++)
                    {
                        var id = Variabili.UnitaEsterneAccreditate.ElementAt(n);
                        sw.WriteLine("disco esterno accreditato;" + id.Key + ";" + id.Value);
                    }
                }
                if (Variabili.UnitaEsterneRifiutate.Count > 0)
                {
                    for (int n = 0; n < Variabili.UnitaEsterneRifiutate.Count; n++)
                    {
                        var id = Variabili.UnitaEsterneRifiutate.ElementAt(n);
                        sw.WriteLine("disco esterno rifiutato;" + id.Key + ";" + id.Value);
                    }
                }
                if (Preferenze.verboso)
                    sw.WriteLine("verboso");
                else sw.WriteLine("non verboso");
                sw.Close();

            }
            return res;
        }
        public static string getNomeCartellaFotoDoppie()
        {
            return NomeCartellaFotoOrganizzate + @"\doppie";
        }
        public static string getNomeCestino()
        {
            return NomeCartellaFotoOrganizzate + @"\cestino";
        }
        public static bool creaCartellaDatiPermanenti()
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
