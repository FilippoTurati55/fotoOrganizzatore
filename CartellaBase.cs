using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    public class CartellaBase
    {
        public Cartella cartella = null;
        string nomeCartella = "";
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
        #endregion
    }
}
