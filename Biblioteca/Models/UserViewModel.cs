using Biblioteca.Entities;

namespace Library.Models;

public class UserViewModel
{
    public UserViewModel(string name, string email, DateTime birthdate)
    {
        Name = name;
        Email = email;
        Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }

    public static UserViewModel FromEntity(User user) =>
        new UserViewModel(user.Name, user.Email, user.Birthdate);
}
