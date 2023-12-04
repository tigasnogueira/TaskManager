using AutoMapper;
using TaskManager.Api.Dtos;
using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetById(Guid id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByEmailAndPassword(string email, string password)
    {
        var user = await _userRepository.GetByEmailAndPassword(email, password);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByName(string name)
    {
        var user = await _userRepository.GetByName(name);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> Add(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var resultado = await _userRepository.Add(user);
        return _mapper.Map<UserDto>(resultado);
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var CurrentUser = await _userRepository.GetById(userDto.Id);
        if (CurrentUser == null)
        {
            return null;
        }
        var user = _mapper.Map<User>(userDto);
        var resultado = await _userRepository.Update(user);
        return _mapper.Map<UserDto>(resultado);
    }

    public async Task<UserDto> Remove(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var resultado = await _userRepository.Remove(user);
        return _mapper.Map<UserDto>(resultado);
    }

    public async Task<bool> IsEmailAlreadyInUse(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        return user != null;
    }

    public async Task<bool> IsNameAlreadyInUse(string name)
    {
        var user = await _userRepository.GetByName(name);
        return user != null;
    }
}
