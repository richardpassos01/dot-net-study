using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using src.Application.UseCases;

namespace src.Api.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanManagementController : ControllerBase
    {
        private readonly GetLoan _getLoan;
        private readonly LoanOrigination _loanOrigination;

        public LoanManagementController(GetLoan getLoan, LoanOrigination loanOrigination)
        {
            _getLoan = getLoan;
            _loanOrigination = loanOrigination;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLoan()
        {
            var loan = await _getLoan.Execute();
            return Ok(loan);
        }


        [HttpPost("origination")]
        public async Task<IActionResult> LoanOrigination()
        {
            await _loanOrigination.Execute();
            return Ok();
        }
    }
}