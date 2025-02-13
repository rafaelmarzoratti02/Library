using Library.Core.Entities;

namespace Library.Application.Models;

public class CreateLoanInputModel
{

    public int IdBook { get; set; }
    public int IdUser { get; set; }

    public Loan ToEntity()
        => new(IdBook, IdUser);
}
