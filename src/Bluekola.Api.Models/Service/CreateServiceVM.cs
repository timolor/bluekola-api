using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Gallery
{
    public class CreateServiceVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gallery { get; set; }
        public string BannerUrl { get; set; }
        public string ServiceType { get; set; }
        public string Address { get; set; }
        public List<string> Tags { get; set; }
    }
}
