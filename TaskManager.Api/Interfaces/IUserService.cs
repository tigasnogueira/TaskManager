using TaskManager.Core.Models;

namespace TaskManager.Api.Interfaces;

public interface IUserService
{
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
    Task<User> GetByEmailAndPassword(string email, string password);
    Task<User> GetByName(string name);
    Task<IEnumerable<User>> GetAll();
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task<User> Remove(User user);
    Task<bool> IsEmailAlreadyInUse(string email);
    Task<bool> IsNameAlreadyInUse(string name);
}
