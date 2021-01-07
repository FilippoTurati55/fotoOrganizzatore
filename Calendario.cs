using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    class Calendario
    {
        public SortedList<DateTime, SetDataOraBase> elencoDateFotiAsync = new SortedList<DateTime, SetDataOraBase>();
        Panel SceltaCalendario;
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
        public void MostraCalendarioFoto(Panel pannello, bool soloDateNuove)
        {
            Avvenimento avvenimento;
            SetDataOraBase sdob;
            SceltaCalendario = pannello;
            pannello.Controls.Clear();
            int location = 0;
            foreach (var dt in elencoDateFotiAsync)
            {
                sdob = dt.Value;
                if (sdob.avvenimento == null)
                {
                    avvenimento = sdob.creaAvvenimento();
                }
                else
                {
                    avvenimento = sdob.avvenimento;
                }
                /*sdo.resetEventiClick();
                //if (dt.Value.GiorniEstesi)
                if (sdo.GiorniEstesi)
                {
                    // dt.Value.EventoClick += EventoSciogliRaggruppamento;
                    sdo.EventoClick += EventoSciogliRaggruppamento;
                }
                else
                {
                    // dt.Value.EventoClick += EventoSelezionaData;
                    sdo.EventoClick += EventoSelezionaData;
                }
                sdo.EventoModificaCommento += EventoModificaCommento;
                if ((Variabili.SelezioneCosaMostrareTutto) && (Variabili.elencoDateDiFotoNuove.ContainsKey(dt.Key)))
                {
                    sdo.dataInizio.Background =
                        sdo.dataFine.Background =
                        sdo.Evento.Background = new SolidColorBrush(Colors.Yellow);

                }
                if ((Variabili.SelezioneCosaMostrareTutto) || (Variabili.elencoDateDiFotoNuove.ContainsKey(dt.Key)))
                {
                    if ((!soloDateNuove) || (dt.Key > Variabili.DataLetturaFotoPrecedente))
                    {
                        _ = SceltaCalendario.Children.Add(sdo);
                    }
                }
                */
                SceltaCalendario.Controls.Add(avvenimento);
                avvenimento.resize();
                avvenimento.Location = new Point(0, location);
                location += avvenimento.Height;
            }
        }
    }
}
