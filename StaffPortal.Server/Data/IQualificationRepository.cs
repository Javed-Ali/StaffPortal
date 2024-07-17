using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public interface IQualificationRepository
    {
        Task<List<Qualification>> GetAllQualificationsAsync();
    }
}
