namespace AloDoutor.Domain.Entity
{
    public class Medico : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Estado { get; private set; }
        public string Crm { get; private set; }
        public string Telefone { get; private set; }

        public IEnumerable<EspecialidadeMedico>? EspecialidadesMedicos { get; private set; }

        public Medico() { }
        public Medico(string nome, string cpf, string cep, string endereco, string estado, string crm, string telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Cep = cep;
            Endereco = endereco;
            Estado = estado;
            Crm = crm;
            Telefone = telefone;
        }
    }
}
