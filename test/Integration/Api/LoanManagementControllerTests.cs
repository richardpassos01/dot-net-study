// using System.Net;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Moq;
// using Moq.Protected;
// using Xunit;
// using src.Api.Controllers;
// using src.Application.UseCases;
// using src.Domain;
// using src.Infrastructure.Adapters;
// using src.Application.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading;
// using System;
// using dotenv.net;

// namespace tests.Integration.Api
// {
//     public class LoanManagementControllerTests
//     {
//         public LoanManagementControllerTests()
//         {
//             DotEnv.Load(options: new DotEnvOptions(probeForEnv: true, envFilePaths: new[] { ".env.test" }));
//         }

//         [Fact]
//         public async Task GetLoan_ShouldReturnLoanWithCorrectProperties()
//         {
//             // Arrange
//             var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
//             mockHttpMessageHandler.Protected()
//                 .Setup<Task<HttpResponseMessage>>(
//                     "SendAsync",
//                     ItExpr.IsAny<HttpRequestMessage>(),
//                     ItExpr.IsAny<CancellationToken>()
//                 )
//                 .ReturnsAsync(new HttpResponseMessage
//                 {
//                     StatusCode = HttpStatusCode.OK,
//                     Content = new StringContent("[{\"Id\":\"807f\",\"LoanId\":1,\"State\":\"active\",\"ContractBalance\":5000,\"DiscountAmount\":200,\"LoanAmount\":10000,\"FundedDate\":\"2025-01-01T00:00:00\",\"AmountDue\":4800}]")
//                 });

//             var httpClient = new HttpClient(mockHttpMessageHandler.Object)
//             {
//                 BaseAddress = new Uri("http://localhost:3000")
//             };

//             var loanManagementAdapter = new LoanManagementAdapter(httpClient);
//             var getLoan = new GetLoan(loanManagementAdapter);
//             var loanOrigination = new LoanOrigination(loanManagementAdapter);
//             var controller = new LoanManagementController(getLoan, loanOrigination);

//             // Act
//             var result = await controller.GetLoan() as OkObjectResult;
//             var loan = result?.Value as Loan;

//             // Assert
//             Assert.NotNull(loan);;
//             Assert.True(loan.IsActive);
//             Assert.Equal(5000, loan.Balance);
//             Assert.Equal(200, loan.Discount);
//             Assert.Equal(10000, loan.PaybackAmount);
//             Assert.Equal(new DateTime(2025, 1, 1), loan.FundedDate);
//             Assert.Equal(4800, loan.PaymentDue);

//             mockHttpMessageHandler.Protected().Verify(
//                 "SendAsync",
//                 Times.Once(),
//                 ItExpr.Is<HttpRequestMessage>(req =>
//                     req.Method == HttpMethod.Get &&
//                     req.RequestUri == new Uri("http://localhost:3000/loans?loanId=1")
//                 ),
//                 ItExpr.IsAny<CancellationToken>()
//             );
//         }
//     }
// }