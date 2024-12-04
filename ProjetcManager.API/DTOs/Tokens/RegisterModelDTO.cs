using System.ComponentModel.DataAnnotations;

namespace ProjetcManager.API.DTOs.Tokens;

public record class RegisterModelDTO
{
    [Required(ErrorMessage = "User Name is required!")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Password is required!")]
    public string? Password { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
}
