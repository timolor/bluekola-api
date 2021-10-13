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
    public class AuthController : Controller
    {
        private readonly ILoginQueryProcessor _query;
        private readonly IAutoMapper _mapper;

        public AuthController(ILoginQueryProcessor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpPost("Authenticate")]
        [ValidateModel]
        public GenericResponse<UserWithTokenModel> Authenticate([FromBody] LoginModel model)
        {
            var result = _query.Authenticate(model.Phone, model.Password);

            var resultModel = _mapper.Map<UserWithTokenModel>(result);

            return new GenericResponse<UserWithTokenModel>(true, ResponseBase.SUCCESSFUL ,resultModel);
        }

        [HttpPost("Register")]
        [ValidateModel]
        public async Task<GenericResponse<UserModel>> Register([FromBody] RegisterModel model)
        {
            var result = await _query.Register(model);
            var resultModel = _mapper.Map<UserModel>(result);
            //return resultModel;
            return new GenericResponse<UserModel>(true, ResponseBase.SUCCESSFUL ,resultModel);
        }

        [HttpPost("Password")]
        [ValidateModel]
        [Authorize]
        public async Task ChangePassword([FromBody]ChangeUserPasswordModel requestModel)
        {
            await _query.ChangePassword(requestModel);
        }
    }
}