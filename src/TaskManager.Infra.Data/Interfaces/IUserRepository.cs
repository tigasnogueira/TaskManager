using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetByEmail(string email);
    public Task<User?> GetByEmailAndPassword(string email, string password);
    public Task<User?> GetByName(string name);
}
