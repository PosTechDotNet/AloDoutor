using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloDoutor.Domain.Entity
{
    public class Medico : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }

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
