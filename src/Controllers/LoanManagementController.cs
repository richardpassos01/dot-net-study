using Microsoft.AspNetCore.Mvc;
using src.UseCases;

[ApiController]
[Route("api/[controller]")]
public class LoanManagementController : ControllerBase
{
    private readonly GetLoan _getLoan;

    public LoanManagementController(GetLoan getLoan)
    {
        _getLoan = getLoan;
    }

    [HttpGet]
    public IActionResult GetLoan()
    {
        var loan = _getLoan.Execute();
        return Ok(loan);
    }
}