using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Domain;
using src.Application.Interfaces;
using src.Infrastructure.Database;

namespace src.Infrastructure.Repositories;

public class LoanApplicationRepository : ILoanApplicationRepository
{
    private readonly RelationalDbContext _context;

    public LoanApplicationRepository(RelationalDbContext context)
    {
        _context = context;
    }

    public async Task<LoanApplication> GetByIdAndUserId(Guid Id, Guid UserId)
    {
        return await _context.Applications
            .Include(la => la.Offer)
            .FirstOrDefaultAsync(la => la.Id == Id && la.UserId == UserId);
    }
}
