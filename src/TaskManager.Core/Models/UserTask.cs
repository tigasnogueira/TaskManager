namespace TaskManager.Core.Models;

public class UserTask
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public Guid ProjetoId { get; set; }
    public Project Projeto { get; set; }
}
