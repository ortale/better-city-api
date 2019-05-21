using System;
using System.Collections;
using System.Threading.Tasks;
using BtterCity.Interfaces;
using BtterCity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BtterCity.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly DatabaseContext _context;

        public IssueRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(Issue issue)
        {
            _context.Issues.Add(issue);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _context.Issues.ToListAsync();
        }
    }
}
