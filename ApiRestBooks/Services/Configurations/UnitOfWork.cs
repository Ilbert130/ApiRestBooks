using ApiRestBooks.Repositories;
using ApiRestBooks.Repositories.Interfaces;
using AutoMapper;

namespace ApiRestBooks.Configurations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookRepository Book { get; private set; }
        public UnitOfWork(IMapper mapper)
        {
            Book = new BookRepository(mapper);
        }
    }
}
