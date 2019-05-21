using System;
using System.Collections;
using System.Threading.Tasks;
using BtterCity.Interfaces;
using BtterCity.Models;
using Microsoft.EntityFrameworkCore;

namespace BtterCity.Repository
{
    public class IssueTypeRepository : IIssueTypeRepository
    {
        private readonly DatabaseContext _context;

        public IssueTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(IssueType issueType)
        {
            _context.IssueTypes.Add(issueType);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _context.IssueTypes.ToListAsync();
        }
    }
}
