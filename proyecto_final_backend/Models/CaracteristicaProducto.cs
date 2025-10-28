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
        [ForeignKey("Producto")]
        [Column("id_producto")]
        public required int IdProducto { get; set; }
        [ForeignKey("Caracteristica")]
        [Column("id_caracteristica")]
        public required int IdCaracteristica { get; set; }
    }
}
