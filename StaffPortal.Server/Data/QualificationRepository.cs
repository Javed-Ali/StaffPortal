using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly AppDbContext _context;

        public QualificationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Qualification>> GetAllQualificationsAsync()
        {
            return await _context.Qualifications.ToListAsync();
        }
    }
}
