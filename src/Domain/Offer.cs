using System;

namespace src.Domain
{
    public class Offer
    {
        public string Id { get; set; }
        public decimal paybackAmount { get; set; }
        public int paymentTerms { get; set; }
    }
}