using System;
using System.Collections.Generic;

namespace Support.Models
{
    public partial class DepositRequests
    {
        public long Id { get; set; }
        public int ResultCode { get; set; }
        public string CheckoutRequestId { get; set; }
        public string ResultDesc { get; set; }
        public string MerchantRequestId { get; set; }
    }
}
