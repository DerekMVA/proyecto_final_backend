using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("ordenes_ensambles")]
    public class OrdenEnsamble
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio_ensamble")]
        public decimal PrecioEnsamble { get; set; }

        [Column("estado")]
        public byte Estado { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        [Column("id_venta")]
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } = null!;

        public ICollection<ComponenteOrden> Componentes { get; set; } = new List<ComponenteOrden>();
    }
}
