using ApiRestBooks.DTOs;

namespace ApiRestBooks.Repositories.Interfaces
{
    public interface IBookRepository
    {
        BookShowDTO Get();
        BookShowDTO Get(int id);
        Task<BookShowDTO> Post(BookCreateDTO bookCreateDTO);
        Task<BookShowDTO> Put(int id, BookCreateDTO bookCreateDTO);
        BookShowDTO Delete(int id);
    }
}
