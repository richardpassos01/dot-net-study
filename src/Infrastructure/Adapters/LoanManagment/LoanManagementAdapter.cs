using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using src.Domain;
using System.Net.Http.Json;
using src.Infrastructure.Adapters.LoanManagment.Responses;
using src.Application.Interfaces;
using src.Infrastructure.Adapters.LoanManagment.Endpoints;
using src.Infrastructure.Adapters.LoanManagment.Requests;
using Microsoft.AspNetCore.WebUtilities;

namespace src.Infrastructure.Adapters
{
    public class LoanManagementAdapter : ILoanManagementAdapter
    {
        private readonly HttpClient _httpClient;

        public LoanManagementAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var host = Environment.GetEnvironmentVariable("ADAPTER_HOST") ?? "http://localhost:3000";
            _httpClient.BaseAddress = new Uri(host);
        }

        public async Task<Loan> GetLoanByApplicationId()
        {
            try
            {
                var queryParams = new Dictionary<string, string>
                {
                    ["loanId"] = "1"
                };
                var uri = QueryHelpers.AddQueryString(Endpoints.LOANS, queryParams);

                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var loanDataList = await response.Content.ReadFromJsonAsync<List<LoanData>>();
                var loanData = loanDataList[0];

                return new Loan
                {
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
                    Address = "1234 Main St",
                    UserId = Guid.NewGuid()
                };

                var response = await _httpClient.PostAsJsonAsync(Endpoints.CUSTOMERS, createCustomerData);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Loan>> ListActiveLoans(Guid userId)
        {
            try
            {
                var queryParams = new Dictionary<string, string>
                {
                    ["loan_state"] = "active",
                    ["select"] = "loanData"
                };
                var endpoint = $"{Endpoints.CUSTOMERS}-{userId}"; // @TODO: Fix this - should be /customers/{userId}
                var uri = QueryHelpers.AddQueryString(endpoint, queryParams);

                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                var customerDataList = await response.Content.ReadFromJsonAsync<List<CustomerData>>();
                var customerData = customerDataList?.FirstOrDefault();

                var loans = customerData.LoanData.Select(loanData => new Loan
                {
                    IsActive = loanData.State == "active",
                    Balance = loanData.ContractBalance,
                    Discount = loanData.DiscountAmount,
                    PaybackAmount = loanData.LoanAmount,
                    FundedDate = loanData.FundedDate,
                    PaymentDue = loanData.AmountDue
                }).ToList();

                return loans;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task CreateInactiveLoan(LoanApplication application)
        {
            try
            {
                var createLoanData = new CreateLoanData {
                    UserId = application.UserId,
                    ApplicationId = application.Id,
                    LoanAmount = application.Offer.PaybackAmount,
                    loanTerm = application.Offer.PaymentTerms,
                };

                var response = await _httpClient.PostAsJsonAsync(Endpoints.LOANS, createLoanData);
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