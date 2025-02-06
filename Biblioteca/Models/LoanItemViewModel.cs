using Biblioteca.Entities;

namespace Library.Models;

public class LoanItemViewModel
{
    public LoanItemViewModel(int id, string bookTitle, string userName, DateTime deadline)
    {
        Id = id;
        BookTitle = bookTitle;
        UserName = userName;
        Deadline = deadline;
    }

    public int Id { get; set; }
    public string BookTitle { get; set; }
    public string UserName { get; set; }
    public  DateTime Deadline { get; set; }

    public static LoanItemViewModel FromEntity(Loan loan) =>
        new LoanItemViewModel(loan.Id, loan.Book.Title, loan.User.Name, loan.Deadline);

}
