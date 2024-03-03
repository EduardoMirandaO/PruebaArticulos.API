using System.ComponentModel.DataAnnotations;

namespace PruebasArticulos.API.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedOn { get; set; }

       
        Users User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
