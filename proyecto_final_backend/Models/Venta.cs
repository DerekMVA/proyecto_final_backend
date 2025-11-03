using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("ventas")]
    public class Venta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [Column("id_cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
        public ICollection<Devolucion> Devoluciones { get; set; } = new List<Devolucion>();
        public ICollection<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
        public OrdenEnsamble? OrdenEnsamble { get; set; }
        public ICollection<Garantia> Garantias { get; set; } = new List<Garantia>();
    }
}
