using ApiBackend.Application.DTOs;

namespace ApiBackend.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDto> GetPedidoByIdAsync(int id);
        Task<List<PedidoDto>> GetAllPedidosAsync();
        Task<int> AddPedidoAsync(AddPedidoDto pedidoDto);
        Task<bool> UpdatePedidoAsync(int id, UpdatePedidoDto pedidoDto);
        Task<bool> DeletePedidoAsync(int id);
    }
}
