using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using src.Application.Interfaces;
using src.Domain;

namespace src.Application.UseCases
{
    public class LoanOrigination
    {
        private readonly ILoanManagementAdapter _loanManagementAdapter;

        public LoanOrigination(ILoanManagementAdapter loanManagementAdapter)
        {
            _loanManagementAdapter = loanManagementAdapter;
        }

        public async Task Execute(string applicationId, string userId)
        {
            try
            {
                await this.CreateCustomer();

                bool isFundEligible = await this.CheckFundEligibility();

                if (!isFundEligible)
                {
                    throw new Exception("The user has loans with open balance!");
                }

                await this.CreateInactiveLoan();
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

        private async Task CreateInactiveLoan()
        {
            try
            {
                var offer = new Offer
                {
                    Id = Guid.NewGuid(),
                    PaybackAmount = 1000,
                    PaymentTerms = 12
                };

                var application = new LoanApplication
                {
                     Id = Guid.NewGuid(),
                     UserId = Guid.NewGuid(),
                     OfferId = offer.Id,
                };

                await _loanManagementAdapter.CreateInactiveLoan(application);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<bool> CheckFundEligibility()
        {
            var userId = Guid.NewGuid();
            var MAXIMUM_BALANCE_AMOUNT_TO_ENABLE_RENEWAL = 5;

            bool isFundEligible = true;

            List<Loan> loans = await _loanManagementAdapter.ListActiveLoans(userId);

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
}