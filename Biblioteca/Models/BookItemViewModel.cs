using Biblioteca.Entities;

namespace Biblioteca.Models;

public class BookItemViewModel
{
    public BookItemViewModel(string title, string autor)
    {
        Title = title;
        Autor = autor;
    }

    public string Title { get; set; }
    public string Autor { get; set; }


    public static BookItemViewModel FromEntity(Book book)
       => new BookItemViewModel(book.Title, book.Autor);

}
