using skills_api.DTO.Auth;

namespace skills_api.Services.Interfaces;

public interface IAuthService
{
    Task<UserDTO> RegisterUser(RegisterDTO registerDto);
    Task<UserDTO> Login(LoginDTO loginDto);
}
