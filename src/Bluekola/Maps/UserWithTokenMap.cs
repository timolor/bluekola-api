using System.Linq;
using AutoMapper;
using Bluekola.Api.Models.Users;
using Bluekola.Data.Model;
using Bluekola.Queries.Models;

namespace Bluekola.Maps
{
    public class UserWithTokenMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<UserWithToken, UserWithTokenModel>();
        }
    }
}