using System.Collections.Generic;
using System.Threading.Tasks;
using Bluekola.Api.Models.Gallery;
using Bluekola.Data.Model.Entities;

namespace Bluekola.Queries.Queries
{
    public interface IServiceQueryProcessor
    {
        Service Get(int Id, string userId);
        List<Service> Get();
        Task Create(CreateServiceVM model, string userId);
        Task Update();
        Task Delete(int id);
        Task AddRate(AddRateVM model, string userId);
    }
}