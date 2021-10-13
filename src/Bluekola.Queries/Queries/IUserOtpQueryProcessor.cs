using System.Threading.Tasks;
using Bluekola.Api.Models.Auth;
using Bluekola.Api.Models.Users;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;
using Bluekola.Queries.Models;

namespace Bluekola.Queries.Queries
{
    public interface IUserOtpQueryProcessor
    {
        Task<bool> Send(string phone);
        Task<bool> Validate(string phone, string otp);
    }
}