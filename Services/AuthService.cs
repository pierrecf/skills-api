using MapsterMapper;
using skills_api.DTO.Auth;
using skills_api.Repositories.Interfaces;
using skills_api.Services.Interfaces;

namespace skills_api.Services;

public class AuthService(IUserRepository userRepository,IMapper mapper):IAuthService
{
    public Task<UserDTO> RegisterUser(RegisterDTO registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> Login(LoginDTO loginDto)
    {
        throw new NotImplementedException();
    }
}