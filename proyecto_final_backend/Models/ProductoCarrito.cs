using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("productos_carritos")]
    public class ProductoCarrito
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_carrito")]
        public required int IdCarrito { get; set; }
        public Carrito? Carrito { get; set; }
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
