using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("ordenes_ensambles")]
    public class OrdenEnsamble
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_usuario")]
        public required int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("id_venta")]
        public required int IdVenta { get; set; }
        public Venta? Venta { get; set; }

        [Required]
        [Column("estado")]
        public byte Estado { get; set; }

        [Required]
        [Column("precio_ensamble")] // Precio del ensamble, mano de obra
        public decimal PrecioEnsamble { get; set; }

        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; } = false;
    }
}
