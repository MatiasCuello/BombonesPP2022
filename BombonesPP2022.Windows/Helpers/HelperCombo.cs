using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombonesPP2022.Windows.Helpers
{
    public static class HelperCombo
    {
        public static void CargarDatosComboPaises(ref ComboBox comboBox)
        {
            IservicioPais servicioTipoDocumento = new ServicioTipoDocumento();
            var lista = servicioTipoDocumento.GetTipoDocumento();
            var defaultTipoDocumento = new TipoDocumento
            {
                TipoDocumentoId = 0,
                Descripcion = "Seleccionar Tipo"
            };
            lista.Insert(0, defaultTipoDocumento);
            comboBox.DataSource = lista;
            comboBox.ValueMember = "TipoDocumentoId";
            comboBox.DisplayMember = "Descripcion";
            comboBox.SelectedIndex = 0;
        }
}
