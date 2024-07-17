using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public class GenderRepository : IGenderRepository
    {
        private readonly AppDbContext _context;

        public GenderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Gender>> GetAllGenders()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}
