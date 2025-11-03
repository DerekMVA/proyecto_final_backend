using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("detalles_ventas")]
    public class DetalleVenta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("cantidad")]
        public byte Cantidad { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [Column("id_producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; } = null!;

        [Column("id_venta")]
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } = null!;
    }
}
