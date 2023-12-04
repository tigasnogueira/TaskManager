using TaskManager.Api.Dtos;

namespace TaskManager.Api.Interfaces;

public interface IUserService
{
    Task<UserDto> GetById(Guid id);
    Task<UserDto> GetByEmail(string email);
    Task<UserDto> GetByEmailAndPassword(string email, string password);
    Task<UserDto> GetByName(string name);
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDto> Add(UserDto userDto);
    Task<UserDto> Update(UserDto userDto);
    Task<UserDto> Remove(UserDto userDto);
    Task<bool> IsEmailAlreadyInUse(string email);
    Task<bool> IsNameAlreadyInUse(string name);
}
