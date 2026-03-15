namespace Domain.Login.Dtos;

public class LoginDto
{
    public string ChallengeCode { get; set; }
    public int ChallengeId { get; set; }
    
    public LoginDto(string challengeCode, int challengeId)
    {
            
        ChallengeCode = challengeCode;
        ChallengeId = challengeId;
    }
}