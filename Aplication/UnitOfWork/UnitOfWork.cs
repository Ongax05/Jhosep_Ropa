using Aplication.Repository;
using Domain.Interfaces;
using Persistency;
namespace Aplication.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
