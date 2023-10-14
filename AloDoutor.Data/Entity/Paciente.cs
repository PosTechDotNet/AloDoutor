using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloDoutor.Domain.Entity
{
    public class Paciente: Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public string Estado { get; private set; }
        public string Idade { get; private set; }
        public string Telefone { get; private set; }
        public IEnumerable<Agendamento>? Agendamentos { get; private set; }
    }
}
