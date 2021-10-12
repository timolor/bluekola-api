using System.Linq;
using System.Threading.Tasks;
using Bluekola.Api.Models.Users;
using Bluekola.Data.Model;

namespace Bluekola.Queries.Queries
{
    public interface IUsersQueryProcessor
    {
        IQueryable<User> Get();
        User Get(int id);
        Task<User> Create(CreateUserModel model);
        Task<User> Update(int id, UpdateUserModel model);
        Task Delete(int id);
        Task ChangePassword(int id, ChangeUserPasswordModel model);
    }
}