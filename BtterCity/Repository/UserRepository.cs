using System;
using System.Threading.Tasks;
using BtterCity.Models;

namespace BtterCity.Repository
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Save(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
