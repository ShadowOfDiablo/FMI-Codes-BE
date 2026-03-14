namespace Domain.Entities;

public class Challenge
{
    public int ChallengeId { get; set; }
    public string ChallengeCode { get; set; }
    public string Status  { get; set; }
    public string WebSiteURL { get; set; }
    public DateTime ExpiredDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
}