namespace ProjetcManager.API.DTOs.Tokens;

public record class TokenModelDTO
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
