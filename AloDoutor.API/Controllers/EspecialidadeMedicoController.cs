using AloDoutor.Api.Application.DTO;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{

    [Route("api/especialidade-medico")]
    public class EspecialidadeMedicoController : MainController<EspecialidadeMedicoController>
    {
        private readonly IEspecialidadeMedicoRepository _especialidadeMedicoRepository;
        private readonly IEspecialidadeMedicoService _especialidadeMedicoService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EspecialidadeMedicoController(IEspecialidadeMedicoRepository especialidadeMedicoRepository,
            IMapper mapper, IEspecialidadeMedicoService especialidadeMedicoService, ILogger<EspecialidadeMedicoController> logger) : base(logger)
        {
            _especialidadeMedicoRepository = especialidadeMedicoRepository;
            _mapper = mapper;
            _especialidadeMedicoService = especialidadeMedicoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            _logger.LogInformation("Endpoint de obtenção de todas especialidades de medico cadastradas.");
            return CustomResponse(await _especialidadeMedicoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            _logger.LogInformation("Endpoint de obtenção de especialidades de medico por Id.");
            return CustomResponse(await _especialidadeMedicoRepository.ObterPorId(id));
        }
       
        [HttpPost]
        public async Task<ActionResult> Adicionar(EspecialidadeMedicoDTO especialidadeDTO)
        {
            _logger.LogInformation("Endpoint para cadastramento de especialidades do medico.");
            return CustomResponse(await _especialidadeMedicoService.Adicionar(_mapper.Map<EspecialidadeMedico>(especialidadeDTO)));
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(EspecialidadeMedicoDTO especialidadeDTO)
        {
            _logger.LogInformation("Endpoint para alteração de cadastro da especialidades do medico.");
            return CustomResponse(await _especialidadeMedicoService.Atualizar(_mapper.Map<EspecialidadeMedico>(especialidadeDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            _logger.LogInformation("Endpoint para excluir cadastro da especialidades do medico.");
            return CustomResponse(await _especialidadeMedicoService.Remover(id));
        }
    }
}
