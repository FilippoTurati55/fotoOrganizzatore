using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public class CartellaBase
    {
        public Cartella cartella = null;
        string nomeCartella = "";
        string pathCompleto = "";
        SplitterPanel panel = null;
        #region COMPONENTE_VISUALE
        public Cartella creaCartella()
        {
            cartella = new Cartella(this);
            cartella.setNomeCartella(nomeCartella);
            return cartella;
        }
        #endregion
        #region ACCESSO
        public void setNomeCartella(string nome)
        {
            nomeCartella = nome;
            if (cartella != null)
                cartella.setNomeCartella(nomeCartella);
        }
        public string getNomeCartella()
        {
            return nomeCartella;
        }
        public void setPathCompleto(string path)
        {
            pathCompleto = path;
        }
        public string getPathCompleto()
        {
            return pathCompleto;
        }
        public void setSplitterPanel(SplitterPanel sp)
        {
            panel = sp;
        }
        public SplitterPanel getSplitterPanel()
        {
            return panel;
        }
        #endregion
    }
}
