using Domain.Entities.Services;
using Domain.Services;
using MediatR;

namespace Domain.Handlers.Login;

public class LoginRequestHandler : IRequestHandler<LoginRequest, bool>
{
    private readonly LoginServices _loginServices;
    private readonly UserServices _userServices;
    private readonly ChallengeServices _challengeServices;

    public LoginRequestHandler(LoginServices loginServices,  UserServices userServices, ChallengeServices challengeServices)
    {
        _loginServices = loginServices;
        _userServices = userServices;
        _challengeServices = challengeServices;
    }
    public async Task<bool> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var senderPath = _loginServices.CreateSenderPath();
            var challengeCode = _loginServices.CreateChallengeCode();
            var expireTime =  _loginServices.CreateExpireTime();
            var userId = _userServices.GetUserId(request.Email);
            var newChallengeResult = _challengeServices.CreateChallenge(request.Email, 
                senderPath, challengeCode,
                expireTime, userId);
            if (!newChallengeResult)
            {
                throw new Exception("Can't create Challenge");
            }
            // create push notification

            return true;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}