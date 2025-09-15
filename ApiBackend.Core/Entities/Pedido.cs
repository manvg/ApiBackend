using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Core.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public int? IdMozo { get; set; }
        public int IdEstadoPedido { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Comentario { get; set; }
        //public EstadoPedido? EstadoPedido { get; set; }
        //public Mesa? Mesa { get; set; }
        //public Mozo? Mozo { get; set; }
        //public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
        //public ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
    }
}
