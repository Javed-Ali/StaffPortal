using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public interface IQualificationService
    {
        Task<List<Qualification>> GetAllQualificationsAsync();
    }
}
