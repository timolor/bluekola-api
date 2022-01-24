using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.Gallery
{
    public class GalleryUpload
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}