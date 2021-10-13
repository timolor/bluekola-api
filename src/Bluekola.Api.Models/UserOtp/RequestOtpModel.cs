using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Users
{
    public class RequestOtpModel
    {
        [Required]
        public string Phone { get; set; }
    }
}