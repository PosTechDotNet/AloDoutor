using AloDoutor.Dto;

namespace AloDoutor.Entity;

public class EspecialidadeMedico : Entidade
{
    public int EspecialidadeId { get; set; }
    public string EspecialidadeNome { get; set; }
    public EspecialidadeMedico() { }
    public EspecialidadeMedico(CadastrarEspecialidadeDTO cadastrarEspecialidadeDTO)
    {
        EspecialidadeId = cadastrarEspecialidadeDTO.EspecialidadeId;
        EspecialidadeNome = cadastrarEspecialidadeDTO.Especialidade;
    }
    public EspecialidadeMedico(AlterarEspecialidadeDTO alterarEspecialidadeDTO)
    {
        Id = alterarEspecialidadeDTO.Id;
        EspecialidadeId = alterarEspecialidadeDTO.EspecialidadeId;
        EspecialidadeNome = alterarEspecialidadeDTO.Especialidade;
    }

}
