using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Interfaces.Services;

public interface IUserService
{
    UserResponse GetById(Guid id);
}