using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public interface IStaffRepository
    {
        Task<Staff> CreateAsync(Staff staff);
        Task<Staff> GetByEmployeeNumberAsync(string employeeNumber);

        Task<List<Staff>> GetAllStaff();
        Task<Staff> UpdateAsync(Staff staff);
        Task DeleteAsync(string employeeNumber);
    }
}
