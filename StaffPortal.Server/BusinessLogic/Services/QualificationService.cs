using StaffPortal.Server.Data;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.BusinessLogic.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository _qualificationRepository;
        public QualificationService(IQualificationRepository qualificationRepository)
        {
            _qualificationRepository = qualificationRepository;
        }
        public async Task<List<Qualification>> GetAllQualificationsAsync()
        {
            return await _qualificationRepository.GetAllQualificationsAsync();
        }
 
    }
}
