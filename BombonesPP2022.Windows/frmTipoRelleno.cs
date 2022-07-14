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
    public partial class frmTipoRelleno : Form
    {
        public frmTipoRelleno()
        {
            InitializeComponent();
        }
        private ServicioTipoDeRellenos servicio;
        private List<TipoDeRelleno> lista;

        private void frmTipoRelleno_Load(object sender, EventArgs e)
        {
            servicio = new ServicioTipoDeRellenos();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                HelperMensaje.Mensaje(TipoMensaje.Error, "Error al mostrar los registros de Tipos de rellenos", "Error");
            }
        }
        private void MostrarDatosEnGrilla()
        {
            HelperGrilla.LimpiarGrilla(DatosDataGridView);
            foreach (var tipoDeRelleno in lista)
            {
                var r = HelperGrilla.ConstruirFila(DatosDataGridView);
                HelperGrilla.SetearFila(r, tipoDeRelleno);
                HelperGrilla.AgregarFila(DatosDataGridView, r);
            }
        }

    }
}
