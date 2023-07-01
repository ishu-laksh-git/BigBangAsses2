using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepo<Doctor, int> _docRepo;
        public AdminService(IRepo<Doctor,int> docRepo) 
        {
            _docRepo = docRepo;
        }
        public async Task<Doctor?> UpdateStatus(StatusDTO status)
        {
            try
            {
                var doctor = await _docRepo.Get(status.DoctorID);
                if (doctor == null) { return null; }
                doctor.IsApproved = status.status;
                var updatedDoc = await _docRepo.Update(doctor);
                if (updatedDoc == null) { return null; }
                return updatedDoc;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
