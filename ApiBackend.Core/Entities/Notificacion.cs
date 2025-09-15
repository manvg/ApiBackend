using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Core.Entities
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int? IdPedido { get; set; }
        public string Mensaje { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public bool? Leida { get; set; }
    }
}
