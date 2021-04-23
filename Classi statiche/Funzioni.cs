using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore.Classi_statiche
{
    static class Funzioni
    {
        static public bool normalizzaNomeFile(ref string nomeFile, string nomePath)
        {
            bool res = false;
            string[] nome = null;
            try { 
                string nomeSoloFile = nomePath.Substring(nomePath.LastIndexOf('\\') + 1); 
                // verifica se il nome va bene
                // deve essere del tipo IMG_20210113_151008.jpg
                // l'estensione non è importante
                // la prima parte fino al primo _ non conta
                // la parte numerica tra il primo e il secondo _ conta
                // idem per la pafrte numerica tra il secondo _ e il .
                nome = nomeSoloFile.Split('.');
                string[] dataScomposta = nome[1].Split('_');
                string anno = dataScomposta[1].Substring(0, 4);
                string mese = dataScomposta[1].Substring(4, 2);
                string giorno = dataScomposta[1].Substring(6, 2);
                string ora = dataScomposta[2].Substring(0, 2);
                string minuto = dataScomposta[2].Substring(2, 2);
                string secondo = dataScomposta[2].Substring(4, 2);
                int annoi = Int16.Parse(anno);
                int mesei = Int16.Parse(mese);
                int giornoi = Int16.Parse(giorno);
                int orai = Int16.Parse(ora);
                int minutoi = Int16.Parse(minuto);
                int secondoi = Int16.Parse(secondo);
                if ((annoi > 1900) && (annoi < 2100) && (mesei < 13) && (giornoi < 32) &&
                    (orai < 24) && (minutoi < 60) && (secondoi < 60))
                {
                    res = true;
                }
            }
            catch { }
            try
            {
                if (res == false)
                {
                    // nome file errato: ricostruisci!
                    DateTime dt = new DateTime();
                    if (FileImmagini.CalcolaMomentoScattoFoto(nomePath, ref dt))
                    {
                        string nomeNuovo = "IMG_";
                        nomeNuovo += dt.Year.ToString("D4") +
                                         dt.Month.ToString("D2") +
                                         dt.Day.ToString("D2");
                        nomeNuovo += "_" + dt.Hour.ToString("D2") +
                                        dt.Minute.ToString("D2") +
                                        dt.Second.ToString("D2");
                        nomeNuovo += "." + nome[1];
                        nomeFile = nomeNuovo;
                        res = true;
                    }
                }
            }
            catch { }
            return res;
        }
    }
}
