using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("garantias")]
    public class Garantia
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public required int IdUsuario { get; set; }
        [ForeignKey("Venta")]
        [Column("id_venta")]
        public required int IdVenta { get; set; }
        [Required]
        [Column("fecha")]
        public required DateOnly Fecha { get; set; }
        [Required]
        [Column("estado")]
        public required byte Estado { get; set; }
        [Required]
        [Column("deleted")]
        public required bool Deleted { get; set; } = false;
    }
}
