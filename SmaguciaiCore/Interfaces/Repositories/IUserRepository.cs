using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IUserRepository
{    
    User? GetByEmailOrDefault(string email);
    User PostUser(User user);
    User GetById(Guid id);
}