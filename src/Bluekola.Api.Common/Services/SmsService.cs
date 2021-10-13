using Bluekola.Api.Common.Exceptions;
using Bluekola.Api.Common.Services.Interfaces;
using Bluekola.Api.Models.Domain;
using Bluekola.Api.Models.SMS;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bluekola.Api.Common.Services
{
    public class SmsService : ISmsService
    {
        public SmsSettings _smsSettings { get; }
        public ILogger<SmsService> _logger { get; }

        private const string BASE_URL = "https://portal.nigeriabulksms.com/";

        public SmsService(IOptions<SmsSettings> smsSettings, ILogger<SmsService> logger)
        {
            _smsSettings = smsSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendAsync(SmsRequest request)
        {
            try
            {
                var response = string.Empty;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URL);

                    HttpResponseMessage result = await client.GetAsync(
                        string.Format("api/?username={0}&password={1}&message={2}&sender={3}&mobiles={4}",
                        _smsSettings.ClientUsername, _smsSettings.ClientPassword, request.Message, _smsSettings.SenderName, request.Phone));
                    if (result.IsSuccessStatusCode)
                    {
                        response = await result.Content.ReadAsStringAsync();
                        var smsResponse = (SmsResponse)JsonConvert.DeserializeObject(response ,typeof(SmsResponse));
                        if(smsResponse.status.Equals("OK")){
                            return true;
                        }

                        return false;
                    }
                }
                return false;


            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new System.SystemException(ex.Message);
            }
        }
    }
}