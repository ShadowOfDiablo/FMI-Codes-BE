using Domain.Entities;
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
}