namespace ApiBackend.Core.Entities
{
    public class EstadoPedido
    {
        public int IdEstadoPedido { get; set; }
        public string? Nombre { get; set; }
        public bool? Vigente { get; set; }
    }
}
