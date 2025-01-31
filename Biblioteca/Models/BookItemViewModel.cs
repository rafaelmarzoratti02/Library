using Biblioteca.Entities;

namespace Biblioteca.Models;

public class BookItemViewModel
{
    public BookItemViewModel(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public static BookItemViewModel FromEntity(Book book)
       => new BookItemViewModel(book.Title);

}
