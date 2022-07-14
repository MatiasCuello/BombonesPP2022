using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Datos;
using BombonesPP2022.Datos.Repositorios;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Servicios
{
    public class ServicioPaises
    {
        private readonly RepositorioPaises repositorio;
        private ConexionBD conexion;

        public ServicioPaises()
        {
            repositorio = new RepositorioPaises();
        }
        public List<Pais> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
    }
}
