using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("devoluciones_productos")]
    public class DevolucionProducto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("id_devolucion")]
        public int IdDevolucion { get; set; }

        public Producto Producto { get; set; } = null!;
        public Devolucion Devolucion { get; set; } = null!;
    }
}
