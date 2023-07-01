using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Interfaces
{
    public interface IPatientService
    {
        public Task<ICollection<ListDocDTO>> GetDoctors();
    }
}
