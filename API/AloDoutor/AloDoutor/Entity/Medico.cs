using AloDoutor.Dto;
using static System.Net.Mime.MediaTypeNames;

namespace AloDoutor.Entity;

public class Medico : Entidade
{

    public string Nome { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string Endereco { get; set; }
    public string Estado { get; set; }
    public int Crm { get; set; }
    public int Telefone { get; set; }
    public int EspecialidadeId { get; set; }
    public virtual EspecialidadeMedico Especialidade {  get; set; }

    public Medico() { }
    public Medico(CadastrarMedicoDTO cadastrarMedicoDTO)
    {
        Nome = cadastrarMedicoDTO.Nome;
        Cpf = cadastrarMedicoDTO.Cpf;
        Cep = cadastrarMedicoDTO.Cep;
        Endereco = cadastrarMedicoDTO.Endereco;
        Estado = cadastrarMedicoDTO.Estado;
        Crm = cadastrarMedicoDTO.Crm;
        Telefone = cadastrarMedicoDTO.Telefone;
        EspecialidadeId = cadastrarMedicoDTO.EspecialidadeId;
    }
    public Medico(AlterarMedicoDTO alterarMedicoDTO)
    {
        Id = alterarMedicoDTO.Id;
        Nome = alterarMedicoDTO.Nome;
        Cpf = alterarMedicoDTO.Cpf;
        Cep = alterarMedicoDTO.Cep;
        Endereco = alterarMedicoDTO.Endereco;
        Estado = alterarMedicoDTO.Estado;
        Crm = alterarMedicoDTO.Crm;
        Telefone = alterarMedicoDTO.Telefone;
    }
}
