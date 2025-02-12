namespace Library.Application.Models;

public class UpdateBookInputModel
{
    public int IdBook { get; set; }
    public string Title { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }

}
