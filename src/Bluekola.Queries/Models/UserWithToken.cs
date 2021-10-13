using System;
using Bluekola.Data.Model;
using Bluekola.Data.Model.Entities;

namespace Bluekola.Queries.Models
{
    public class UserWithToken
    {
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}