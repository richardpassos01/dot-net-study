using System;

namespace src.Domain;
public class LoanApplication
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; }
}
