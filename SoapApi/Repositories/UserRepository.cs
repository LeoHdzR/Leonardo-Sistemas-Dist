using SoapApi.Models;
using SoapApi.Services;
using SoapApi.Mappers;

namespace SoapApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RelationalDbContext _dbContext;
    public UserRepository(RelationalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<UserModel>GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(s UserEntity => s.Id == id, cancellationToken);
        return user.ToModel(); 
    }
}