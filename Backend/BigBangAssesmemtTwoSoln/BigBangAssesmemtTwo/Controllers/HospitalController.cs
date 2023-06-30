using BigBangAssesmemtTwo.Interfaces;
using BigBangAssesmemtTwo.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssesmemtTwo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IService _userService;
        public HospitalController(IService userService)
        {
            _userService = userService;
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
                if(user != null)
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
    }
}
