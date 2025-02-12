using Library.Core.Entities;

namespace Library.Application.Models;

public class UserViewModel
{
    public UserViewModel(int id, string name, string email, DateTime birthdate, List<string> loans)
    {
        Id = id;
        Name = name;
        Email = email;
        Birthdate = birthdate;
        Loans = loans;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public List<string> Loans { get; set; }

    public static UserViewModel FromEntity(User user)
    {
        var loans = user.Loans.Select(e => e.Book.Title).ToList();
        return new UserViewModel(user.Id, user.Name, user.Email, user.Birthdate, loans);
    }
}
