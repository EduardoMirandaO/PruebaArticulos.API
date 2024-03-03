using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasArticulos.API.Models;

namespace PruebasArticulos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly Context dbContext;

        public UsersController(Context _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<Users> users = dbContext.Users.ToList();

                if (users.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to retrieve users. Details: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] Users user)
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return Ok($"The user {user.FirstName} {user.LastName} has been saved.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to save {user.FirstName} {user.LastName} user. Details: {ex.Message}");
            }
        }


        [HttpDelete]
        public IActionResult DeleteUserById(int UserId)
        {
            Users findedUser = dbContext.Users.FirstOrDefault(x => x.Id == UserId);
            if (findedUser == null)
            {
                return NotFound($"The user was not found.");
            }

            try
            {
                dbContext.Users.Remove(findedUser);
                dbContext.SaveChanges();
                return Ok($"The User {findedUser.FirstName} has been deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred when trying to delete {findedUser.FirstName} user. Details: {ex.Message}");
            }
        }
    }
}
