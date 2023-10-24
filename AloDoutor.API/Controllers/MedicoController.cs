using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    //[Authorize]
    [Route("Medico")]
    public class MedicoController :  MainController<MedicoController>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public MedicoController(IMedicoRepository medicoRepository, IMapper mapper, IMedicoService medicoService, ILogger<MedicoController> logger) : base(logger)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
            _medicoService = medicoService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            _logger.LogInformation("Endpoint de obtenção de todos medicos cadastrados.");
            return CustomResponse(_mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            _logger.LogInformation("Endpoint de obtenção de medico por Id.");
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id)));
        }

        [HttpGet("MedicoEspecialidades/{idMedico:guid}")]
        public async Task<ActionResult> ObterMedicoEspecialidadePorIdMedico(Guid idMedico)
        {
            _logger.LogInformation("Endpoint para obtenção de especialidade do medico por Id do medico.");
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterEspecialidadesPorIdMedico(idMedico)));
        }

        [HttpGet("Agendamento/{idMedico:guid}")]
        public async Task<ActionResult> ObterAgendamentoPorMedico(Guid idMedico)
        {
            _logger.LogInformation("Endpoint para obtenção de agendamento por medico.");
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterAgendamentosPorIdMedico(idMedico)));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(MedicoDTO medicoDTO)
        {
            //verificar o custom response para created
            _logger.LogInformation("Endpoint para cadastramento de medico.");
            var validation = await _medicoService.Adicionar(_mapper.Map<Medico>(medicoDTO));
           return validation.IsValid ?  Created("", medicoDTO) :  CustomResponse(validation);         
        }

        [HttpPut()]
        public async Task<ActionResult> Atualizar(MedicoDTO medicoDTO)
        {
            _logger.LogInformation("Endpoint para alteração de cadastro do medico.");
            return CustomResponse(await _medicoService.Atualizar(_mapper.Map<Medico>(medicoDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            _logger.LogInformation("Endpoint para excluir cadastro do medico.");
            return CustomResponse(await _medicoService.Remover(id));
        }
    }
}
