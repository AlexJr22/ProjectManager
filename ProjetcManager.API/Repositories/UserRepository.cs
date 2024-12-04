using ProjetcManager.API.Data;
using ProjetcManager.API.Models;
using ProjetcManager.API.Repositories.interfaces;

namespace ProjetcManager.API.Repositories;

public class UserRepository(AppDbContext context) 
    : Repository<UserModel>(context), IUserRepository
{
}
