using ProjetcManager.API.DTOs.User;
using ProjetcManager.API.Models;

namespace ProjetcManager.API.DTOs.Mapping;

public static class UserMapping
{
    public static IEnumerable<UserDTO> ToListUserDTO(this IEnumerable<UserModel> userModels)
    {
        return userModels.Select(user => new UserDTO
        {
            UserId = user.Id,
            UserName = user.UserName,
        });
    }

    public static UserDTO ToUserDTO(this UserModel userModel)
    {
        return new UserDTO()
        {
            UserId = userModel.Id,
            UserName = userModel.UserName
        };
    }

    public static UserWithProjectDTO ToUserWithProjectDTO(this UserModel userModel)
    {
        return new UserWithProjectDTO()
        {
            UserId  = userModel.Id,
            UserName = userModel.UserName,
            Projects = userModel.Projects!.ToListProjectDTO()
        };
    }
}
