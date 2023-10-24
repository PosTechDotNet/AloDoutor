using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AloDoutor.Domain.Services;
using AloDoutor.Infra.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Authorize]
    [Route("api/especialidade")]
    public class EspecialidadeController : MainController<EspecialidadeController>
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IEspecialidadeService _especialidadeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IEspecialidadeService especialidadeService, 
            IMapper mapper, ILogger<EspecialidadeController> logger) : base(logger)
        {
            _especialidadeRepository = especialidadeRepository;
            _especialidadeService = especialidadeService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            _logger.LogInformation("Endpoint de obtenção de todas especialidades cadastradas.");
            return CustomResponse(await _especialidadeRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            _logger.LogInformation("Endpoint de obtenção de especialidade Id.");
            return CustomResponse(await _especialidadeRepository.ObterPorId(id));
        }

        [HttpGet("EspecialidadeMedicos/{idEspecialidade:guid}")]
        public async Task<ActionResult> ObterMedicoEspecialidadePorIdMedico(Guid idEspecialidade)
        {
            _logger.LogInformation("Endpoint para obtenção de especialidade do medico por Id do medico.");
            return CustomResponse(_mapper.Map<EspecialidadeViewModel>(await _especialidadeRepository.ObterMedicosPorEspecialidadeId(idEspecialidade)));
        }


        [HttpPost]
        public async Task<ActionResult> Adicionar(EspecialidadeDTO especialidadeDTO)
        {
            _logger.LogInformation("Endpoint para cadastramento de especialidade.");            

            var validation =  await _especialidadeService.Adicionar(_mapper.Map<Especialidade>(especialidadeDTO));
            return validation.IsValid ? Created("", especialidadeDTO) : CustomResponse(validation);
        }

        [HttpPut]
        public async  Task<ActionResult> Atualizar(EspecialidadeDTO especialidadeDTO)
        {
            _logger.LogInformation("Endpoint para alteração de cadastro da especialidade.");
            return CustomResponse(await _especialidadeService.Atualizar(_mapper.Map<Especialidade>(especialidadeDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            _logger.LogInformation("Endpoint para excluir cadastro da especialidade.");
            return CustomResponse(await _especialidadeService.Remover(id));
        }
    }
}
