using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.User;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public UserResponse GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        var response = _mapper.Map<UserResponse>(user);
        return response;
    }
    public bool EditUser(Guid id,UserEditRequest request)
    {
        try
        {
            var placeToUpdate = _userRepository.GetById(id);
            if (placeToUpdate is null)
            {
                throw new Exception("Place with provided id does not exist");
            }

            var user = _mapper.Map<User>(request);
            user.Id = id;
            var res = _userRepository.EditUser(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteUser(Guid id)
    {
        try
        {
            _userRepository.DeleteUser(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}