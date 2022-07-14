using BombonesPP2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricasAE : Form
    {
        public frmFabricasAE()
        {
            InitializeComponent();
        }

        private Fabrica fabrica;
        public Fabrica GetFabrica()
        {
            return fabrica;
        }

        private void OKIconButton_Click(object sender, EventArgs e)
        {

        }
    }
}
