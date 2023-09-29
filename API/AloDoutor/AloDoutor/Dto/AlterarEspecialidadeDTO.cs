using AloDoutor.Entity;

namespace AloDoutor.Dto;

public class AlterarEspecialidadeDTO
{
    public int Id { get; set; }
    public int EspecialidadeId { get; set; }
    public string? Especialidade { get; set; }
}
