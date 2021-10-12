using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}