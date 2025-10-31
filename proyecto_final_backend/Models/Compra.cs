using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("compras")]
    public class Compra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("IdProveedor")]
        public required int IdProveedor { get; set; }
        public Proveedor? Proveedor { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
