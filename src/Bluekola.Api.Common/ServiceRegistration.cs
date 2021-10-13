using Bluekola.Api.Common.Services;
using Bluekola.Api.Common.Services.Interfaces;
using Bluekola.Api.Models.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bluekola.Api.Common
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<SmsSettings>(_config.GetSection("SmsSettings"));
            services.AddTransient<ISmsService, SmsService>();
        }
    }
}