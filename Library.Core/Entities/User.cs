namespace Library.Core.Entities;

public class User : BaseEntity
{
    public User(string name, string email, DateTime birthdate, string password, string role) : base()
    {
        Name = name;
        Email = email;
        Birthdate = birthdate;
        Password = password;
        Role = role;
        Loans = [];
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public List<Loan> Loans { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }


    public void Update(string name, string email, DateTime birthdate)
    {
        Name = name;
        Email = email;
        Birthdate = birthdate;
    }
}
