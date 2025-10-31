using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [Required]
        [Column("descripcion")]
        public required string Descripcion { get; set; }

        [Required]
        [Column("deleted")]
        public required bool Deleted { get; set; }

    }
}
