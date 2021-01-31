using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoOrganizzatore
{
    public partial class ImmagineIngrandita : UserControl
    {
        bool selected = false;
        public ImmagineIngrandita()
        {
            InitializeComponent();
        }
        public void setImmagine(Image i)
        {
            immagine.Image = i;
        }
    }
}
