using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("reparaciones")]
    public class Reparacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        [Column("id_venta")]
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } = null!;

        public ICollection<ComponenteReparacion> Componentes { get; set; } = new List<ComponenteReparacion>();
    }
}
