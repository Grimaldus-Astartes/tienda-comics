using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tienda_comics.Data_Entities
{
    [Table("producto")]
    public class ProductoEntity
    {
        [Key]
        [Column("id_producto")]
        public int idProducto { get; set; }
        public string nombre { get; set; } = string.Empty;
        public decimal precio { get; set; }
        public int existencia { get; set; }
        public string genero { get; set; } = string.Empty;
        public string fabricante { get; set; } = string.Empty;
        public string proveedor { get; set; } = string.Empty;
        public string tipo { get; set; } = string.Empty;
    }
}
