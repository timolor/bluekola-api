using System.ComponentModel.DataAnnotations;

namespace Bluekola.Api.Models.SMS
{
    public class SmsRequest
    {
        public SmsRequest(){}
        public SmsRequest(string phone, string message){
            Phone = phone;
            Message = message;
        }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
    }
}