using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Interfaces
{
    public interface IService
    {
        public Task<UserDTO?> DoctorRegister(DoctorRegDTO docRegDTO);
        public Task<UserDTO?> PatientRegister(PatientRegDTO patientRegDTO);
        public Task<UserDTO?> Login(UserDTO userDTO);

    }
}
