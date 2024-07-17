using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public interface IGenderService
    {
        Task<List<Gender>> GetAllGenderAsync();
         
    }
}
