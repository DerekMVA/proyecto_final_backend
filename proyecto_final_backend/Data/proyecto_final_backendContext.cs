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

            // Seed data base
            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Nombre = "Administrador", Descripcion = "Acceso total al sistema", Deleted = false },
                new Rol { Id = 2, Nombre = "Vendedor", Descripcion = "Gestión de ventas", Deleted = false }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreCompleto = "Usuario Administrador",
                    NombreUsuario = "admin",
                    Contrasena = "admin123",
                    Salario = 0m,
                    Deleted = false,
                    IdRol = 1
                },
                new Usuario
                {
                    Id = 2,
                    NombreCompleto = "Usuario Vendedor",
                    NombreUsuario = "vendedor",
                    Contrasena = "vendedor123",
                    Salario = 0m,
                    Deleted = false,
                    IdRol = 2
                }
            );

            // Seed Proveedores
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor { Id = 1, Nombre = "Tech Parts", NombreContacto = "Ana Lopez", Correo = "contacto@techparts.com", Telefono = "555-1000", Deleted = false },
                new Proveedor { Id = 2, Nombre = "CompuDistrib", NombreContacto = "Luis Garcia", Correo = "ventas@compudistrib.com", Telefono = "555-2000", Deleted = false }
            );

            // Seed Productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Tarjeta Madre A1", Codigo = "PROD-001", Precio = 1500.00m, Stock = 50, StockMinimo = 10, Nuevo = true, Tipo = 1, Imagen = "mb-a1.png", Deleted = false },
                new Producto { Id = 2, Nombre = "Procesador X", Codigo = "PROD-002", Precio = 2200.00m, Stock = 35, StockMinimo = 8, Nuevo = true, Tipo = 1, Imagen = "cpu-x.png", Deleted = false },
                new Producto { Id = 3, Nombre = "Memoria 16GB", Codigo = "PROD-003", Precio = 600.00m, Stock = 80, StockMinimo = 20, Nuevo = true, Tipo = 2, Imagen = "ram-16gb.png", Deleted = false },
                new Producto { Id = 4, Nombre = "SSD 1TB", Codigo = "PROD-004", Precio = 900.00m, Stock = 60, StockMinimo = 15, Nuevo = true, Tipo = 2, Imagen = "ssd-1tb.png", Deleted = false },
                new Producto { Id = 5, Nombre = "Fuente 650W", Codigo = "PROD-005", Precio = 500.00m, Stock = 40, StockMinimo = 10, Nuevo = false, Tipo = 3, Imagen = "psu-650w.png", Deleted = false }
            );

            // Seed Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, NombreCompleto = "Cliente Demo", Correo = "cliente@demo.com", Telefono = "555-3000", Deleted = false },
                new Cliente { Id = 2, NombreCompleto = "Juan Perez", Correo = "juan@correo.com", Telefono = "555-4000", Deleted = false }
            );

            // Seed Caracteristicas
            modelBuilder.Entity<Caracteristica>().HasData(
                new Caracteristica { Id = 1, Tipo = "Compatibilidad", Descripcion = "Socket LGA1700", Deleted = false },
                new Caracteristica { Id = 2, Tipo = "Capacidad", Descripcion = "16GB DDR4", Deleted = false },
                new Caracteristica { Id = 3, Tipo = "Almacenamiento", Descripcion = "SSD 1TB NVMe", Deleted = false },
                new Caracteristica { Id = 4, Tipo = "Potencia", Descripcion = "Fuente 650W", Deleted = false }
            );

            // Seed CaracteristicasProducto
            modelBuilder.Entity<CaracteristicaProducto>().HasData(
                new CaracteristicaProducto { Id = 1, IdProducto = 1, IdCaracteristica = 1 },
                new CaracteristicaProducto { Id = 2, IdProducto = 3, IdCaracteristica = 2 },
                new CaracteristicaProducto { Id = 3, IdProducto = 4, IdCaracteristica = 3 },
                new CaracteristicaProducto { Id = 4, IdProducto = 5, IdCaracteristica = 4 },
                new CaracteristicaProducto { Id = 5, IdProducto = 2, IdCaracteristica = 1 }
            );

            // Seed Carritos
            modelBuilder.Entity<Carrito>().HasData(
                new Carrito { Id = 1, IdCliente = 1, MontoTotal = 600.00m },
                new Carrito { Id = 2, IdCliente = 2, MontoTotal = 1500.00m }
            );

            // Seed Productos en Carrito
            modelBuilder.Entity<ProductoCarrito>().HasData(
                new ProductoCarrito { Id = 1, IdCarrito = 1, IdProducto = 3, Precio = 600.00m, Cantidad = 1, Deleted = false },
                new ProductoCarrito { Id = 2, IdCarrito = 2, IdProducto = 1, Precio = 1500.00m, Cantidad = 1, Deleted = false }
            );

            // Seed Ventas
            modelBuilder.Entity<Venta>().HasData(
                new Venta { Id = 1, Fecha = new DateOnly(2025, 1, 1), MontoTotal = 2200.00m, Deleted = false, IdCliente = 1, IdUsuario = 1 },
                new Venta { Id = 2, Fecha = new DateOnly(2025, 2, 1), MontoTotal = 1500.00m, Deleted = false, IdCliente = 2, IdUsuario = 2 }
            );

            // Seed Detalles de Venta
            modelBuilder.Entity<DetalleVenta>().HasData(
                new DetalleVenta { Id = 1, IdVenta = 1, IdProducto = 2, Precio = 2200.00m, Cantidad = 1, Deleted = false },
                new DetalleVenta { Id = 2, IdVenta = 2, IdProducto = 1, Precio = 1500.00m, Cantidad = 1, Deleted = false }
            );

            // Seed Ordenes de Ensamble
            modelBuilder.Entity<OrdenEnsamble>().HasData(
                new OrdenEnsamble { Id = 1, PrecioEnsamble = 300.00m, Estado = 1, Deleted = false, IdUsuario = 1, IdVenta = 1 },
                new OrdenEnsamble { Id = 2, PrecioEnsamble = 200.00m, Estado = 1, Deleted = false, IdUsuario = 2, IdVenta = 2 }
            );

            modelBuilder.Entity<ComponenteOrden>().HasData(
                new ComponenteOrden { Id = 1, IdOrdenEnsamble = 1, IdProducto = 1, Precio = 1500.00m, Cantidad = 1 },
                new ComponenteOrden { Id = 2, IdOrdenEnsamble = 2, IdProducto = 3, Precio = 600.00m, Cantidad = 1 }
            );

            // Seed Garantias
            modelBuilder.Entity<Garantia>().HasData(
                new Garantia { Id = 1, Fecha = new DateOnly(2025, 1, 15), Estado = 1, Deleted = false, IdUsuario = 1, IdVenta = 1 },
                new Garantia { Id = 2, Fecha = new DateOnly(2025, 2, 15), Estado = 1, Deleted = false, IdUsuario = 2, IdVenta = 2 }
            );

            modelBuilder.Entity<ComponenteGarantia>().HasData(
                new ComponenteGarantia { Id = 1, IdGarantia = 1, IdProducto = 4, Cantidad = 1 },
                new ComponenteGarantia { Id = 2, IdGarantia = 2, IdProducto = 1, Cantidad = 1 }
            );

            // Seed Devoluciones
            modelBuilder.Entity<Devolucion>().HasData(
                new Devolucion { Id = 1, PrecioDevolucion = 500.00m, Deleted = false, IdVenta = 1 },
                new Devolucion { Id = 2, PrecioDevolucion = 1500.00m, Deleted = false, IdVenta = 2 }
            );

            modelBuilder.Entity<DevolucionProducto>().HasData(
                new DevolucionProducto { Id = 1, IdDevolucion = 1, IdProducto = 5 },
                new DevolucionProducto { Id = 2, IdDevolucion = 2, IdProducto = 1 }
            );

            // Seed Compras y Detalles
            modelBuilder.Entity<Compra>().HasData(
                new Compra { Id = 1, Fecha = new DateOnly(2025, 1, 5), MontoTotal = 14000.00m, Deleted = false, IdProveedor = 1 },
                new Compra { Id = 2, Fecha = new DateOnly(2025, 2, 5), MontoTotal = 8500.00m, Deleted = false, IdProveedor = 2 }
            );

            modelBuilder.Entity<DetalleCompra>().HasData(
                new DetalleCompra { Id = 1, IdCompra = 1, IdProducto = 1, Precio = 1400.00m, Cantidad = 10, Deleted = false },
                new DetalleCompra { Id = 2, IdCompra = 2, IdProducto = 4, Precio = 850.00m, Cantidad = 10, Deleted = false }
            );

            // Seed Componentes (relaciones de compatibilidad/ensamble)
            modelBuilder.Entity<Componente>().HasData(
                new Componente { Id = 1, IdProductoPrincipal = 1, IdProductoSecundario = 2 },
                new Componente { Id = 2, IdProductoPrincipal = 1, IdProductoSecundario = 3 },
                new Componente { Id = 3, IdProductoPrincipal = 2, IdProductoSecundario = 3 }
            );

            // Seed Reparaciones y Componentes usados
            modelBuilder.Entity<Reparacion>().HasData(
                new Reparacion { Id = 1, Precio = 300.00m, Deleted = false, IdUsuario = 1, IdVenta = 1 },
                new Reparacion { Id = 2, Precio = 700.00m, Deleted = false, IdUsuario = 2, IdVenta = 2 }
            );

            modelBuilder.Entity<ComponenteReparacion>().HasData(
                new ComponenteReparacion { Id = 1, IdReparacion = 1, IdProducto = 5, Precio = 500.00m, Cantidad = 1 },
                new ComponenteReparacion { Id = 2, IdReparacion = 2, IdProducto = 1, Precio = 700.00m, Cantidad = 1 }
            );
        }
    }
}
