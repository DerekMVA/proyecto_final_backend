using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("carritos")]
    public class Carrito
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_cliente")]
        public required int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        [Required]
        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

    }
}
