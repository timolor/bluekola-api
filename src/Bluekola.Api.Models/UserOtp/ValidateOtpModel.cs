using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Users
{
    public class ValidateOtpModel
    {
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Otp { get; set; }
    }
}