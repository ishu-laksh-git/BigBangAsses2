using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace BigBangAssesmemtTwo.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepo<Doctor, int> _docRepo;
        private readonly IRepo<User, int> _userRepo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IDocRepo<int, Doctor> _docService;
        public AdminService(IRepo<Doctor,int> docRepo,IRepo<User,int> userRepo,ITokenGenerate tokenGenerate,IDocRepo<int,Doctor> docService) 
        {
            _docRepo = docRepo;
            _userRepo = userRepo;
            _tokenGenerate = tokenGenerate;
            _docService = docService;
        }

        public async Task<UserDTO?> AddDoctor(Doctor doctor)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            doctor.Users = new User();
            var pass = doctor.Name.Substring(0, 4) + doctor.DateOfBirth.Day;
            doctor.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
            doctor.Users.PasswordKey = hmac.Key;
            doctor.Users.EmailId = doctor.Email;
            doctor.Users.Role = "Doctor";
            doctor.IsApproved = "Not approved";
            var userResult = await _userRepo.Add(doctor.Users);
            var docResult = await _docRepo.Add(doctor);
            if (userResult != null && docResult != null)
            {
                user = new UserDTO();
                user.UserId = docResult.Users.UserId;
                user.EmailId = userResult.EmailId;
                user.Role = userResult.Role;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }

        public async Task<Doctor?> UpdateStatus(StatusDTO status)
        {
            try
            {
                var doctor = await _docService.Get(status.DoctorID);
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
