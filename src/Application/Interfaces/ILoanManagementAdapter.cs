using System.Threading.Tasks;
using src.Domain.Loan;

namespace src.Application.Interfaces
{
    public interface ILoanManagementAdapter
    {
        Task<Loan> GetLoanByApplicationId();
    }
}