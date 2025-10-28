using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("reparaciones")]
    public class Reparacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Venta")]
        [Column("id_venta")]
        public required int ReparacionId { get; set; }
        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public required int UsuarioId { get; set; }
        [Column("precio")]
        public required decimal Precio { get; set; }
        [Column("deleted")]
        public required bool Deleted { get; set; }
    }
}
