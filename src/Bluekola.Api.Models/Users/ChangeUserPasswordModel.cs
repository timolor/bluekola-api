using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Users
{
    public class ChangeUserPasswordModel
    {
        [Required]
        public string Password { get; set; }
    }
}