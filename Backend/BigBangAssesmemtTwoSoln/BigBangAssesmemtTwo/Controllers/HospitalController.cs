using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models;
using BigBangAssesmemtTwo.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BigBangAssesmemtTwo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IService _userService;
        private readonly IRepo<Doctor, int> _docRepo;
        private readonly IAdminService _adminService;
        private readonly IPatientService _patientService;
        public HospitalController(IService userService, IRepo<Doctor, int> docrepo, IAdminService adminService,IPatientService patientService)
        {
            _userService = userService;
            _docRepo = docrepo;
            _adminService = adminService;
            _patientService= patientService;

        }
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> RegisterDoc(DoctorRegDTO docDTO)
        {
            try
            {
                var doctor = await _userService.DoctorRegister(docDTO);
                if (doctor != null)
                    return Created("Doctor added", doctor);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error...Try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> RegisterPatient(PatientRegDTO patientDTO)
        {
            try
            {
                var patient = await _userService.PatientRegister(patientDTO);
                if (patient != null)
                    return Created("patient added", patient);
                return BadRequest("Unable to register");
            }
            catch (Exception)
            {
                return BadRequest("Network error...Try again later");
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//Failure Response
        public async Task<ActionResult<UserDTO?>> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.Login(userDTO);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest("Unable to login");
            }
            catch (Exception)
            {
                return BadRequest("Network error...Please try later");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Doctor>), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ICollection<Doctor>>> GetDoctors()
        {
            try
            {
                var doctors = await _docRepo.GetAll();
                if (doctors != null)
                {
                    return Ok(doctors);
                }
                return BadRequest("No doctors available");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response

        public async Task<ActionResult<Doctor?>> UpdateDoctorStatus(StatusDTO status)
        {
            try
            {
                var doctor = await _adminService.UpdateStatus(status);
                if (doctor != null)
                {
                    return Ok(doctor);
                }
                return BadRequest("Not updated!");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response

        public async Task<ActionResult<Doctor?>> UpdateDoctorDetails(Doctor doctor)
        {
            {
                try
                {
                    var doc = await _docRepo.Update(doctor);
                    if (doctor != null)
                    {
                        return Ok(doctor);
                    }
                    return BadRequest("Not updated!");
                }
                catch (Exception)
                {
                    return BadRequest("Backend error");
                }
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var doctor = await _docRepo.Get(id);
                if (doctor != null)
                {
                    return Ok(doctor);
                }
                return BadRequest("No doctor with that id");
            }
            catch (Exception)
            {
                return BadRequest("Database error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Doctor>> AddDoctor(Doctor doctor)
        {
            try
            {
                var doc = await _docRepo.Add(doctor);
                if (doctor != null)
                {
                    return Ok(doc);
                }
                return BadRequest("Doctor already exists!");
            }
            catch (Exception)
            {
                return BadRequest("Backend error!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ProducesResponseType(typeof(Doctor), StatusCodes.Status201Created)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            try
            {
                var doc = await _docRepo.Get(id);
                if(doc != null)
                {
                    return Ok(doc);
                }
                return BadRequest("No doctor found!");
            }
            catch (Exception)
            {
                return BadRequest("Backend error!");
            }
        }
        [Authorize(Roles = "Patient")]
        [HttpGet]
        [ProducesResponseType(typeof(List<ListDocDTO>), StatusCodes.Status201Created)]//successResponse
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListDocDTO>> GetDocSpec()
        {
            try
            {
                var doctors = await _patientService.GetDoctors();
                if(doctors != null)
                {
                    return Ok(doctors);
                }
                return BadRequest("No doctors found");
            }
            catch (Exception)
            {
                return BadRequest("Backend error");
            }
        }

    }
}
