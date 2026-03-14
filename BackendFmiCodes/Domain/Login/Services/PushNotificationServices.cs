using FirebaseAdmin.Messaging;

namespace Domain.Services;

public class PushNotificationServices
{
    public async Task SendLoginPush(string token, string challengeCode, int challengeId)
    {
        var message = new Message()
        {
            Token = "eVAvlff8Q5OhBdwZ1BTcBe:APA91bEKDDY86xTSA7-jmU5e9f03BLees-tFmaa4AfSfpFMIDOVobgNcSsadwhALhksHGhvUg2H1dNG3Wdp9G8pg-cvM_vF6uf9UzCN9_qcelfgsye15QhU",
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