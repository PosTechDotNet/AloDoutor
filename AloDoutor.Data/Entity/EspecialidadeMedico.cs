namespace AloDoutor.Domain.Entity
{
    public class EspecialidadeMedico : Entidade
    {   
        public Guid EspecialidadeId { get; set; }
        public Guid MedicoId { get; set; }
        public DateTime DataRegistro { get; set; }

        /* EF Relations */
        public Medico Medico { get; private set; }

        /* EF Relations */
        public Especialidade Especialidade { get; private set; }

        /* EF Relations */
        public IEnumerable<Agendamento>? Agendamentos { get; private set; }

        public EspecialidadeMedico() { }

        public EspecialidadeMedico(Guid especialidadeId, Guid medicoId, DateTime dataRegistro)
        {
            EspecialidadeId = especialidadeId;
            MedicoId = medicoId;
            DataRegistro = dataRegistro;           
        }
    }
}
