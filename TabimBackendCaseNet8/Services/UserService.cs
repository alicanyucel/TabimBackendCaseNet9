using Microsoft.EntityFrameworkCore;
using TabimBackendCaseNet8.Context;
using TabimBackendCaseNet8.Dtos;
using TabimBackendCaseNet8.Entities;
using TabimBackendCaseNet8.Enums;
using BCrypt.Net;
public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterAsync(UserRegisterDto userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            PhoneNumber = userDto.PhoneNumber,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            Role = UserRole.User
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> LoginAsync(UserLoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid login attempt");
        }
        return user;
    }
}
