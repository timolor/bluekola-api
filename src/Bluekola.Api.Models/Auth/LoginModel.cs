using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Auth
{
    public class LoginModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}