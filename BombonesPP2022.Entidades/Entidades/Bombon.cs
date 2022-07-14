using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombonesPP2022.Entidades.Entidades
{
    public class Bombon
    {
        public int BombonId { get; set; }
        public string NombreBombon { get; set; }
        public int TipoChocolateId { get; set; }
        public int TipoRellenoId { get; set; }
        public int TipoNuezId { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int FabricaId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
