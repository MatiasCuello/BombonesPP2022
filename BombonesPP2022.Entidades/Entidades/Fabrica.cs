using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades.Entidades
{
    public class Fabrica:ICloneable
    {
        public int FabricaId { get; set; }
        public string NombreFabrica { get; set; }
        public string Direccion { get; set; }
        public string GerenteVentas { get; set; }
        public int PaisId { get; set; }
        public byte[] RowVersion { get; set; }

        public Pais Pais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
