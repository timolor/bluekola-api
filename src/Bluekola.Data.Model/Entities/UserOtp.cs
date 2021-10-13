using System;
using Bluekola.Data.Model.Common;

namespace Bluekola.Data.Model.Entities
{
    public class UserOtp : BaseEntity
    {
        public string Phone { get; set; }
        public string Otp { get; set; }
        public bool isUsed { get; set; }
        public DateTime DateCreated { get; set; }
    }
}