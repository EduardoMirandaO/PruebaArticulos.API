using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasArticulos.API.Models;

namespace PruebasArticulos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly Context dbContext;

        public ShoppingCartController(Context _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetShoppingCarts()
        {
            try
            {
                List<ShoppingCart> carts = dbContext.shoppingCarts.Include(sc => sc.ShoppingCartItems).ToList();

                if (carts.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(carts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to retrieve the shopping carts. Details: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult CreateShoppingCart([FromBody] ShoppingCart cart)
        {
            if (cart.ShoppingCartItems.Count == 0)
            {
                return BadRequest("Cannot create a cart with no items.");
            }
            if (cart.UserId == 0)
            {
                return BadRequest("Cannot create a cart without a user.");
            }

            try
            {
                dbContext.shoppingCarts.Add(cart);
                dbContext.SaveChanges();
                return Ok($"The Shopping cart has been created.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to save the shopping cart");
            }
        }


        [HttpDelete]
        public IActionResult DeleteShoppingCartById(int ShoppingCartId)
        {
            ShoppingCart findedShoppingCart = dbContext.shoppingCarts.FirstOrDefault(x => x.Id == ShoppingCartId);
            if (findedShoppingCart == null)
            {
                return NotFound($"The ShoppingCart was not found.");
            }

            try
            {
                dbContext.shoppingCarts.Remove(findedShoppingCart);
                dbContext.SaveChanges();
                return Ok($"The shopping cart has been deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to delete the shopping cart. Details: {ex.Message}");
            }
        }

    }
}
