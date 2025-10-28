using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes_reparaciones")]
    public class ComponenteReparacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Producto")]
        [Column("id_producto")]
        public int IdProduto { get; set; }
        [ForeignKey("Reparacion")]
        [Column("id_reparacion")]
        public int IdReparacion { get; set; }
        [Required]
        [Column("precio")]
        public required decimal precio { get; set; }
        [Required]
        [Column("cantidad")]
        public required byte cantidad { get; set; }
    }
}
