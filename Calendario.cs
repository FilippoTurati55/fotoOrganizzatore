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
        public void ElencaDateFotoCatalogate()
        {
            for (int n = 0; n < Variabili.dataBaseFotoLocali.elencoFoto.Count; n++)
            {
                var fotiEquDim = Variabili.dataBaseFotoLocali.elencoFoto.ElementAt(n);
                for (int f = 0; f < fotiEquDim.Value.Length; f++)
                {
                    var fileFoto = fotiEquDim.Value[f];
                }
            }
        }
    }
}
