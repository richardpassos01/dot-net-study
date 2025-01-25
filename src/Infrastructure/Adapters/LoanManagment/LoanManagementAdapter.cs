using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using src.Domain;
using System.Net.Http.Json;
using src.Infrastructure.Adapters.LoanManagment.Responses;
using src.Application.Interfaces;
using src.Infrastructure.Adapters.LoanManagment.Endpoints;
using src.Infrastructure.Adapters.LoanManagment.Requests;

namespace src.Infrastructure.Adapters
{
    public class LoanManagementAdapter : ILoanManagementAdapter
    {
        private readonly HttpClient _httpClient;

        public LoanManagementAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var host = Environment.GetEnvironmentVariable("ADAPTER_HOST");
            _httpClient.BaseAddress = new Uri(host);
        }

        public async Task<Loan> GetLoanByApplicationId()
        {
            try
            {
                var response = await _httpClient.GetAsync(Endpoints.GET_LOAN.Replace(":applicationId", "1"));
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

        public async Task CreateCustomer()
        {
            try
            {
                var createCustomerData = new CreateCustomerData
                {
                    Name = "John Doe",
                    Email = "john.doe@gmail.com",
                    Phone = "1234567890",
                    Address = "1234 Main St"
                };

                var response = await _httpClient.PostAsJsonAsync(Endpoints.CREATE_CUSTOMER, createCustomerData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}