using FirebaseAdmin.Messaging;

namespace Domain.Services;

public class PushNotificationServices
{
    public async Task SendLoginPush(string token, string challengeCode, int challengeId)
    {
        var message = new Message()
        {
            Token = "f8AeI9SyQdm09kU2ISlmR5:APA91bGtlLlC5JpDa9_pRBStW0ImmanNGtbBy5u1IhQTP8CUeIAjZW1DvxIvDkuwiRLVL8H-Wm0qMKyzm_-Go5KIC0sRIfsxJfuzfARWbOGePTtp3xGp2n8", 
            Notification = new Notification
            {
                Title = "Login Request",
                Body = $"Do you want to approve this login?"
            },
            
            Data = new Dictionary<string, string>()
            {
                { "challengeId", challengeId.ToString() },
                { "challengeCode", challengeCode },
                { "type", "login_approval" }
            }
        };

        await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}