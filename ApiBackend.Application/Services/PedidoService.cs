using ApiBackend.Application.DTOs;
using ApiBackend.Application.Interfaces;
using ApiBackend.Application.Mappers;
using ApiBackend.Core.Interfaces;

namespace ApiBackend.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> GetPedidoByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoByIdAsync(id);
            return PedidoMapper.ToDto(pedido);
        }

        public async Task<List<PedidoDto>> GetAllPedidosAsync()
        {
            var pedidos = await _pedidoRepository.GetPedidosAsync();
            return PedidoMapper.ToDtoList(pedidos).ToList();
        }

        public async Task<int> AddPedidoAsync(AddPedidoDto pedidoDto)
        {
            var nuevoPedido = PedidoMapper.ToEntity(pedidoDto);

            await _pedidoRepository.AddPedidoAsync(nuevoPedido);
            return nuevoPedido.IdPedido;
        }

        public async Task<bool> UpdatePedidoAsync(int id, UpdatePedidoDto pedidoDto)
        {
            var pedido = await _pedidoRepository.GetPedidoByIdAsync(id);
            if (pedido == null) return false;

            pedido.IdMesa = pedidoDto.IdMesa;
            pedido.IdMozo = pedidoDto.IdMozo;
            pedido.IdEstadoPedido = pedidoDto.IdEstadoPedido;
            pedido.Comentario = pedidoDto.Comentario;

            await _pedidoRepository.UpdatePedidoAsync(id, pedido);
            return true;
        }

        public async Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoByIdAsync(id);
            if (pedido == null) return false;

            await _pedidoRepository.DeletePedidoByIdAsync(id);
            return true;
        }
    }
}
