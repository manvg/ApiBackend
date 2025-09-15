using ApiBackend.Application.DTOs;
using ApiBackend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> GetById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddPedidoDto pedidoDto)
        {
            var id = await _pedidoService.AddPedidoAsync(pedidoDto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePedidoDto pedidoDto)
        {
            var result = await _pedidoService.UpdatePedidoAsync(id, pedidoDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pedidoService.DeletePedidoAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("CheckEstado")]
        public async Task<ActionResult<bool>> CheckEstadoApi()
        {
            return Ok(true);
        }
    }
}
