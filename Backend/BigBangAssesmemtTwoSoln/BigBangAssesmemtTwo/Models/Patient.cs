using System.ComponentModel.DataAnnotations;

namespace BigBangAssesmemtTwo.Models
{
    public class Patient
    {
        public Patient()
        {
            Name = string.Empty;
            Gender = "Unknown";
            HealthIssue = "Unknown";
        }
        [Key]
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public string HealthIssue { get; set; } 
        public User? Users { get; set; }

    }
}
