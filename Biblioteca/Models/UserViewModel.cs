using Biblioteca.Entities;

namespace Library.Models;

public class UserViewModel
{
    public UserViewModel(string name, string email, DateTime birthdate, List<string> loans)
    {
        Name = name;
        Email = email;
        Birthdate = birthdate;
        Loans = loans;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public List<string> Loans { get; set; }

    public static UserViewModel FromEntity(User user) { 
        var loans = user.Loans.Select(e=> e.Book.Title).ToList();
        return new UserViewModel(user.Name, user.Email, user.Birthdate, loans);
    }
}
