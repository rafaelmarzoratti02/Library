namespace Biblioteca.Entities;

public class Loan : BaseEntity
{
    public Loan() { }
    public Loan(int idBook, int idUser)
    {
        IdBook = idBook;
        IdUser = idUser;
        StartDate = DateTime.Now;
        Deadline = StartDate.AddDays(14);
    }

    public int IdBook { get; set; }
    public Book Book { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime ReturnDate { get; set; }

    public void ReturnBook()
    {
        ReturnDate = DateTime.Now;
    }

}
 