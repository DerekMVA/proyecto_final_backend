using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace proyecto_final_backend.Models
{
    [Table("compras")]
    public class Compra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("IdProveedor")]
        public required Proveedor Proveedor { get; set; }

        [Required]
        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Required]
        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Required]
        [Column("deleted")]

    }
}
