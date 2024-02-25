using MapsterMapper;
using skills_api.Repositories.Interfaces;
using skills_api.Services.Interfaces;

public class UserService(IUserRepository userRepository,IMapper mapper) : IUserService
{
    public async  Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await userRepository.GetAllUsersAsync();
        return mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public Task<UserDTO> CreateUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> UpdateUserAsync(UserDTO userDto)
    {
        throw new NotImplementedException();
    }
}