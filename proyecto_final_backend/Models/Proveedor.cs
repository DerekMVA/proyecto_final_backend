using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyecto_final_backend.Models
{
    [Table("proveedores")]
    [Index(nameof(Correo), IsUnique = true)]
    [Index(nameof(Telefono), IsUnique = true)]
    public class Proveedor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [MaxLength(30)]
        public required string Nombre { get; set; }

        [Column("nombre_contacto")]
        [MaxLength(30)]
        public required string NombreContacto { get; set; }

        [Column("correo")]
        [MaxLength(30)]
        public required string Correo { get; set; }

        [Column("telefono")]
        [MaxLength(14)]
        public required string Telefono { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}