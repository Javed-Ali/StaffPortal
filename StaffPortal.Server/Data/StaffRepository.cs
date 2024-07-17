using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.DTOs;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Staff> CreateAsync(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> GetByEmployeeNumberAsync(string employeeNumber)
        {
            return await _context.Staff.Include(s => s.Gender)
                                       .Include(s => s.Qualification)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(s => s.EmployeeNumber == employeeNumber);
        }

        public async Task<Staff> UpdateAsync(Staff staff)
        {
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task DeleteAsync(string employeeNumber)
        {
            var staff = await _context.Staff.FirstOrDefaultAsync(s => s.EmployeeNumber == employeeNumber);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Staff>> GetAllStaff()
        {
            return await _context.Staff.Include(x => x.Gender).Include(x => x.Qualification).AsNoTracking().ToListAsync();
        }
    }


}
