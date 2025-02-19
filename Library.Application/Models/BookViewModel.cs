using Library.Core.Entities;

namespace Library.Application.Models;

public class BookViewModel
{
    public BookViewModel(int id,string title, string autor, string iSBN, int anoDePublicacao, List<string> loans)
    {
        Id = id;
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
        Loans = loans;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public List<string> Loans { get; set; }
    public static BookViewModel FromEntity(Book book)
    {
        var loans = book.Loans.Select(e => e.User.Name).ToList();
        return new BookViewModel(book.Id,book.Title, book.Autor, book.ISBN, book.AnoDePublicacao, loans);
    }

}
