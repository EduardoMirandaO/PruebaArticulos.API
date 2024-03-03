using System.ComponentModel.DataAnnotations;

namespace PruebasArticulos.API.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Department { get; set; }

    }
}

