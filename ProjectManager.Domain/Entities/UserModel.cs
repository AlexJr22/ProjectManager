namespace ProjectManager.Domain.Entities;

public sealed class UserModel
{
    public string? RefreshToken { get; private set; }
    public DateTime RefreshTokenExpiryTime { get; private set; }
    public ICollection<ProjectModel>? Projects { get; private set; }
}
