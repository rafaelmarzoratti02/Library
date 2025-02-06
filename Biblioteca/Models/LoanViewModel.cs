using Biblioteca.Entities;

namespace Library.Models;

public class LoanViewModel
{
    public LoanViewModel(int id, int bookId, string bookTitle, int userId, string userName, DateTime startDate, DateTime deadline, DateTime returnDate)
    {
        Id = id;
        IdBook = bookId;
        BookTitle = bookTitle;
        IdUser = userId;
        UserName = userName;
        StartDate = startDate;
        Deadline = deadline;
        ReturnDate = returnDate;
    }

    public int Id { get; set; }
    public string BookTitle { get; set; }
    public int IdBook { get; set; }
    public string UserName { get; set; }
    public int IdUser { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime ReturnDate { get; set; }

    public static LoanViewModel FromEntity(Loan loan) =>
        new LoanViewModel(loan.Id, loan.IdBook, loan.Book.Title, loan.IdUser, loan.User.Name, loan.StartDate, loan.Deadline, loan.ReturnDate);
}
