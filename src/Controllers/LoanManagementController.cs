using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using src.UseCases;

namespace src.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanManagementController : ControllerBase
    {
        private readonly GetLoan _getLoan;

        public LoanManagementController(GetLoan getLoan)
        {
            _getLoan = getLoan;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoan()
        {
            var loan = await _getLoan.Execute();
            return Ok(loan);
        }
    }
}