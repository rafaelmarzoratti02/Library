using Library.Core.Entities;

namespace Library.Application.Models;

public class BookItemViewModel
{
    public BookItemViewModel(int id, string title, string autor)
    {
        Id = id;
        Title = title;
        Autor = autor;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }


    public static BookItemViewModel FromEntity(Book book)
       => new BookItemViewModel(book.Id, book.Title, book.Autor);

}
