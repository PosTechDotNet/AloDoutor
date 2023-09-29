using AloDoutor.Entity;

namespace AloDoutor.Dto;

public class AlterarPacienteDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string Endereco { get; set; }
    public string Estado { get; set; }
    public int Idade { get; set; }
    public int Telefone { get; set; }
}
