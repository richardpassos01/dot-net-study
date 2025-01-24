using System.Threading.Tasks;
using src.Domain;

namespace src.Application.Interfaces
{
    public interface ILoanManagementAdapter
    {
        Task<Loan> GetLoanByApplicationId();
    }
}