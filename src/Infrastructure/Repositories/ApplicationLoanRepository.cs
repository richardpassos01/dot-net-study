using src.Domain;
using src.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace src.Infrastructure.Repositories
{
    public class LoanApplicationRepository
    {
        private readonly RelationalDbContext _context;

        public LoanApplicationRepository(RelationalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanApplication>> GetAllAsync()
        {
            return await _context.Applications.Include(la => la.Offer).ToListAsync();
        }

        public async Task<LoanApplication> GetByIdAsync(Guid id)
        {
            return await _context.Applications.Include(la => la.Offer).FirstOrDefaultAsync(la => la.Id == id);
        }

        public async Task CreateAsync(LoanApplication application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }
    }
}