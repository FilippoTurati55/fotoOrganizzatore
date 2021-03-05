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
        #region COMPONENTE_VISUALE
        public Cartella creaCartella()
        {
            cartella = new Cartella(this);
            return cartella;
        }
        #endregion
    }
}
