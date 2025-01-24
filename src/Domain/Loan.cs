using System;

namespace src.Domain.Loan
{
    public class Loan
    {
        public string Id { get; set; }
        public int LoanId { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public decimal Discount { get; set; }
        public decimal PaybackAmount { get; set; }
        public DateTime FundedDate { get; set; }
        public decimal PaymentDue { get; set; }
    }
}