using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Application.DTOs
{
    public class PedidoDto
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public int? IdMozo { get; set; }
        public int IdEstadoPedido { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Comentario { get; set; }

        public List<PedidoDetalleDto> Detalles { get; set; } = new();
    }
}
