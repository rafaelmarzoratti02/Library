using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.BookCommands.UpdateBook;

public class UpdateBookCommand : IRequest<ResultViewModel>
{
    public UpdateBookCommand(int idBook, string title, string autor, string iSBN, int anoDePublicacao)
    {
        IdBook = idBook;
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
    }

    public int IdBook { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
}
