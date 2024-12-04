namespace ProjetcManager.API.DTOs.TokensDTO;

public record class TokenModelDTO
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
