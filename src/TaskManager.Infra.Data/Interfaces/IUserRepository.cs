using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IUserRepository
{
    public Task<User> GetById(Guid id);
    public Task<User> GetByEmail(string email);
    public Task<User> GetByEmailAndPassword(string email, string password);
    public Task<User> GetByName(string name);
    public Task<IEnumerable<User>> GetAll();
    public Task<User> Add(User user);
    public Task<User> Update(User user);
    public Task<User> Remove(User user);
}
