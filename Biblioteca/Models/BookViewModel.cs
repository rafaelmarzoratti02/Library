using Biblioteca.Entities;

namespace Biblioteca.Models;

public class BookViewModel
{
    public BookViewModel(string title, string autor, string iSBN, int anoDePublicacao, List<string> loans)
    {
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
        Loans = loans;
    }

    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public List<string> Loans { get; set; }
    public static BookViewModel FromEntity(Book book)
    {
        var loans = book.Loans.Select(e => e.User.Name).ToList();
        return new BookViewModel(book.Title, book.Autor, book.ISBN, book.AnoDePublicacao, loans); 
    }
        
}
