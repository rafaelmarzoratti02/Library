using Library.Core.Entities;

namespace Library.Application.Models;

public class CreateBookInputModel
{
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public Book ToEntity()
       => new(Title, Autor, ISBN, AnoDePublicacao);
}
