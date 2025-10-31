using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("garantias")]
    public class Garantia
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Column("fecha")]
        public DateOnly Fecha { get; set; }

        [Column("estado")]
        public byte Estado { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        public ICollection<ComponenteGarantia> Componentes { get; set; } = new List<ComponenteGarantia>();
    }
}
