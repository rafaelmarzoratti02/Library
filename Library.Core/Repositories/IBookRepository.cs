using Library.Core.Entities;


namespace Library.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book> GetDetailsById(int id);
    Task<Book> GetById(int id);
    Task<int> Add(Book book);
    Task Update(Book book);
}
