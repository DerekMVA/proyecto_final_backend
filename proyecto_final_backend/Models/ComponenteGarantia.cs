using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes_garantias")]
    public class ComponenteGarantia
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Producto")]
        [Column("id_producto")]
        public int IdProducto { get; set; }
        [ForeignKey("Garantia")]
        [Column("id_garantia")]
        public int IdGarantia { get; set; }
        [Required]
        [Column("cantidad")]
        public byte Cantidad { get; set; }
    }
}
