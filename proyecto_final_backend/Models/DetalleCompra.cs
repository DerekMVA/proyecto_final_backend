using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("detalles_compras")]
    public class DetalleCompra
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

        [Column("id_compra")]
        public int IdCompra { get; set; }
        public Compra Compra { get; set; } = null!;
    }
}
