using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace SoapApi.Services
{
    [ServiceContract]
    public interface IBookContract
    {
        [OperationContract]
        Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken);
    }
}
