using System.ComponentModel.DataAnnotations;

namespace tienda_comics.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public double precio { get; set; }
        public int existencia { get; set; }
        public string genero { get; set; } = string.Empty;
        public string fabricante { get; set; } = string.Empty;
        public string proveedor { get; set; } = string.Empty;
        public string tipo { get; set; } = string.Empty;
    }

    public class ProductoCreateModel
    {
        [Required(ErrorMessage ="El campo 'nombre' es necesario")]
        public string nombre { get; set; } = string.Empty;
        [Required(ErrorMessage ="El campo 'precio' es requerido'")]
        [Range(1.00, double.MaxValue, ErrorMessage ="El precio minimo debe ser 1")]
        public double precio { get; set; }
        [Required(ErrorMessage = "El campo 'existencia' es requerido'")]
        [Range(1, int.MaxValue, ErrorMessage ="La existencia minima debe ser 1")]
        public int existencia { get; set; }
        [Required(ErrorMessage = "El campo 'genero' es requerido'")]
        public string genero { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo 'fabricante' es requerido'")]
        public string fabricante { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo 'proveedor' es requerido'")]
        public string proveedor { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo 'tipo' es requerido'")]
        public string tipo { get; set; } = string.Empty;
    }
}
