using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SoapApi.Models;

namespace SoapApi.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken);
        Task DeleteByIdAsync(Guid bookId, CancellationToken cancellationToken);
    }
}
