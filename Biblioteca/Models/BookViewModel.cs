using Biblioteca.Entities;

namespace Biblioteca.Models;

public class BookViewModel
{
    public BookViewModel(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    
    public static BookViewModel FromEntity(Book book) 
        => new BookViewModel(book.Title);
}
