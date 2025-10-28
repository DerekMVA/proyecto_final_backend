using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [Required]
        [Column("nombre_contacto")]
        public required string NombreContacto { get; set; }

        [Required]
        [Column("telefono")]
        public required string Telefono { get; set; }

        [Required]
        [Column("correo")]
        public required string Correo { get; set; }

        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; } = false;


    }

}