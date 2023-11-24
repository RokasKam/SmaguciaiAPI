using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public UserRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User? GetByEmailOrDefault(string email)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User PostUser(User user)
    {
        user.Id = Guid.NewGuid();
        user.ReviewCount = 0;
        _dbContext.Users.Add(user); 
        _dbContext.SaveChanges();
        return user;
    }

    public User GetById(Guid id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        return user;    
    }
}