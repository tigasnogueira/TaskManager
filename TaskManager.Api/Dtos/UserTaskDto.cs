using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos;

public class UserTaskDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(300, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime? DataUltimaAtualizacao { get; set; }

    public DateTime? DataUltimoLogin { get; set; }

    public bool Ativo { get; set; }

    public bool Excluido { get; set; }

    public Guid ProjectId { get; set; }
}
