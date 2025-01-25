using System;

namespace src.Domain
{
    public class Loan
    {
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public decimal Discount { get; set; }
        public decimal PaybackAmount { get; set; }
        public DateTime FundedDate { get; set; }
        public decimal PaymentDue { get; set; }
    }
}