using System;
using System.Threading.Tasks;
using Bluekola.Api.Models.Auth;
using Bluekola.Api.Models.Common;
using Bluekola.Api.Models.Users;
using Bluekola.Filters;
using Bluekola.Maps;
using Bluekola.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bluekola.Server.RestAPI
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserOtpController : Controller
    {
        private readonly IUserOtpQueryProcessor _query;
        private readonly IAutoMapper _mapper;

        public UserOtpController(IUserOtpQueryProcessor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpPost("Send")]
        [ValidateModel]
        public async Task<IActionResult> Send([FromBody] RequestOtpModel model)
        {
            try
            {
                var result = await _query.Send(model.Phone);

                if (result)
                {
                    return Ok(new GenericResponse<object>(true, ResponseBase.SUCCESSFUL, null));
                }
                return Ok(new GenericResponse<object>(false, ResponseBase.FAILED, null));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<object>(false, ex.Message, null));
            }
        }

        [HttpPost("Validate")]
        [ValidateModel]
        public async Task<IActionResult> Validate([FromBody] ValidateOtpModel model)
        {
            try
            {
                var result = await _query.Validate(model.Phone, model.Otp);
                if (result)
                {
                    return Ok(new GenericResponse<object>(true, ResponseBase.SUCCESSFUL, null));
                }
                return Ok(new GenericResponse<object>(false, ResponseBase.FAILED, null));
            }
            catch (Exception ex)
            {
                return Ok(new GenericResponse<object>(false, ex.Message, null));
            }
        }
    }
}