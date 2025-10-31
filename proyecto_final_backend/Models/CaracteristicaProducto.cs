using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("caracteristicas_productos")]
    public class CaracteristicaProducto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("id_caracteristica")]
        public int IdCaracteristica { get; set; }

        public Producto Producto { get; set; } = null!;
        public Caracteristica Caracteristica { get; set; } = null!;
    }
}
