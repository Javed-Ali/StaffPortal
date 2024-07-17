using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGenders();
    }
}
