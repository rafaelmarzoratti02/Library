﻿namespace Library.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string autor, string iSBN, int anoDePublicacao) : base()
    {
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
        Loans = [];
    }

    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
    public List<Loan> Loans { get; set; }


    public void Update(string title, string autor, string iSBN, int anoDePublicacao)
    {
        Title = title;
        Autor = autor;
        ISBN = iSBN;
        AnoDePublicacao = anoDePublicacao;
    }

}
