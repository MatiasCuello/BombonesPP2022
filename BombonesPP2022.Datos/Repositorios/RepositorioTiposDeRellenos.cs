using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioTiposDeRellenos
    {
        private readonly ConexionBD conexion;

        public RepositorioTiposDeRellenos()
        {
            conexion = new ConexionBD();
        }

        public List<TipoDeRelleno> GetLista()
        {
            List<TipoDeRelleno> lista = new List<TipoDeRelleno>();
            try
            {
                using (var cn = conexion.AbrirConexion())
                {
                    var cadenaComando = "SELECT TipoRellenoId, Relleno, RowVersion FROM TiposDeRelleno";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tpr = ConstruirTipoDeRelleno(reader);
                            lista.Add(tpr);
                        }

                    }
                    
                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer de la tabla de Tipos de Rellenos");
            }
        }

        private TipoDeRelleno ConstruirTipoDeRelleno(SqlDataReader reader)
        {
            return new TipoDeRelleno()
            {
                TipoRellenoId = reader.GetInt32(0),
                Relleno = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }
    }
}
