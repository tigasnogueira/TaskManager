using System.ComponentModel.DataAnnotations;

namespace TaskManager.Api.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
    public string Senha { get; set; }

    public DateTime DataCriacao { get; set; }
    
    public DateTime? DataUltimaAtualizacao { get; set; }
    
    public DateTime? DataUltimoLogin { get; set; }
    
    public bool Ativo { get; set; }
    
    public bool Excluido { get; set; }
    
    public ICollection<ProjectDto> Projetos { get; set; }
    
    public ICollection<UserTaskDto> Tarefas { get; set; }
}
