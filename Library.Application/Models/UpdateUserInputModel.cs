namespace Library.Application.Models;

public class UpdateUserInputModel
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }

}
