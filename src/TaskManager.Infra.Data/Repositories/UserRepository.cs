using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Infra.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(TaskManagerContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);
    }

    public async Task<User?> GetByName(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Nome == name);
    }
}
