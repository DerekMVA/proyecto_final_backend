using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [Required]
        [Column("telefono")]
        public required string Telefono { get; set; }

        [Required]
        [Column("correo")]
        public required string Correo { get; set; }

        [Required]
        [Column("deleted")]
        public required bool Deleted { get; set; }

    }
}
