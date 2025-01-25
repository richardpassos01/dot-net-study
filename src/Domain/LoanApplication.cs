using System;

namespace src.Domain
{
    public class LoanApplication
    {
        public string Id { get; set; }
        public string userId { get; set; }
        public Offer offer { get; set; }
    }
}