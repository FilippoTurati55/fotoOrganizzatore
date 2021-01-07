using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    static class Utility
    {
        public static bool CalcolaDateTimeDaStringa(string nomeFile, ref DateTime dateTime, ref string conclusione, ref string commento)
        {
            int anno, mese,giorno;
            bool res = false;
            try
            {
                string[] fileFotoSplit = nomeFile.Split('\\');
                if (fileFotoSplit.Length == 5)
                {
                    if (Int32.TryParse(fileFotoSplit[2], out anno))
                    {
                        string[] meseGiorno = fileFotoSplit[3].Split(' ');
                        if (Int32.TryParse(meseGiorno[0], out mese))
                        {
                            bool giornoCorretto = false;
                            if (meseGiorno[1].Contains('_'))
                            {
                                // evento su più di un giorno
                                string[] giornoMultiplo = meseGiorno[1].Split('_');
                                conclusione = giornoMultiplo[1];
                                for (int n = 2; n < giornoMultiplo.Length; n++)
                                {
                                    // evento su più mesi o anni
                                    conclusione += " " + giornoMultiplo[n];
                                }
                                if (Int32.TryParse(giornoMultiplo[0], out giorno))
                                    giornoCorretto = true;
                            }
                            else
                            {
                                if (Int32.TryParse(meseGiorno[1], out giorno))
                                    giornoCorretto = true;
                            }
                            if (meseGiorno.Length > 2)
                            {
                                commento += meseGiorno[2];
                                for (int n = 3; n < meseGiorno.Length; n++)
                                {
                                    commento += " " + meseGiorno[n];
                                }
                            }
                            if (giornoCorretto)
                            {
                                dateTime = new DateTime(anno, mese, giorno);
                                res = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                // tracciare l'errore nel calcolo della data
                ;
            }
            return res;
        }
        public static bool CalcolaDateTimeDaStringa(string anno, string data, ref DateTime dateTime, ref string conclusione, ref string commento)
        {
            bool res = false;
            conclusione = "";
            try
            {
                int annoInt, meseInt, giornoInt;
                _ = Int32.TryParse(anno, out annoInt);
                string[] dataGiorno = data.Split(' ');
                _ = Int32.TryParse(dataGiorno[0], out meseInt);
                if (!dataGiorno[1].Contains("_"))
                {
                    _ = Int32.TryParse(dataGiorno[1], out giornoInt);
                }
                else
                {
                    string[] giornoMultiplo = dataGiorno[1].Split('_');
                    _ = Int32.TryParse(giornoMultiplo[0], out giornoInt);
                    conclusione = giornoMultiplo[1];
                    for (int n = 2; n < giornoMultiplo.Length; n++)
                    {
                        conclusione += " " + giornoMultiplo[n];
                    }
                }
                if (dataGiorno.Length > 2)
                {
                    commento += dataGiorno[2];
                    for (int n = 3; n < dataGiorno.Length; n++)
                    {
                        commento += " " + dataGiorno[n];
                    }
                }
                dateTime = new DateTime(annoInt, meseInt, giornoInt);
                res = true;
            }
            catch { }
            return res;
        }
    }
}
