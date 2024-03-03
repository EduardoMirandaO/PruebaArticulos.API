using Microsoft.EntityFrameworkCore;

namespace PruebasArticulos.API.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
