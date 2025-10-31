using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("detalle_compras")]
    public class DetalleCompra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("cantidad")]
        public required byte Cantidad { get; set; }

        [Required]
        [Column("precio")]
        public required decimal Precio { get; set; }

        [ForeignKey("id_compra")]
        public required int IdCompra { get; set; }
        public required Compra Compra { get; set; }

        [ForeignKey("id_producto")]
        public required int IdProducto { get; set; }  
        public required Producto Producto { get; set; }

    }
}
