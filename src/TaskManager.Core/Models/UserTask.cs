using TaskManager.Core.Models.Enums;

namespace TaskManager.Core.Models;

public class UserTask : Entity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Comentarios { get; set; }
    public Priority Prioridade { get; private set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public Guid ProjetoId { get; set; }
    public Project Projeto { get; set; }

    public UserTask(string nome, string descricao, Priority prioridade, Guid projetoId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Prioridade = prioridade;
        DataCriacao = DateTime.Now;
        ProjetoId = projetoId;
        Ativo = true;
        Excluido = false;
    }

    public void SetPrioridade(Priority novaPrioridade)
    {
        if (Prioridade != novaPrioridade)
        {
            Prioridade = novaPrioridade;
        }
    }
}
