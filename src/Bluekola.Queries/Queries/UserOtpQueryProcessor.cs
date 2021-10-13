using System;
using System.Linq;
using System.Threading.Tasks;
using Bluekola.Api.Common.Exceptions;
using Bluekola.Api.Common.Services.Interfaces;
using Bluekola.Api.Models.Auth;
using Bluekola.Api.Models.SMS;
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
    public class UserOtpQueryProcessor : IUserOtpQueryProcessor
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly ISmsService _smsService;
        private readonly ISecurityContext _context;
        private Random _random;

        string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public UserOtpQueryProcessor(IUnitOfWork uow, ISmsService smsService)
        {
            _random = new Random();
            _uow = uow;
            _smsService = smsService;
        }

        public async Task<bool> Send(string phone)
        {
            UserOtp userOtp;
            string otp = GenerateRandomOTP(5, saAllowedCharacters);
            string message = string.Format("Hello, your One-Time-Password (OTP) to register is: {0}.", otp);

            SmsRequest request = new SmsRequest(phone, message);

            var resp = await _smsService.SendAsync(request);

            userOtp = GetQuery()
                .FirstOrDefault(x => x.Phone.Equals(phone));

            if (userOtp != null)
            {
                userOtp.DateCreated = DateTime.UtcNow;
                userOtp.Otp = otp;
                userOtp.isUsed = false;
            }
            else
            {
                userOtp = new UserOtp
                {
                    DateCreated = DateTime.UtcNow,
                    Phone = phone,
                    Otp = otp
                };
                _uow.Add(userOtp);
            }
            await _uow.CommitAsync();

            return resp;
        }

        public async Task<bool> Validate(string phone, string otp)
        {
            UserOtp userOtp = GetQuery().FirstOrDefault(u => u.Phone == phone.Trim());
   
            if (userOtp == null)
            {
                throw new BadRequestException("Invalid/Expired OTP");
            }

            if(userOtp != null && userOtp.isUsed){
                throw new BadRequestException("Invalid/Expired OTP");
            }
            
            if(userOtp != null && !userOtp.Otp.Equals(otp)){
                throw new BadRequestException("Invalid/Expired OTP");
            }
            
            userOtp.isUsed = true;
            await _uow.CommitAsync();

            return true;
        }

        private IQueryable<UserOtp> GetQuery()
        {
            return _uow.Query<UserOtp>();
        }

        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        {
            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;
        }
    }
}