using ApiBackend.Core.Entities;
using ApiBackend.Core.Interfaces;
using ApiBackend.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Infrastructure.Persistence.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _dbContext;

        public PedidoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await _dbContext.Pedido.ToListAsync();
        }

        public async Task<Pedido?> GetPedidoByIdAsync(int id)
        {
            return await _dbContext.Pedido.FirstOrDefaultAsync(p => p.IdPedido == id);
        }

        public async Task<Pedido> AddPedidoAsync(Pedido entity)
        {
            _dbContext.Pedido.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Pedido?> UpdatePedidoAsync(int id, Pedido entity)
        {
            var pedido = await _dbContext.Pedido.FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido is not null)
            {
                pedido.IdMesa = entity.IdMesa;
                pedido.IdMozo = entity.IdMozo;
                pedido.IdEstadoPedido = entity.IdEstadoPedido;
                pedido.Comentario = entity.Comentario;

                await _dbContext.SaveChangesAsync();
                return pedido;
            }

            return null;
        }

        public async Task<bool> DeletePedidoByIdAsync(int id)
        {
            var pedido = await _dbContext.Pedido.FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido is not null)
            {
                _dbContext.Pedido.Remove(pedido);
                return await _dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
