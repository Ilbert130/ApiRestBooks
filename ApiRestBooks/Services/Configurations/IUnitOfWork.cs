using ApiRestBooks.Repositories.Interfaces;

namespace ApiRestBooks.Configurations
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
    }
}
