namespace skills_api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> CreateUserAsync();
    Task<UserDTO?> DeleteUserAsync(int id);
    Task<UserDTO> UpdateUserAsync(UserDTO userDto);
}