using Microsoft.AspNetCore.Mvc;
using PruebasArticulos.API.Models;

namespace PruebasArticulos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Context dbContext;

        public ProductsController(Context _dbContext) { 
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                List<Products> products = dbContext.Products.ToList();

                if (products.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to retrieve products. Details: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name))
            {
                return BadRequest("Invalid product data.");
            }

            try
            {
                product.Name = product.Name.ToUpper();
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return Ok($"The product {product.Name} has been saved.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to save {product.Name} product. Details: {ex.Message}");
            }
        }


        [HttpDelete]
        public IActionResult DeleteProductById(int ProductId)
        {
            Products findedItem = dbContext.Products.FirstOrDefault(x => x.Id == ProductId);
            if (findedItem == null)
            {
                return NotFound($"The product was not found.");
            }

            try
            {
                dbContext.Products.Remove(findedItem);
                dbContext.SaveChanges();
                return Ok($"The product {findedItem.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to delete {findedItem.Name} product. Details: {ex.Message}");
            }
        }

    }
}
