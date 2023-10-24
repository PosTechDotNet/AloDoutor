using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AloDoutor.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Authorize]
    [Route("Paciente")]
    public class PacienteController : MainController<PacienteController>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PacienteController(IPacienteRepository pascienteRepository, IPacienteService pacienteService, IMapper mapper,
            ILogger<PacienteController> logger) : base(logger)
        {
            _pacienteRepository = pascienteRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            _logger.LogInformation("Endpoint de obtenção de todos pacientes cadastrados.");
            return CustomResponse(await _pacienteRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            _logger.LogInformation("Endpoint de obtenção de paciente por Id.");
            return CustomResponse(await _pacienteRepository.ObterPorId(id));
        }

        [HttpGet("Agendamento/{idPaciente:guid}")]
        public async Task<ActionResult> ObterAgendamentoPorPaciente(Guid idPaciente)
        {
            _logger.LogInformation("Endpoint para obtenção de agendamento por paciente.");
            return CustomResponse(_mapper.Map<PacienteViewModel>(await _pacienteRepository.ObterAgendamentosPorIdPaciente(idPaciente)));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(PacienteDTO pacienteDTO)
        {
            _logger.LogInformation("Endpoint para cadastramento de paciente.");

            var validation = await _pacienteService.Adicionar(_mapper.Map<Paciente>(pacienteDTO));
            return validation.IsValid ? Created("", pacienteDTO) : CustomResponse(validation);
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(PacienteDTO pacienteDTO)
        {
            _logger.LogInformation("Endpoint para alteração de cadastro do paciente.");
            return CustomResponse(await _pacienteService.Atualizar(_mapper.Map<Paciente>(pacienteDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            _logger.LogInformation("Endpoint para excluir cadastro do paciente.");
            return CustomResponse(await _pacienteService.Remover(id));
        }
    }
}
