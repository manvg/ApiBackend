using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Application.DTOs
{
    public class PedidoDetalleDto
    {
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }
}
