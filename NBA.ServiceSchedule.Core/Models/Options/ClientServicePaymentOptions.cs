using System;
using System.Collections.Generic;

namespace NBA.ServiceSchedule.Core.Models.Options
{
    public class ClientServicePaymentOptions
    {
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public List<string> FilteredClientCodeList { get; set; }
        public List<string> FilteredServiceCodeList { get; set; }
    }
}
