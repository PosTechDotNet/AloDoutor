using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloDoutor.Domain.Entity
{
    public class Especialidade: Entidade
    {   
        public string Nome { get; set; }
        public string? Descricao { get; set; }

        /* EF Relations */
        public IEnumerable<EspecialidadeMedico>? EspecialidadeMedicos { get; private set; }

        public Especialidade() { }
        public Especialidade(string nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
