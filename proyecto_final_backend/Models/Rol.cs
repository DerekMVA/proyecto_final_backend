using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        public required string Nombre { get; set; }

        [Column("descripcion")]
        [MaxLength(255)]
        public required string Descripcion { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
