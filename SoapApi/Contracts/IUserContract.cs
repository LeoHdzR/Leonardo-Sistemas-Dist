using System.ServiceModel;

namespace SoapApi.Constracts;

[ServiceContract]
public interface IUserContract
{
    public Task<> GetUserById(Guid userId, Cancellation Token cancellation token)
}