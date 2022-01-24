using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bluekola.Api.Common.Exceptions;
using Bluekola.Api.Models.Gallery;
using Bluekola.Data.Access.DAL;
using Bluekola.Data.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluekola.Queries.Queries
{
    public class ServiceQueryProcessor : IServiceQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public ServiceQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddRate(AddRateVM model, string userId)
        {
            var service = GetServiceQuery().FirstOrDefault(x => x.Id.Equals(model.ServiceId));
            if (service == null)
            {
                // throw new NotFoundException(string.Format("Service with id {0} does not exist", model.ServiceId));
                 throw new NotFoundException("Service does not exist");
            }

            Rate rate = new Rate {
                Name = model.Name,
                Amount = model.Amount,
                ServiceId = model.ServiceId,
                CreatedBy = int.Parse(userId),
                Created = DateTime.UtcNow.AddHours(1),
            };

            _uow.Add(rate);
            await _uow.CommitAsync();
        }

        public async Task Create(CreateServiceVM model, string userId)
        {

            Service service = new Service
            {
                Name = model.Name,
                Description = model.Description,
                BannerUrl = model.BannerUrl,
                ServiceType = model.ServiceType,
                Tags = string.Join(",", model.Tags),
                Gallery = model.Gallery,
                Address = model.Address,
                CreatedBy = int.Parse(userId),
                Created = DateTime.UtcNow.AddHours(1),
            };

            _uow.Add(service);
            await _uow.CommitAsync();
        }

        public Task Delete(int serviceId)
        {
            var service = GetServiceQuery().FirstOrDefault(x => x.Id.Equals(serviceId));
            if (service == null)
            {
                // throw new NotFoundException(string.Format("Service with id {0} does not exist", serviceId));
                throw new NotFoundException("Service does not exist");
            }

            return null;
        }

        public Service Get(int Id, string userId)
        {
            var service = GetServiceWithRatesAndUserQuery().FirstOrDefault(x => x.Id.Equals(Id));
            // service.User = _uow.Query<User>().FirstOrDefault(x => x.Id.Equals(int.Parse(userId)));
            // var service = GetServiceQuery().FirstOrDefault(x => x.Id.Equals(Id));
            // service.Rates = GetRateQuery().Where(x => x.ServiceId.Equals(Id)).ToList();
            if (service == null)
            {
                // throw new NotFoundException(string.Format("Service with id {0} does not exist", Id));
                throw new NotFoundException("Service does not exist");
            }

            return service;
        }

        public List<Service> Get()
        {
            var services = GetServiceQuery().ToList();
            return services;
        }

        public async Task<int> SaveToGallery(string imageUrl)
        {
            Gallery gallery = new Gallery
            {
                ImageUrl = imageUrl
            };
            _uow.Add(gallery);
            await _uow.CommitAsync();
            return gallery.Id;
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }

        private IQueryable<Service> GetServiceWithRatesAndUserQuery()
        {
            return _uow.Query<Service>()
                .Include(x => x.Rates)
                .Include(x => x.User);
        }

        private IQueryable<Service> GetServiceQuery()
        {
            return _uow.Query<Service>();
        }

        private IQueryable<Rate> GetRateQuery()
        {
            return _uow.Query<Rate>();
        }
    }
}