using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades.Entidades;
using BombonesPP2022.Servicios;

namespace BombonesPP2022.Windows.Helpers
{
    public static class HelperCombo
    {
        public static void CargarDatosComboPaises(ref ComboBox comboBox)
        {
            ServicioPaises servicio = new ServicioPaises();
            var lista = servicio.GetLista();
            var defaultPais = new Pais()
            {
                PaisId = 0,
                NombrePais = "Seleccione País"
            };
            lista.Insert(0, defaultPais);
            comboBox.DataSource = lista;
            comboBox.DisplayMember = "NombrePais";
            comboBox.ValueMember = "PaisId";
            comboBox.SelectedIndex = 0;
        }
    }
}
