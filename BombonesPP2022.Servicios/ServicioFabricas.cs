using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombonesPP2022.Datos.Repositorios;
using BombonesPP2022.Entidades.Entidades;

namespace BombonesPP2022.Servicios
{
    public class ServicioFabricas
    {
        private readonly RepositorioFabricas repositorio;

        public ServicioFabricas()
        {
            repositorio = new RepositorioFabricas();

        }

        public List<Fabrica> GetLista()
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

        public void Agregar(Fabrica fabrica)
        {
            try
            {
                repositorio.Agregar(fabrica);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(Fabrica fabrica)
        {
            try
            {
                return repositorio.Borrar(fabrica);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
