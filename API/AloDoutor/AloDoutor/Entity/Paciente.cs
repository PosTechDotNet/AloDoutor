using AloDoutor.Dto;

namespace AloDoutor.Entity;

public class Paciente : Entidade
{
    public string Nome { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string Endereco { get; set; }
    public string Estado { get; set; }
    public int Idade { get; set; }
    public int Telefone { get; set; }

    public Paciente() { }

    public Paciente(CadastrarPacienteDTO cadastrarPacienteDTO)
    {
        Nome = cadastrarPacienteDTO.Nome;
        Cpf = cadastrarPacienteDTO.Cpf;
        Cep = cadastrarPacienteDTO.Cep;
        Endereco = cadastrarPacienteDTO.Endereco;
        Estado = cadastrarPacienteDTO.Estado;
        Idade = cadastrarPacienteDTO.Idade;
        Telefone = cadastrarPacienteDTO.Telefone;
    }

    public Paciente(AlterarPacienteDTO alterarPacienteDTO)
    {
        Id = alterarPacienteDTO.Id;
        Nome = alterarPacienteDTO.Nome;
        Cpf = alterarPacienteDTO.Cpf;
        Cep = alterarPacienteDTO.Cep;
        Endereco = alterarPacienteDTO.Endereco;
        Estado = alterarPacienteDTO.Estado;
        Idade = alterarPacienteDTO.Idade;
        Telefone = alterarPacienteDTO.Telefone;
    }
}
