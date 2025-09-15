using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Application.DTOs
{
    public class UpdatePedidoDto
    {
        public int IdPedido { get; set; }
        public int IdMesa { get; set; }
        public int? IdMozo { get; set; }
        public int IdEstadoPedido { get; set; }
        public string? Comentario { get; set; }
    }
}
