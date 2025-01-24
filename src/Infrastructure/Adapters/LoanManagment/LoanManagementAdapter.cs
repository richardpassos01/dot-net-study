using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using src.Domain;
using System.Net.Http.Json;
using src.Infrastructure.Adapters.Responses;

namespace src.Infrastructure.Adapters
{
    public class LoanManagementAdapter : ILoanManagementAdapter
    {
        private readonly HttpClient _httpClient;

        public LoanManagementAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Loan> GetLoanByApplicationId()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:3000/loans?loanId=1");
                response.EnsureSuccessStatusCode();

                var loanDataList = await response.Content.ReadFromJsonAsync<List<LoanData>>();
                var loanData = loanDataList[0];

                return new Loan
                {
                    Id = loanData.Id,
                    LoanId = loanData.LoanId,
                    IsActive = loanData.State == "active",
                    Balance = loanData.ContractBalance,
                    Discount = loanData.DiscountAmount,
                    PaybackAmount = loanData.LoanAmount,
                    FundedDate = loanData.FundedDate,
                    PaymentDue = loanData.AmountDue
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}