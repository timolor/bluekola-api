using System;
using System.IO;
using System.Threading.Tasks;
using Bluekola.Api.Models.Common;
using Bluekola.Api.Models.Gallery;
using Bluekola.Data.Access.DAL;
using Bluekola.Filters;
using Bluekola.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bluekola.Server.RestAPI
{
    [Route("api/[controller]")]
    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IGalleryQueryProcessor _query;

        public GalleryController(IGalleryQueryProcessor query)
        {
            _query = query;
        }

        [HttpPost("upload-banner")]
        public async Task<IActionResult> UploadBanner([FromForm(Name = "uploadedFile")] IFormFile file)
        {

            try
            {
                Random random = new Random();
                if (file == null || file.Length == 0)
                {
                    return Ok(new GenericResponse<string>(false, "Please select banner", "Please select banner"));
                }

                var folderName = Path.Combine("Resources", "Banners");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var uniqueFileName = $"{User.Identity.Name}_{DateTime.UtcNow.AddHours(1).ToString("ddMMyyyyhhmmss")}_{random.Next(10, 50)}.png";
                var dbPath = Path.Combine(folderName, uniqueFileName);

                using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(new GenericResponse<string>(true, ResponseBase.SUCCESSFUL, dbPath.Replace(@"\\", @"\").Replace("Resources", "Assets")));
            }

            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(true, ex.Message, null));
            }
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm(Name = "uploadedFile")] IFormFile file)
        {
            try
            {
                string baseUrl = "http://api.bluekola.com//";
                Random random = new Random();
                if (file == null || file.Length == 0)
                {
                    return Ok(new GenericResponse<string>(false, "Please select banner", "Please select banner"));
                }

                var folderName = Path.Combine("Resources", "Banners");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var uniqueFileName = $"{User.Identity.Name}_{DateTime.UtcNow.AddHours(1).ToString("ddMMyyyyhhmmss")}_{random.Next(10, 50)}.png";
                var dbPath = Path.Combine(folderName, uniqueFileName);

                using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                string imagePath = dbPath.Replace(@"\\", @"\").Replace("Resources", "Assets");
                GalleryUpload gallery = new GalleryUpload
                {
                    ImageUrl = baseUrl + imagePath,
                    Id = await _query.SaveToGallery(imagePath)
                };

                return Ok(new GenericResponse<GalleryUpload>(true, ResponseBase.SUCCESSFUL, gallery));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(true, ex.Message, null));
            }
        }

    }
}