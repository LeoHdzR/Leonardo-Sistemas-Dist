using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoapApi.Models;
using SoapApi.Infrastructure;

namespace SoapApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RelationalDbContext _DbContext;

        public BookRepository(RelationalDbContext DbContext)
        {
            _context = context;
        }

        public async Task<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);
        }

        public async Task DeleteByIdAsync(Guid bookId, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(new object[] { bookId }, cancellationToken);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
