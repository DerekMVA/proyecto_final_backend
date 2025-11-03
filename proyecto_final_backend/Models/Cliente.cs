using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre_completo")]
        [MaxLength(50)]
        public required string NombreCompleto { get; set; }

        [Column("correo")]
        [MaxLength(30)]
        public required string Correo { get; set; }

        [Column("telefono")]
        [MaxLength(14)]
        public required string Telefono { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }

        public Carrito? Carrito { get; set; }
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
