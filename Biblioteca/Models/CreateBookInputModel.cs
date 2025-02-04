using Biblioteca.Entities;
using System.Net.Sockets;

namespace Biblioteca.Models;

public class CreateBookInputModel
{
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public Book ToEntity()
       => new(Title, Autor, ISBN, AnoDePublicacao);
}
