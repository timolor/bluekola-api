using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Bluekola.Api.Models.Common;
using Bluekola.Api.Models.Gallery;
using Bluekola.Data.Access.DAL;
using Bluekola.Data.Model.Entities;
using Bluekola.Filters;
using Bluekola.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bluekola.Server.RestAPI
{
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceQueryProcessor _query;

        public ServiceController(IServiceQueryProcessor query)
        {
            _query = query;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceVM model)
        {

            try
            {
                string userId = User.Identity.Name;
                await _query.Create(model, userId);
                return Ok(new GenericResponse<string>(true, "Service created successfully", null));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(false, ex.Message, null));
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Service> services = _query.Get();
                return Ok(new GenericResponse<List<Service>>(true, ResponseBase.SUCCESSFUL, services));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(false, ex.Message, null));
            }

        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] int Id)
        {
            try
            {
                string userId = User.Identity.Name;
                Service service = _query.Get(Id, userId);
                return Ok(new GenericResponse<Service>(true, ResponseBase.SUCCESSFUL, service));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(false, ex.Message, null));
            }

        }

        [HttpPost("rate")]
        public async Task<IActionResult> AddRate([FromBody] AddRateVM model)
        {
            try
            {
                string userId = User.Identity.Name;
                await _query.AddRate(model, userId);
                return Ok(new GenericResponse<string>(true, "Rate added successfully", null));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(false, ex.Message, null));
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _query.Delete(id);
                return Ok(new GenericResponse<string>(true, "Service deleted successfully", null));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<string>(false, ex.Message, null));
            }

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

    }
}