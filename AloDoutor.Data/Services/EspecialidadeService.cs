using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using FluentValidation.Results;

namespace AloDoutor.Domain.Services
{
    public class EspecialidadeService : CommandHandler, IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeService(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        public async Task<ValidationResult> Adicionar(Especialidade especialidade)
        {
            var especialidadeCadastrada = await _especialidadeRepository.ObterPorNome(especialidade.Nome);

            if(especialidadeCadastrada != null)
            {
                AdicionarErro("Essa especialidade já está cadastrada!");
                return ValidationResult;
            }

            _especialidadeRepository.Adicionar(especialidade);

            return await PersistirDados(_especialidadeRepository.UnitOfWork);
            
        }

        public async Task<ValidationResult> Atualizar(Especialidade especialidade)
        {
            var especialidadeCadastrada = await _especialidadeRepository.ObterPorId(especialidade.Id);

            if(especialidadeCadastrada == null)
            {
                AdicionarErro("Especialidade não localizada!");
                return ValidationResult;
            }
            especialidadeCadastrada.Nome = especialidade.Nome;
            especialidadeCadastrada.Descricao = especialidade.Descricao;
            _especialidadeRepository.Atualizar(especialidadeCadastrada);

            return await PersistirDados(_especialidadeRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Remover(Guid id)
        {
            var especialidadeCadastrada = await _especialidadeRepository.ObterPorId(id);

            if (especialidadeCadastrada == null)
            {
                AdicionarErro("Especialidade não localizada!");
                return ValidationResult;
            }

            _especialidadeRepository.Remover(especialidadeCadastrada);

            return await PersistirDados(_especialidadeRepository.UnitOfWork);
        }
    }
}
