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
}
