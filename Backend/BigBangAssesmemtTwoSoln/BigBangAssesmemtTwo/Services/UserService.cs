using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace BigBangAssesmemtTwo.Services
{
    public class UserService : IService
    {
        private readonly IRepo<Doctor, int> _doctorRepo;
        private readonly IRepo<Patient, int> _patientRepo;
        private readonly IRepo<User, int> _userRepo;
        private readonly ITokenGenerate _tokenGenerate;
        public UserService(IRepo<Doctor, int> doctorRepo, IRepo<Patient, int> patientRepo,
                           IRepo<User, int> userRepo, ITokenGenerate tokenGenerate)
        {
            _doctorRepo = doctorRepo;
            _patientRepo = patientRepo;
            _userRepo = userRepo;
            _tokenGenerate = tokenGenerate;
        }

        public async Task<UserDTO?> DoctorRegister(DoctorRegDTO docRegDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            docRegDTO.Users = new User();
            docRegDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(docRegDTO.PasswordClear));
            docRegDTO.Users.PasswordKey = hmac.Key;
            docRegDTO.Users.EmailId = docRegDTO.Email;
            docRegDTO.Users.Role = "Doctor";
            docRegDTO.IsApproved = "Not approved";
            var userResult = await _userRepo.Add(docRegDTO.Users);
            var docResult = await _doctorRepo.Add(docRegDTO);
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

        public async Task<UserDTO?> Login(UserDTO user)
        {
            var userData = await _userRepo.Get(user.UserId);
            if(userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.Role = userData.Role;
                user.Token = _tokenGenerate.GenerateToken(user);
                return user;
            }
            return null;
            
        }

        public async Task<UserDTO?> PatientRegister(PatientRegDTO patientRegDTO)
        {
            UserDTO? user = null;
            var hmac = new HMACSHA512();
            patientRegDTO.Users = new User();
            patientRegDTO.Users.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(patientRegDTO.PasswordClear));
            patientRegDTO.Users.PasswordKey = hmac.Key;
            patientRegDTO.Users.Role = "Patient";
            patientRegDTO.Users.EmailId = patientRegDTO.Email;
            var userResult = await _userRepo.Add(patientRegDTO.Users);
            
            var patientResult = await _patientRepo.Add(patientRegDTO);
            if (userResult != null && patientResult != null)
            {
                user = new UserDTO();
                user.UserId = patientResult.PatientId;
                user.Role = userResult.Role;
                user.EmailId = patientResult.Email;
                user.Token = _tokenGenerate.GenerateToken(user);
            }
            return user;
        }
    } 
}
