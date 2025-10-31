using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombre")]
        [MaxLength(30)]
        public required string Nombre { get; set; }
        [Column("codigo")]
        [MaxLength(20)]
        public required string Codigo { get; set; }
        [Column("precio")]
        public decimal Precio { get; set; }
        [Column("stock")]
        public byte Stock { get; set; }
        [Column("stock_minimo")]
        public byte StockMinimo { get; set; }
        [Column("nuevo")]
        public bool Nuevo { get; set; }
        [Column("tipo")]
        public byte Tipo { get; set; }
        [Column("imagen")]
        [MaxLength(255)]
        public required string Imagen { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        public ICollection<Componente> ComponentesPrincipales { get; set; } = new List<Componente>();
        public ICollection<Componente> ComponentesSecundarios { get; set; } = new List<Componente>();
        public ICollection<CaracteristicaProducto> CaracteristicasProducto { get; set; } = new List<CaracteristicaProducto>();
        public ICollection<ComponenteGarantia> ComponentesGarantias { get; set; } = new List<ComponenteGarantia>();
        public ICollection<ComponenteReparacion> ComponentesReparaciones { get; set; } = new List<ComponenteReparacion>();
        public ICollection<DevolucionProducto> DevolucionesProducto { get; set; } = new List<DevolucionProducto>();
    }
}
