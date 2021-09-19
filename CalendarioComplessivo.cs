using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    class CalendarioComplessivo : Calendario
    {
        SortedList<DateTime, SetDataOraBase> avvenimentiDoppi = new SortedList<DateTime, SetDataOraBase>();
        int numeroDateAggiunte = 0;
        public bool AggiungiData(DateTime chiave, SetDataOraBase avvenimento)
        {
            bool res = false;
            if (!elencoDateFotiAsync.ContainsKey(chiave))
            {
                // nuovo
                elencoDateFotiAsync.Add(chiave, avvenimento);
                numeroDateAggiunte++;
                res = true;
            }
            else
            {
                avvenimentiDoppi.Add(chiave, avvenimento);// già presente
            }
            return res;
        }
        public void MessaggiConclusioneAggiunta()
        {
            Variabili.tracciaMessaggi("aggiunte " + numeroDateAggiunte + " nuove date a calendario complessivo");
        }
    }
}
