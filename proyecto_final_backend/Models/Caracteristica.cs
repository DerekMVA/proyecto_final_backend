using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("caracteristicas")]
    public class Caracteristica
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("tipo")]
        [MaxLength(50)]
        public required string Tipo { get; set; }

        [Column("descripcion")]
        [MaxLength(255)]
        public required string Descripcion { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        public ICollection<CaracteristicaProducto> CaracteristicasProducto { get; set; } = new List<CaracteristicaProducto>();
    }
}
