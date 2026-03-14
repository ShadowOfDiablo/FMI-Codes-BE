using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
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

    public async Task<bool> ReturnApiResponse(string apiPath, int challengeId)
    {
        using (var client = new HttpClient())
        {
            // Подготвяме данните, които ще пратим (обект, който се превръща в JSON)
            var payload = new { id = challengeId};
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Изпращаме POST заявка към оригиналното API
                var response = await client.PostAsync(apiPath, content);

                // Връщаме true, ако статус кодът е 200-299 (Success)
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Тук е добре да логнеш грешката
                Console.WriteLine($"Грешка при връщане на отговор: {ex.Message}");
                return false;
            }
        }
    }
}