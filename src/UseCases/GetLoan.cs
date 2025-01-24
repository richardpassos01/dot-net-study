using System;
using src.Domain;

namespace src.UseCases
{
    public class GetLoan
    {
        public Loan Execute()
        {
            return new Loan
            {
                Id = Guid.NewGuid(),
                CustomerName = "Richard"
            };
        }
    }
}