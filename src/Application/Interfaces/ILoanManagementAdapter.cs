using System.Threading.Tasks;
using src.Domain;

namespace src.Infrastructure.Adapters
{
    public interface ILoanManagementAdapter
    {
        Task<Loan> GetLoanByApplicationId();
    }
}