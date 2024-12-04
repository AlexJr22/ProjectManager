using System.ComponentModel.DataAnnotations;

namespace ProjetcManager.API.DTOs.TokensDTO;

public record class LoginModelDTO
{
    [Required(ErrorMessage = "User Name is required!")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    public string? Password { get; set; }
}
