using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace Domain.Services;

public class LoginServices
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginServices(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string CreateSenderPath()
    {
        var context = _httpContextAccessor.HttpContext;

        var ip = context?.Connection.RemoteIpAddress?.ToString();
        var path = context?.Request.Path.ToString();
        var fullUrl = $"{context?.Request.Scheme}://{context?.Request.Host}{context?.Request.Path}";

        return fullUrl;
    }
    
    public string CreateChallengeCode()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        var challengeCode = Convert.ToBase64String(bytes);

        return challengeCode;
    }

    public DateTime CreateExpireTime()
    {
        return DateTime.UtcNow.AddMinutes(15);
    }
    
}