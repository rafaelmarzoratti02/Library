using Biblioteca.Entities;

namespace Biblioteca.Models;

public class BookViewModel
{
    public BookViewModel(string title, string autor, string iSBN, int anoDePublicacao)
    {
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
    }

    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public static BookViewModel FromEntity(Book book) 
        => new BookViewModel(book.Title, book.Autor, book.ISBN, book.AnoDePublicacao);
}
