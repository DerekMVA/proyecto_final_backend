using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("caracteristicas")]
    public class Caracteristica
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("tipo")]
        [MaxLength(50)]
        public required string Tipo { get; set; }
        [Required]
        [Column("descripcion")]
        [MaxLength(255)]
        public required string Descripcion { get; set; }
        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
