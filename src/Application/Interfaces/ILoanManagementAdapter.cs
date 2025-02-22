using System;
using System.Threading.Tasks;
using src.Domain;
using System.Collections.Generic;

namespace src.Application.Interfaces;
public interface ILoanManagementAdapter
{
    Task<Loan> GetLoanByApplicationId();
    Task CreateCustomer();
    Task CreateInactiveLoan(LoanApplication application);
    Task<List<Loan>> ListActiveLoans(Guid userId);
}
