﻿namespace TaskManager.Core.Models;

public class User : Entity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public DateTime? DataUltimoLogin { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public ICollection<Project> Projetos { get; set; }
}
