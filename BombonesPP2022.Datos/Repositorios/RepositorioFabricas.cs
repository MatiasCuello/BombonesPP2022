using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Datos.Repositorios
{
    public class RepositorioFabricas
    {
        private readonly ConexionBD conexion;

        public RepositorioFabricas()
        {
            conexion = new ConexionBD();
        }

        public List<Fabrica> GetLista()
        {
            List<Fabrica> lista = new List<Fabrica>();
            try
            {
                using (var cn = conexion.AbrirConexion())
                {
                    var cadenaComando = "SELECT FabricaId, NombreFabrica, Direccion, GerenteDeVentas, PaisId, RowVersion FROM Fabricas";
                    var comando = new SqlCommand(cadenaComando, cn);
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var fabrica = ConstruirFabrica(reader);
                            lista.Add(fabrica);
                        }
                        
                    }
                    SetPaises(lista, cn);
                    return lista;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer de la tabla de Fabricas");
            }
        }

        public int Editar(Fabrica fabrica)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexion.AbrirConexion())
                {
                    var cadenaComando = "UPDATE Fabricas SET NombreFabrica=@nom, Direccion=@dir, GerenteDeVentas=@ger, PaisId=@paisId WHERE FabricaId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", fabrica.NombreFabrica);
                    comando.Parameters.AddWithValue("@dir", fabrica.Direccion);
                    comando.Parameters.AddWithValue("@ger", fabrica.GerenteVentas);
                    comando.Parameters.AddWithValue("@paisId", fabrica.PaisId);
                    comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                    comando.Parameters.AddWithValue("@r", fabrica.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Fabricas WHERE FabricaId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                        fabrica.RowVersion = (byte[])comando.ExecuteScalar();
                    }
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Fabrica repetida");
                }
                throw new Exception(e.Message);
            }
        }

        public void Agregar(Fabrica fabrica)
        {
            
            try
            {
                int registrosAfectados = 0;
                using (var cn = conexion.AbrirConexion())
                {
                    string cadenaComando = "INSERT INTO Fabricas (NombreFabrica, Direccion, GerenteDeVentas, PaisId) VALUES (@nom, @dir, @gerente,@paisId)";
                    SqlCommand comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@nom", fabrica.NombreFabrica);
                    comando.Parameters.AddWithValue("@dir", fabrica.Direccion);
                    comando.Parameters.AddWithValue("@gerente", fabrica.GerenteVentas);
                    comando.Parameters.AddWithValue("@paisId", fabrica.PaisId);
                    registrosAfectados = comando.ExecuteNonQuery();
                    if (registrosAfectados == 0)
                    {
                        throw new Exception("No se agregaron registros");
                    }
                    else
                    {
                        cadenaComando = "SELECT @@IDENTITY";
                        comando = new SqlCommand(cadenaComando, cn);
                        fabrica.FabricaId = (int) (decimal) comando.ExecuteScalar();
                        cadenaComando = "SELECT RowVersion FROM Fabricas WHERE FabricaId=@id";
                        comando = new SqlCommand(cadenaComando, cn);
                        comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                        fabrica.RowVersion = (byte[]) comando.ExecuteScalar();
                    }


                }

                
            }
            catch(Exception e )
            {
                throw new Exception(e.Message);
            }

        }
        public int Borrar(Fabrica fabrica)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = conexion.AbrirConexion())
                {
                    var cadenaComando = "DELETE FROM Fabricas WHERE FabricaId=@id AND RowVersion=@r";
                    var comando = new SqlCommand(cadenaComando, cn);
                    comando.Parameters.AddWithValue("@id", fabrica.FabricaId);
                    comando.Parameters.AddWithValue("@r", fabrica.RowVersion);
                    registrosAfectados = comando.ExecuteNonQuery();
                }

                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Fabrica relacionada... baja denegada");
                }
                throw new Exception(e.Message);
            }
        }


        private Fabrica ConstruirFabrica(SqlDataReader reader)
        {
            return new Fabrica()
            {
                FabricaId = reader.GetInt32(0),
                NombreFabrica = reader.GetString(1),
                Direccion = reader.GetString(2),
                GerenteVentas = reader.GetString(3),
                PaisId = reader.GetInt32(4),
                RowVersion = (byte[])reader[5]
            };
        }

        private void SetPaises(List<Fabrica> lista, SqlConnection cn)
        {
            foreach (var fabrica in lista)
            {
                fabrica.Pais = SetPais(fabrica.PaisId, cn);
            }
        }

        private Pais SetPais(int id, SqlConnection cn)
        {
            Pais pais = null;
            var cadenaComando = "SELECT PaisId, NombrePais, RowVersion FROM Paises WHERE PaisId=@id";
            var comando = new SqlCommand(cadenaComando, cn);
            comando.Parameters.AddWithValue("@id", id);
            using (var reader = comando.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    pais = ConstruirPais(reader);
                }
            }

            return pais;
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
