using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Commands.BookCommands.InsertBook;

public class InsertBookCommand : IRequest<ResultViewModel<int>>
{
    public InsertBookCommand(string title, string autor, string iSBN, int anoDePublicacao)
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
    public Book ToEntity()
       => new(Title, Autor, ISBN, AnoDePublicacao);
}
