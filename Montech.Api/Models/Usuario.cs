namespace Montech.Api.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public Usuario()
    {
        Id = Guid.NewGuid();
    }
}
