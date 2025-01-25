using System;
using System.Threading.Tasks;
using src.Application.Interfaces;
using src.Domain;

namespace src.Application.UseCases;

public class GetLoan
{
    private readonly ILoanManagementAdapter _loanManagementAdapter;

    public GetLoan(ILoanManagementAdapter loanManagementAdapter)
    {
        _loanManagementAdapter = loanManagementAdapter;
    }

    public async Task<Loan> Execute()
    {
        try
        {
            var loan = await _loanManagementAdapter.GetLoanByApplicationId();
            return loan;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}
