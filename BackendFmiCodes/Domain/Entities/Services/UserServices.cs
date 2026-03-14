using Domain.Entities;
using Domain.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Services;

public class UserServices
{
    private readonly FmiDatabaseConfig _context;

    public UserServices(FmiDatabaseConfig context)
    {
        _context = context;
    }

    public int GetUserId(string email)
    {
        var user = _context.Set<User>()
            .FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        return user.UserId;
    }
    public UserIdAndPushToken GetUserIdAndPushToken(string email)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            throw new Exception("User not found.");
        }
        var userDto = new UserIdAndPushToken(user.PushToken, user.UserId);

        return userDto;
    }
}