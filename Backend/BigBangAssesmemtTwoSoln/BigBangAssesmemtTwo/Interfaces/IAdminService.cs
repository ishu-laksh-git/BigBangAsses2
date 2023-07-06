using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Interfaces
{
    public interface IAdminService
    {
        public Task<Doctor?> UpdateStatus(StatusDTO status);
        public Task<UserDTO?> AddDoctor(Doctor doctor);
    }
}