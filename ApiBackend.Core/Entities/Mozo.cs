using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Core.Entities
{
    public class Mozo
    {
        public int IdMozo { get; set; }
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public bool Vigente { get; set; }
    }
}
