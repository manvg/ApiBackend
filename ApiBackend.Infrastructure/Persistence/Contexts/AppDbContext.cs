using ApiBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ApiBackend.Infrastructure.Persistence.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<EstadoPedido> EstadoPedido { get; set; }

    public virtual DbSet<Mesa> Mesa { get; set; }

    public virtual DbSet<Mozo> Mozo { get; set; }

    public virtual DbSet<Notificacion> Notificacion { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1001AF13C2");

            //entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Categoria)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Categoria_Restaurante");
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPedido).HasName("PK__EstadoPe__86B98371389826CA");
        });

        //modelBuilder.Entity<Interaccion>(entity =>
        //{
        //    entity.HasKey(e => e.IdInteraccion).HasName("PK__Interacc__ADBFF88300B80123");

        //    entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Interaccion)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Interaccion_Mesa");

        //    entity.HasOne(d => d.IdTipoInteraccionNavigation).WithMany(p => p.Interaccion)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Interaccion_TipoInteraccion");
        //});

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK__Mesa__4D7E81B1A2FD6C4B");

            //entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Mesa)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Mesa_Restaurante");
        });

        modelBuilder.Entity<Mozo>(entity =>
        {
            entity.HasKey(e => e.IdMozo).HasName("PK__Mozo__33CE84AF78F61A0B");

            //entity.HasOne(d => d.IdRestauranteNavigation).WithMany(p => p.Mozo)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Mozo_Restaurante");
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__F6CA0A8576B65B85");

            entity.Property(e => e.Leida).HasDefaultValue(false);

            //entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Notificacion).HasConstraintName("FK_Notificacion_Pedido");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC39D3ED3EE");

            //entity.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.Pedido)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Pedido_EstadoPedido");

            //entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.Pedido)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Pedido_Mesa");

            //entity.HasOne(d => d.IdMozoNavigation).WithMany(p => p.Pedido).HasConstraintName("FK_Pedido_Mozo");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdPedidoDetalle).HasName("PK__PedidoDe__968E515B8BEAD77E");

            //entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoDetalle).HasConstraintName("FK_PedidoDetalle_Pedido");

            //entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PedidoDetalle)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PedidoDetalle_Producto");
        });

        //modelBuilder.Entity<Producto>(entity =>
        //{
        //    entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210B6B568D0");

        //    entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Producto_Categoria");
        //});

        //modelBuilder.Entity<Restaurante>(entity =>
        //{
        //    entity.HasKey(e => e.IdRestaurante).HasName("PK__Restaura__29CE64FA24AEA7D8");
        //});

        //modelBuilder.Entity<TipoInteraccion>(entity =>
        //{
        //    entity.HasKey(e => e.IdTipoInteraccion).HasName("PK__TipoInte__1280F8D444B3D788");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
