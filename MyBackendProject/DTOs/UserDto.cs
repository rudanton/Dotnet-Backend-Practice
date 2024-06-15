namespace MyBackendProject.DTOs;
public class RegisterDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class UserInfoDto
{
    public string Username { get; set; }
    public string Email { get; set; }
}