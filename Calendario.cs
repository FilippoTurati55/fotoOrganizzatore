using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    class Calendario
    {
        public SortedList<DateTime, SetDataOraBase> elencoDateFotiAsync = new SortedList<DateTime, SetDataOraBase>();
        public List<string> elencoDateDoppie = new List<string>();
        /*public void ElencaDateFotoCatalogate()
        {
            int lunghezzaRadice = Preferenze.NomeCartellaFotoOrganizzate.Length + 1;
            for (int n = 0; n < Variabili.dataBaseFotoLocali.elencoFoto.Count; n++)
            {
                var fotiEquDim = Variabili.dataBaseFotoLocali.elencoFoto.ElementAt(n);
                for (int f = 0; f < fotiEquDim.Value.Length; f++)
                {
                    var fileFoto = fotiEquDim.Value[f];
                    DateTime dt = new DateTime();
                    if (Utility.CalcolaDateTimeDaStringa(fileFoto, ref dt));
                    {

                    }
                }
            }
        }*/
        public void AggiungiData(string data)
        {
            //SetDataOra nuovoEvento = null;
            SetDataOraBase nuovoEventoBase = new SetDataOraBase();
            DateTime dateTime = new DateTime();
            string conclusione = "";
            string commento = "";
            if (Utility.CalcolaDateTimeDaStringa(data, ref dateTime, ref conclusione, ref commento))
            {
                nuovoEventoBase.SetData(dateTime, conclusione, commento);
                if (!elencoDateFotiAsync.ContainsKey(dateTime))
                {
                    elencoDateFotiAsync.Add(dateTime, nuovoEventoBase);
                }
                else
                {
                    if (!elencoDateDoppie.Contains(data))
                        elencoDateDoppie.Add(data);
                }
            }
        }
    }
}
