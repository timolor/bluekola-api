using System;
using System.Collections.Generic;
using System.Text;

namespace Bluekola.Api.Models.Domain
{
    public class SmsSettings
    {
        public string ClientUsername { get; set; }
        public string ClientPassword { get; set; }
        public string SenderName { get; set; }
    }
}