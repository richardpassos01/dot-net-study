using System;
using System.Threading.Tasks;
using src.Domain;
using System.Collections.Generic;

namespace src.Application.Interfaces
{
    public interface ILoanApplicationRepository
    {
        Task<LoanApplication> GetByIdAndUserId(Guid Id, Guid UserId);
        
    }
}