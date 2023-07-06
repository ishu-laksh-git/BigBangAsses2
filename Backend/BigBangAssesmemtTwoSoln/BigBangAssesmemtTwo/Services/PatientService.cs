using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepo<Doctor, int> _docRepo;
        private readonly IDocRepo<int, Doctor> _doctorRepo;
        public PatientService(IRepo<Doctor,int> docRepo, IDocRepo<int, Doctor> doctorRepo)
        {
            _docRepo = docRepo;
            _doctorRepo = doctorRepo;
        }
        private ListDocDTO ConvertIntoDTO(Doctor doctor)
        {
            ListDocDTO doclist = new ListDocDTO();
            doclist.Id = doctor.DoctorId;
            doclist.Name = doctor.Name;
            doclist.isApproved = doctor.IsApproved;
            doclist.Gender = doctor.Gender;
            doclist.Speciality = doctor.Speciality;
            doclist.Experience = doctor.Experience;
            return doclist;
        }
        public async Task<ICollection<ListDocDTO>> GetDoctors()
        {
            List<ListDocDTO> doctors = new List<ListDocDTO>();
            var allDoctors = await _docRepo.GetAll();
            if(allDoctors != null)
            {
                foreach(var doctor in allDoctors)
                {
                    var doc = await _doctorRepo.Get(doctor.DoctorId);
                    if(doc != null)
                    {
                        var listDTO = ConvertIntoDTO(doc);
                        doctors.Add(listDTO);
                    }
                }
                return doctors;
            }
            return null;
        }

        
    }
}
