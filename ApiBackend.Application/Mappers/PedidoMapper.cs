using ApiBackend.Application.DTOs;
using ApiBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBackend.Application.Mappers
{
    public class PedidoMapper
    {
        public static PedidoDto ToDto(Pedido pedido)
        {
            if (pedido == null) return null!;

            return new PedidoDto
            {
                IdPedido = pedido.IdPedido,
                IdMesa = pedido.IdMesa,
                IdMozo = pedido.IdMozo,
                IdEstadoPedido = pedido.IdEstadoPedido,
                Fecha = pedido.Fecha,
                Comentario = pedido.Comentario
            };
        }

        public static Pedido ToEntity(AddPedidoDto dto)
        {
            return new Pedido
            {
                IdMesa = dto.IdMesa,
                IdMozo = dto.IdMozo,
                IdEstadoPedido = dto.IdEstadoPedido,
                Fecha = DateTime.Now,
                Comentario = dto.Comentario
            };
        }

        public static IEnumerable<PedidoDto> ToDtoList(IEnumerable<Pedido> pedidos)
        {
            return pedidos.Select(ToDto).ToList();
        }
    }
}
