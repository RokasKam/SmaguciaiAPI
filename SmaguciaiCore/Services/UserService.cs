using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Responses.User;

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
    
}