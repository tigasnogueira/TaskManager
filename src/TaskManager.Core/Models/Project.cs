namespace TaskManager.Core.Models;

public class Project : Entity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public Guid UsuarioId { get; set; }
    public User Usuario { get; set; }
    public ICollection<UserTask> Tarefas { get; set; }
}
