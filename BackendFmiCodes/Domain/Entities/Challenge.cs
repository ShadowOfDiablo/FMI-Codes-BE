namespace Domain.Entities;

public class Challenge
{
    public int ChallengeId { get; set; }
    public String ChallengeCode { get; set; }
    public String Status  { get; set; }
    public String WebSiteURL { get; set; }
    public DateTime ExpiredDate { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}