using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace src.Infrastructure.Adapters.LoanManagment.Responses
{
public class CustomerData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public List<LoanData> LoanData { get; set; }
}

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