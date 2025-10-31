using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_cliente")]
        public required int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("id_usuario")]

        [Required]
        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Required]
        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
