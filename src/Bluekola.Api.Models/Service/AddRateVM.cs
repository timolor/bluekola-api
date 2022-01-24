using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Gallery
{
    public class AddRateVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ServiceId { get; set; }
    }
}

