using skills_api.Models;
using skills_api.Repositories.Interfaces;

class UserRepository(DatabaseContext context) : IUserRepository
{
    private readonly DatabaseContext _context = context;


    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await Task.FromResult(_context.Users.ToList());
    }
}