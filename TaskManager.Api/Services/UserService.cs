using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRepository.GetByEmail(email);
    }

    public async Task<User> GetByEmailAndPassword(string email, string password)
    {
        return await _userRepository.GetByEmailAndPassword(email, password);
    }

    public async Task<User> GetByName(string name)
    {
        return await _userRepository.GetByName(name);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> Add(User user)
    {
        return await _userRepository.Add(user);
    }

    public async Task<User> Update(User user)
    {
        return await _userRepository.Update(user);
    }

    public async Task<User> Remove(User user)
    {
        return await _userRepository.Remove(user);
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
