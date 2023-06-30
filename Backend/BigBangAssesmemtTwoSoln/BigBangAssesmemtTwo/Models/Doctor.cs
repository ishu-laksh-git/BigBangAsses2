using System.ComponentModel.DataAnnotations;

namespace BigBangAssesmemtTwo.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }
        [Key]
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? IsApproved { get; set; }
        public string? Speciality { get; set; }
        public int? Experience { get; set; }
        public User? Users { get; set; }
    }
}
