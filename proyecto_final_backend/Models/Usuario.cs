using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre_completo")]
        public required string NombreCompleto { get; set; }

        [Required]
        [Column("usuario")]
        public required string UsuarioNombre { get; set; }

        [Required]
        [Column("contrasena")]
        public required string Contrasena { get; set; }

        [ForeignKey("IdRol")]
        public required int idRol { get; set; }
        public required Rol Rol { get; set; }

        [Required]
        [Column("salario")]
        public required decimal Salario { get; set; }

        [Required]
        [Column("deleted")]
        public required bool Deleted { get; set; }


    }
}
