using CinemaPipocando.Requests;

namespace CinemaPipocando.Models;

public class Filme
{
    public Filme(string nome)
    {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;
    }

    public Guid Id { get; init; }
    public string Nome { get; private set; } = string.Empty;
    public bool Ativo { get; set; }

    public void ChangeName(string name)
    {
        Nome = name;
    }
    public void SetInactive()
    {
        Ativo = false;
    }
}
