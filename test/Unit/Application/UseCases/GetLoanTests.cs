using System.Threading.Tasks;
using Moq;
using Xunit;
using src.Application.UseCases;
using src.Domain;
using src.Application.Interfaces;
using System;

namespace tests.Unit.Application.UseCases
{
    public class GetLoanTests
    {
        [Fact]
        public async Task Execute_ShouldReturnLoanWithCorrectProperties()
        {
            // Arrange
            var mockLoanManagementAdapter = new Mock<ILoanManagementAdapter>();
            mockLoanManagementAdapter.Setup(adapter => adapter.GetLoanByApplicationId())
                .ReturnsAsync(new Loan
                {
                    IsActive = true,
                    Balance = 5000,
                    Discount = 200,
                    PaybackAmount = 10000,
                    FundedDate = new DateTime(2025, 1, 1),
                    PaymentDue = 4800
                });

            var getLoan = new GetLoan(mockLoanManagementAdapter.Object);

            // Act
            var loan = await getLoan.Execute();

            // Assert
            Assert.NotNull(loan);
            Assert.True(loan.IsActive);
            Assert.Equal(5000, loan.Balance);
            Assert.Equal(200, loan.Discount);
            Assert.Equal(10000, loan.PaybackAmount);
            Assert.Equal(new DateTime(2025, 1, 1), loan.FundedDate);
            Assert.Equal(4800, loan.PaymentDue);
        }
    }
}