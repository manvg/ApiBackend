using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Core.Entities
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public int IdRestaurante { get; set; }
        public string UrlCodigoQr { get; set; } = null!;
        public string NumeroMesa { get; set; } = null!;
        public bool Vigente { get; set; }
    }
}
