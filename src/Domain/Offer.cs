using System;

namespace src.Domain;
public class Offer
{
    public Guid Id { get; set; }
    public decimal PaybackAmount { get; set; }
    public int PaymentTerms { get; set; }
}
