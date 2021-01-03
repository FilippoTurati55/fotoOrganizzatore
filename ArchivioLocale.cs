using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoOrganizzatore
{
    class ArchivioLocale
    {
        public bool PreparaCartelleFoto()
        {
            if (!Directory.Exists(Preferenze.NomeCartellaFotoOrganizzate))
            {
                Directory.CreateDirectory(Preferenze.NomeCartellaFotoOrganizzate);
            }
            return (Directory.Exists(Preferenze.NomeCartellaFotoOrganizzate));
        }
    }
}
