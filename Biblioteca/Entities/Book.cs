using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Entities;

public class Book : BaseEntity
{
    public Book(string title, string autor, string iSBN, int anoDePublicacao)
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


    public void Update(string title, string autor, string iSBN, int anoDePublicacao)
    {
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
    }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}
 