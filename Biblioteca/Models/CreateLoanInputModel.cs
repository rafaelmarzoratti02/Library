using Biblioteca.Entities;

namespace Library.Models;

public class CreateLoanInputModel
{
    public int IdBook { get; set; }
    public int IdUser { get; set; }

    public Loan ToEntity() 
        =>  new (IdBook, IdUser);
}
