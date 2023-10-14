using AloDoutor.Domain.Entity;

namespace AloDoutor.Domain.Interfaces
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico> ObterPacientePorCPF(string cpf);
        Task<Medico> ObterPacientePorCRM(string crm);
    }
}
