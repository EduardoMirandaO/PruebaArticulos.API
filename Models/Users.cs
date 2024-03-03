using System.ComponentModel.DataAnnotations;

namespace PruebasArticulos.API.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean isAdmin {get; set; }
        public string email { get; set; }
        public string Password { get; set; }

    }
}
