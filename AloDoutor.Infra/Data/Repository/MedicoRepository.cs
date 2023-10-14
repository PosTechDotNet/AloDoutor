using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AloDoutor.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloDoutor.Infra.Data.Repository
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(MeuDbContext context) : base(context) { }

        public async Task<Medico> ObterPacientePorCPF(string cpf)
        {
            return await DbSet.FirstOrDefaultAsync<Medico>(p => p.Cpf == cpf);
        }

        public async Task<Medico> ObterPacientePorCRM(string crm)
        {
            return await DbSet.FirstOrDefaultAsync<Medico>(p => p.Crm == crm);
        }
    }
}
