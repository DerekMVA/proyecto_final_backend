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
        public proyecto_final_backendContext (DbContextOptions<proyecto_final_backendContext> options)
            : base(options)
        {
        }

        public DbSet<proyecto_final_backend.Models.Proveedor> Proveedor { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Compra> Compra { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Producto> Producto { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Componente> Componente { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Caracteristica> Caracteristica { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.CaracteristicaProducto> CaracteristicaProducto { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Garantia> Garantia { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ComponenteGarantia> ComponenteGarantia { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.Reparacion> Reparacion { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.ComponenteReparacion> ComponenteReparacion { get; set; } = default!;
        public DbSet<proyecto_final_backend.Models.DevolucionProducto> DevolucionProducto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.IdProveedor);

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
                .HasIndex(cp => new { cp.IdProducto, cp.IdCaracteristica })
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

            modelBuilder.Entity<Reparacion>()
                .HasIndex(r => r.UsuarioId);

            modelBuilder.Entity<Reparacion>()
                .HasIndex(r => r.VentaId);

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

            modelBuilder.Entity<DevolucionProducto>()
                .HasOne(dp => dp.Producto)
                .WithMany(p => p.DevolucionesProducto)
                .HasForeignKey(dp => dp.IdProducto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DevolucionProducto>()
                .HasIndex(dp => new { dp.IdProducto, dp.IdDevolucion })
                .IsUnique();
        }
    }
}
