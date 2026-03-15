using Domain.Entities.Services;
using Domain.Login.Dtos;
using Domain.Services;
using MediatR;

namespace Domain.Handlers.Login;

public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginDto>
{
    private readonly LoginServices _loginServices;
    private readonly UserServices _userServices;
    private readonly ChallengeServices _challengeServices;
    private readonly PushNotificationServices _pushNotificationServices;

    public LoginRequestHandler(LoginServices loginServices,  UserServices userServices,
        ChallengeServices challengeServices, PushNotificationServices pushNotificationServices)
    {
        _loginServices = loginServices;
        _userServices = userServices;
        _challengeServices = challengeServices; 
        _pushNotificationServices = pushNotificationServices;
    }
    public async Task<LoginDto> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var senderPath = _loginServices.CreateSenderPath();
            var challengeCode = _loginServices.CreateChallengeCode();
            var expireTime =  _loginServices.CreateExpireTime();
            var userIdAndPushToken = _userServices.GetUserIdAndPushToken(request.Email);
            var newChallengeResult = _challengeServices.CreateChallenge(request.Email, 
                senderPath, challengeCode,
                expireTime, userIdAndPushToken.UserId);
            if (newChallengeResult == -1)
            {
                throw new Exception("Can't create Challenge");
            }
            // create push notification
            _pushNotificationServices.SendLoginPush(userIdAndPushToken.PushToken, challengeCode, newChallengeResult);
            //var returnResult = await _loginServices.ReturnApiResponse(senderPath, userIdAndPushToken.UserId);
            
            return new LoginDto(challengeCode, newChallengeResult);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}