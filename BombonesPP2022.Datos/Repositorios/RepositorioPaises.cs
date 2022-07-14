using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioPaises
    {
        private readonly ConexionBD conexion;

        public RepositorioPaises()
        {
            conexion = new ConexionBD();
        }

        public List<Pais> GetLista()
        {
            List<Pais> lista = new List<Pais>();
            try
            {
                using (var cn = conexion.AbrirConexion())
                {
                    var cadenaComando = "SELECT PaisId, NombrePais, RowVersion FROM Paises";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pais = ConstruirPais(reader);
                            lista.Add(pais);
                        }

                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer los paises");
            }
        }

        private Pais ConstruirPais(SqlDataReader reader)
        {
            return new Pais()
            {
                PaisId = reader.GetInt32(0),
                NombrePais = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }
    }
}
