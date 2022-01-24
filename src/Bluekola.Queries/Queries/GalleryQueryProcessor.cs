using System;
using System.Linq;
using System.Threading.Tasks;
using Bluekola.Api.Common.Exceptions;
using Bluekola.Api.Models.Auth;
using Bluekola.Api.Models.Users;
using Bluekola.Data.Access.DAL;
using Bluekola.Data.Access.Helpers;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;
using Bluekola.Queries.Models;
using Bluekola.Security;
using Bluekola.Security.Auth;
using Microsoft.EntityFrameworkCore;

namespace Bluekola.Queries.Queries
{
    public class GalleryQueryProcessor : IGalleryQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public GalleryQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
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
    }
}