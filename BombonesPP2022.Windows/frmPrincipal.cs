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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FabricasButton_Click(object sender, EventArgs e)
        {
            frmFabricas frm = new frmFabricas()
                {Text = "Fabricas"};
            DialogResult dr = frm.ShowDialog(this);

        }

        private void RellenosButton_Click(object sender, EventArgs e)
        {
            frmTipoRelleno frm = new frmTipoRelleno()
                { Text = "Tipos De Rellenos" };
            DialogResult dr = frm.ShowDialog(this);

        }
    }
}
