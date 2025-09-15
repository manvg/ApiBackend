using ApiBackend.Core.Entities;

namespace ApiBackend.Core.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task<Pedido> AddPedidoAsync(Pedido entity);
        Task<Pedido> UpdatePedidoAsync(int id, Pedido entity);
        Task<bool> DeletePedidoByIdAsync(int id);
    }
}
