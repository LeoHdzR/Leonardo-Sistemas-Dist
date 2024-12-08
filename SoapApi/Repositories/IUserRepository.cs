namespace SoapApi.Repositories

public interface 
{
    public Task<UserModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
}