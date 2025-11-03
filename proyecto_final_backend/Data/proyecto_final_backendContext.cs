using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyecto_final_backend.Models;

namespace proyecto_final_backend.Data
{
    public class proyecto_final_backendContext : DbContext
    {
        public proyecto_final_backendContext(DbContextOptions<proyecto_final_backendContext> options)
            : base(options)
        {
        }

        public DbSet<proyecto_final_backend.Models.Caracteristica> Caracteristica { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.CaracteristicaProducto> CaracteristicaProducto { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Carrito> Carrito { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Componente> Componente { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ComponenteGarantia> ComponenteGarantia { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ComponenteOrden> ComponenteOrden { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ComponenteReparacion> ComponenteReparacion { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Compra> Compra { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.DetalleCompra> DetalleCompra { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.DetalleVenta> DetalleVenta { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Devolucion> Devolucion { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.DevolucionProducto> DevolucionProducto { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Garantia> Garantia { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.OrdenEnsamble> OrdenEnsamble { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Producto> Producto { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ProductoCarrito> ProductoCarrito { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Reparacion> Reparacion { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Rol> Rol { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Venta> Venta { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caracteristica>()
                .HasIndex(c => c.Tipo)
                .IsUnique();

            modelBuilder.Entity<CaracteristicaProducto>()
                .HasOne(cp => cp.Producto)
                .WithMany(p => p.CaracteristicasProducto)
                .HasForeignKey(cp => cp.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CaracteristicaProducto>()
                .HasOne(cp => cp.Caracteristica)
                .WithMany(c => c.CaracteristicasProducto)
                .HasForeignKey(cp => cp.IdCaracteristica)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CaracteristicaProducto>()
                .HasIndex(cp => new {cp.IdCaracteristica, cp.IdProducto})
                .IsUnique();

            modelBuilder.Entity<Carrito>()
               .HasOne(c => c.Cliente)
               .WithOne(cl => cl.Carrito)
               .HasForeignKey<Carrito>(c => c.IdCliente)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Carrito>()
                .HasIndex(c => c.IdCliente)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
               .HasIndex(c => c.Correo)
               .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Telefono)
                .IsUnique();

            modelBuilder.Entity<Componente>()
                .HasOne(c => c.ProductoPrincipal)
                .WithMany(p => p.ComponentesPrincipales)
                .HasForeignKey(c => c.IdProductoPrincipal)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Componente>()
                .HasOne(c => c.ProductoSecundario)
                .WithMany(p => p.ComponentesSecundarios)
                .HasForeignKey(c => c.IdProductoSecundario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Componente>()
                .HasIndex(c => new { c.IdProductoPrincipal, c.IdProductoSecundario })
                .IsUnique();

            modelBuilder.Entity<ComponenteGarantia>()
                .HasOne(cg => cg.Producto)
                .WithMany(p => p.ComponentesGarantias)
                .HasForeignKey(cg => cg.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteGarantia>()
                .HasOne(cg => cg.Garantia)
                .WithMany(g => g.Componentes)
                .HasForeignKey(cg => cg.IdGarantia)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteGarantia>()
                .HasIndex(cg => new { cg.IdProducto, cg.IdGarantia })
                .IsUnique();

            modelBuilder.Entity<ComponenteOrden>()
                .HasOne(co => co.Producto)
                .WithMany(p => p.ComponentesOrdenes)
                .HasForeignKey(co => co.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteOrden>()
                .HasOne(co => co.OrdenEnsamble)
                .WithMany(oe => oe.Componentes)
                .HasForeignKey(co => co.IdOrdenEnsamble)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteOrden>()
                .HasIndex(co => new { co.IdProducto, co.IdOrdenEnsamble })
                .IsUnique();

            modelBuilder.Entity<ComponenteReparacion>()
                .HasOne(cr => cr.Producto)
                .WithMany(p => p.ComponentesReparaciones)
                .HasForeignKey(cr => cr.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteReparacion>()
                .HasOne(cr => cr.Reparacion)
                .WithMany(r => r.Componentes)
                .HasForeignKey(cr => cr.IdReparacion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponenteReparacion>()
                .HasIndex(cr => new { cr.IdProducto, cr.IdReparacion })
                .IsUnique();

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Compra>()
                .HasIndex(c => c.IdProveedor)
                .IsUnique();

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.Compra)
                .WithMany(c => c.Detalles)
                .HasForeignKey(dc => dc.IdCompra)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.Producto)
                .WithMany(p => p.DetallesCompra)
                .HasForeignKey(dc => dc.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleCompra>()
                .HasIndex(dc => dc.IdProducto )
                .IsUnique();

            modelBuilder.Entity<DetalleCompra>()
                .HasIndex(dc => dc.IdCompra)
                .IsUnique();

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleVenta>()
                .HasIndex(d => d.IdProducto )
                .IsUnique();

            modelBuilder.Entity<DetalleVenta>()
                .HasIndex(d => d.IdVenta)
                .IsUnique();

            modelBuilder.Entity<Devolucion>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Devoluciones)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Devolucion>()
                .HasIndex(d => d.IdVenta)
                .IsUnique();

            modelBuilder.Entity<DevolucionProducto>()
                .HasOne(dp => dp.Producto)
                .WithMany(p => p.DevolucionesProducto)
                .HasForeignKey(dp => dp.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DevolucionProducto>()
                .HasOne(dp => dp.Devolucion)
                .WithMany(d => d.DevolucionesProducto)
                .HasForeignKey(dp => dp.IdDevolucion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DevolucionProducto>()
                .HasIndex(dp => new { dp.IdProducto, dp.IdDevolucion })
                .IsUnique();

            modelBuilder.Entity<Garantia>()
                .HasOne(g => g.Usuario)
                .WithMany(u => u.Garantias)
                .HasForeignKey(g => g.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Garantia>()
                .HasOne(g => g.Venta)
                .WithMany(v => v.Garantias)
                .HasForeignKey(g => g.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Garantia>()
                .HasIndex(g => g.IdUsuario)
                .IsUnique();

            modelBuilder.Entity<Garantia>()
                .HasIndex(g => g.IdVenta)
                .IsUnique();

            modelBuilder.Entity<OrdenEnsamble>()
                .HasOne(oe => oe.Usuario)
                .WithMany(u => u.OrdenesEnsamble)
                .HasForeignKey(oe => oe.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenEnsamble>()
                .HasOne(oe => oe.Venta)
                .WithOne(v => v.OrdenEnsamble)
                .HasForeignKey<OrdenEnsamble>(oe => oe.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrdenEnsamble>()
               .HasIndex(oe => oe.IdUsuario)
               .IsUnique();

            modelBuilder.Entity<OrdenEnsamble>()
                .HasIndex(oe => oe.IdVenta)
                .IsUnique();

            modelBuilder.Entity<Producto>()
                .HasIndex(p => p.Codigo)
                .IsUnique();

            modelBuilder.Entity<ProductoCarrito>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductosCarrito)
                .HasForeignKey(pc => pc.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductoCarrito>()
                .HasOne(pc => pc.Carrito)
                .WithMany(c => c.ProductosCarrito)
                .HasForeignKey(pc => pc.IdCarrito)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductoCarrito>()
                .HasIndex(pc => new { pc.IdProducto, pc.IdCarrito })
                .IsUnique();

            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.Correo)
                .IsUnique();

            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.Telefono)
                .IsUnique();

            modelBuilder.Entity<Reparacion>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reparaciones)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reparacion>()
                .HasOne(r => r.Venta)
                .WithMany(v => v.Reparaciones)
                .HasForeignKey(r => r.IdVenta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reparacion>()
                .HasIndex(r => r.IdUsuario);

            modelBuilder.Entity<Reparacion>()
                .HasIndex(r => r.IdVenta);

            modelBuilder.Entity<Rol>()
                .HasIndex(r => r.Nombre)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.IdRol)
                .IsUnique();

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Usuario)
                .WithMany(u => u.Ventas)
                .HasForeignKey(v => v.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venta>()
                .HasIndex(v => v.IdCliente)
                .IsUnique();

            modelBuilder.Entity<Venta>()
                .HasIndex(v => v.IdUsuario)
                .IsUnique();
        }
    }
}
