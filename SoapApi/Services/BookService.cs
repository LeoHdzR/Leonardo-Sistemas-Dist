using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using SoapApi.Repositories;
using SoapApi.Models;

namespace SoapApi.Services
{
    public class BookService : IBookContract
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken)
        {
            // Buscar el libro por su Id
            var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);

            // Si el libro no existe, lanzar una excepción
            if (book == null)
            {
                throw new FaultException("BookNotFound: The book with the given ID does not exist.");
            }

            // Eliminar el libro
            await _bookRepository.DeleteByIdAsync(bookId, cancellationToken);

            // Devolver true si se eliminó correctamente
            return true;
        }
    }
}
