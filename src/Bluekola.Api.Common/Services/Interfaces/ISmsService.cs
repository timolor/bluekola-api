using System.Threading.Tasks;
using Bluekola.Api.Models.SMS;

namespace Bluekola.Api.Common.Services.Interfaces
{
    public interface ISmsService
    {
        Task<bool> SendAsync(SmsRequest request);
    }
}