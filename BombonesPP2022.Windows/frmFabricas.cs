using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades.Entidades;
using BombonesPP2022.Servicios;
using BombonesPP2022.Windows.Helper;
using BombonesPP2022.Windows.Helpers;

namespace BombonesPP2022.Windows
{
    public partial class frmFabricas : Form
    {
        public frmFabricas()
        {
            InitializeComponent();
        }

        private ServicioFabricas servicio;
        private List<Fabrica> lista;

        private void frmFabricas_Load(object sender, EventArgs e)
        {
            servicio = new ServicioFabricas();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                HelperMensaje.Mensaje(TipoMensaje.Error, "Error al mostrar los registros de Fabricas", "Error");
            }
        }
        private void MostrarDatosEnGrilla()
        {
            HelperGrilla.LimpiarGrilla(DatosDataGridView);
            foreach (var fabrica in lista)
            {
                var r = HelperGrilla.ConstruirFila(DatosDataGridView);
                HelperGrilla.SetearFila(r, fabrica);
                HelperGrilla.AgregarFila(DatosDataGridView, r);
            }
        }

        private void NuevoIconButton_Click(object sender, EventArgs e)
        {
            frmFabricasAE frm = new frmFabricasAE()
            { Text = "Agregar Fabrica" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Fabrica fabrica = frm.GetFabrica();
                servicio.Agregar(fabrica);
                var r = HelperGrilla.ConstruirFila(DatosDataGridView);
                HelperGrilla.SetearFila(r, fabrica);
                HelperGrilla.AgregarFila(DatosDataGridView, r);
                HelperMensaje.Mensaje(TipoMensaje.Information, "Fabrica gregada", "Mensaje");


            }
            catch (Exception exception)
            {
                HelperMensaje.Mensaje(TipoMensaje.Error, exception.Message, "Error");
            }
        }
    }
}

