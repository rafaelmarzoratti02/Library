using Library.Core.Entities;

namespace Library.Application.Models;

public class BookSyncModel
{
    public BookSyncModel(int id, string title, string autor, string isbn, int anoDePublicacao)
    {
        Id = id;
        Title = title;
        Autor = autor;
        ISBN = isbn;
        AnoDePublicacao = anoDePublicacao;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    
    public static BookSyncModel FromEntity(Book book)
        => new BookSyncModel(book.Id, book.Title, book.Autor,  book.ISBN, book.AnoDePublicacao);
}