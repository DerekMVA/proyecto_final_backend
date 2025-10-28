using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        [MaxLength(30)]
        public required string Nombre { get; set; }
        [Required]
        [Column("codigo")]
        [MaxLength(20)]
        public required string Codigo { get; set; }
        [Required]
        [Column("precio")]
        public required decimal Precio { get; set; }
        [Required]
        [Column("stock")]
        public required byte Stock { get; set; }
        [Required]
        [Column("stock_minimo")]
        public required byte StockMinimo { get; set; }
        [Required]
        [Column("nuevo")]
        public required bool Nuevo { get; set; }
        [Required]
        [Column("tipo")]
        public required byte Tipo { get; set; }
        [Required]
        [Column("imagen")]
        public required string Imagen { get; set; }
        [Required]
        [Column("deleted")]
        public required bool Deleted { get; set; } = false;
    }
}
