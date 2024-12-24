namespace ProjectManager.Domain.Entities;

public sealed class UserModel
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public ICollection<ProjectModel>? Projects { get; set; }
}
