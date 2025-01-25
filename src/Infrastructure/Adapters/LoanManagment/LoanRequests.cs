using System;

namespace src.Infrastructure.Adapters.LoanManagment.Requests;

public class CreateCustomerData
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public Guid UserId { get; set; }
}

public class CreateLoanData
{
    public Guid UserId { get; set; }
    public Guid ApplicationId { get; set; }
    public decimal LoanAmount { get; set; }
    public int loanTerm { get; set; }
}
