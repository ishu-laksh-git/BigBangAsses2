using BigBangAssesmemtTwo.Models.DTO;

namespace BigBangAssesmemtTwo.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);
    }
}
