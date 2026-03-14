namespace Domain.CompareSignature.Dto;

public class JwtStatusDto
{
    public string status { get; set; }
    public string jwt { get; set; }

    public JwtStatusDto()
    {
        
    }
    
    public JwtStatusDto(string status, string jwt)
    {
        this.status = status;
        this.jwt = jwt;
    }
}