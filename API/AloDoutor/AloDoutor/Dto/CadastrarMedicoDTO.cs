namespace AloDoutor.Dto;

public class CadastrarMedicoDTO
{
    public string? Nome { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Estado { get; set; }
    public int Idade { get; set; }
    public int Telefone { get; set; }
    public int Crm { get; set; }
    public int EspecialidadeId { get; set; }
}
