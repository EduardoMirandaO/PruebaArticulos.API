using System.ComponentModel.DataAnnotations;

namespace PruebasArticulos.API.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }


        ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }

        Products Product { get; set; }
        public int ProductId { get; set; }
    }
}
