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

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        public Proveedor Proveedor { get; set; } = null!;

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
