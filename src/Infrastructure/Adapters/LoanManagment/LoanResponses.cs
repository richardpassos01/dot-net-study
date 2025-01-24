using System;

namespace src.Infrastructure.Adapters.Responses
{
    public class LoanData
    {
        public string Id { get; set; }
        public int LoanId { get; set; }
        public string State { get; set; }
        public decimal ContractBalance { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime FundedDate { get; set; }
        public decimal AmountDue { get; set; }
    }
}