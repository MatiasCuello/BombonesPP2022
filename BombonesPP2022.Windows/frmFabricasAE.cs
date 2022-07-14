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
using BombonesPP2022.Servicios;
using BombonesPP2022.Windows.Helpers;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricasAE : Form
    {
        public frmFabricasAE()
        {
            InitializeComponent();
        }

        private Fabrica fabrica;
        private ServicioPaises servicio;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            servicio = new ServicioPaises();
            HelperCombo.CargarDatosComboPaises(ref PaisesComboBox);
            if (fabrica != null)
            {
                FabricaTextBox.Text = fabrica.NombreFabrica;
                DireccionTextBox.Text = fabrica.Direccion;
                GerenteTextBox.Text = fabrica.GerenteVentas;
                PaisesComboBox.SelectedValue = fabrica.PaisId;
            }
        }
        public Fabrica GetFabrica()
        {
            return fabrica;
        }

        private void OKIconButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (fabrica == null)
                {
                    fabrica = new Fabrica();
                }

                fabrica.NombreFabrica = FabricaTextBox.Text;
                fabrica.Direccion = DireccionTextBox.Text;
                fabrica.Pais = (Pais)PaisesComboBox.SelectedItem;
                fabrica.PaisId = ((Pais)PaisesComboBox.SelectedItem).PaisId;
                fabrica.GerenteVentas = GerenteTextBox.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (PaisesComboBox.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(PaisesComboBox, "Debe seleccionar un pais");

            }
            if (string.IsNullOrEmpty(FabricaTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(FabricaTextBox, "El nombre de la fabrica es requerido");
            }
            if (string.IsNullOrEmpty(DireccionTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(DireccionTextBox, "La direccion es requerida");
            }
            if (string.IsNullOrEmpty(GerenteTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(GerenteTextBox, "El gerente es requerido");
            }
            return valido;
        }


        private void CancelarIconButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmFabricasAE_Load(object sender, EventArgs e)
        {

        }

        public void SetFabrica(Fabrica fabrica)
        {
            this.fabrica = fabrica;
        }
    }
}
