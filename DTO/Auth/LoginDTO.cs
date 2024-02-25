using System.Runtime.InteropServices.JavaScript;

namespace skills_api.DTO.Auth;

public class LoginDTO
{
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}