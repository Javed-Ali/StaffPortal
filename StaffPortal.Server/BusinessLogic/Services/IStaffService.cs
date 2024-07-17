using StaffPortal.Server.DTOs;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public interface IStaffService
    {
        Task<Staff> CreateStaffAsync(StaffDTO staffDto);
        Task<Staff> GetStaffByEmployeeNumberAsync(string employeeNumber);
        Task<List<Staff>> GetAllStaffAsync();
        Task<Staff> UpdateStaffAsync(string employeeNumber, StaffDTO staffDto);
        Task DeleteStaffAsync(string employeeNumber);

        decimal CalculateSalary(int qualificationLevel, int yearsOfExperience);
    }
}