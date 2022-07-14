using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Windows.Helper
{
    public static class HelperGrilla
    {
        public static DataGridViewRow ConstruirFila(DataGridView dataGrid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dataGrid);
            return r;
        }

        public static void AgregarFila(DataGridView dataGrid, DataGridViewRow r)
        {
            dataGrid.Rows.Add(r);
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Fabrica f:

                    r.Cells[0].Value = ((Fabrica) obj).NombreFabrica;
                    r.Cells[1].Value = ((Fabrica)obj).Direccion;
                    r.Cells[2].Value = ((Fabrica)obj).Pais.NombrePais;
                    r.Cells[3].Value = ((Fabrica)obj).GerenteVentas;

                    break;
                case TipoDeRelleno tp:

                    r.Cells[0].Value = ((TipoDeRelleno)obj).Relleno;
                    
                    break;


            }

            r.Tag = obj;
        }
        public static void LimpiarGrilla(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
        }
    }
}