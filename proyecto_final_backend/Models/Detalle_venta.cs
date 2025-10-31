using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("detalles_ventas")]
    public class Detalle_venta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_venta")]
        public required int IdVenta { get; set; }
        public Venta? Venta { get; set; }

        [ForeignKey("id_producto")]
        public required int IdProducto { get; set; }
        public Producto? Producto { get; set; }

        [Required]
        [Column("cantidad")]
        public Byte Cantidad { get; set; }

        [Required]
        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
