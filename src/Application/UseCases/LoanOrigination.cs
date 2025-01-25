using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using src.Application.Interfaces;
using src.Domain;
using src.Infrastructure.Repositories;

namespace src.Application.UseCases;

public class LoanOrigination
{
    private readonly ILoanManagementAdapter _loanManagementAdapter;
    private readonly ILoanApplicationRepository _loanApplicationRepository;

    public LoanOrigination(ILoanManagementAdapter loanManagementAdapter, ILoanApplicationRepository loanApplicationRepository)
    {
        _loanManagementAdapter = loanManagementAdapter;
        _loanApplicationRepository = loanApplicationRepository;
    }


    public async Task Execute(Guid ApplicationId, Guid UserId)
    {
        try
        {
            await this.CreateCustomer();

            bool isFundEligible = await this.CheckFundEligibility(UserId);

            if (!isFundEligible)
            {
                throw new Exception("The user has loans with open balance!");
            }

            await this.CreateInactiveLoan(ApplicationId, UserId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task CreateCustomer()
    {
        try
        {
            await _loanManagementAdapter.CreateCustomer();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task CreateInactiveLoan(Guid ApplicationId, Guid UserId)
    {
        try
        {
            var application = await _loanApplicationRepository.GetByIdAndUserId(ApplicationId, UserId);

            await _loanManagementAdapter.CreateInactiveLoan(application);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<bool> CheckFundEligibility(Guid UserId)
    {
        var MAXIMUM_BALANCE_AMOUNT_TO_ENABLE_RENEWAL = 5;

        bool isFundEligible = true;

        List<Loan> loans = await _loanManagementAdapter.ListActiveLoans(UserId);

        foreach (var loan in loans)
        {
            bool hasOpenBalance = loan.Balance > MAXIMUM_BALANCE_AMOUNT_TO_ENABLE_RENEWAL;

            if (hasOpenBalance)
            {
                isFundEligible = false;
            }
        }

        return isFundEligible;
    }
}
