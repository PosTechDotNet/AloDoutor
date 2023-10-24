using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Core.Usuario;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace AloDoutor.Api.Controllers
{
    [Authorize]
    [Route("api")]
    public class AgendamentoController : MainController<AgendamentoController>
    {
        private readonly IAspNetUser _user;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper, 
            IAgendamentoRepository agendamentoRepository, ILogger<AgendamentoController> logger, IAspNetUser user) : base(logger)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
            _agendamentoRepository = agendamentoRepository;
            _logger = logger;
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            _logger.LogInformation("Endpoint de obtenção de todos agendamentos cadastradas.");
            return CustomResponse(await _agendamentoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            _logger.LogInformation("Endpoint de obtenção de agendamento por Id.");
            return CustomResponse(await _agendamentoRepository.ObterPorId(id));
        }

        [HttpGet("Por-status/{status:int}")]
        public async Task<ActionResult> ObterAgendamentoPorStatus(int status)
        {
            _logger.LogInformation("Endpoint de obtenção de agendamento por status.");
            return CustomResponse(_mapper.Map<IEnumerable<AgendamentoViewModel>>(await _agendamentoRepository.ObterAgendamentosPorIStatus(status)));
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Adicionar(AgendamentoDTO agendamentoDTO)
        {
            _logger.LogInformation("Endpoint para cadastramento de agendamento.");
            var validation = await _agendamentoService.Adicionar(_mapper.Map<Agendamento>(agendamentoDTO));            
            return validation.IsValid ? Created("", agendamentoDTO) : CustomResponse(validation);
        }

        [HttpPut("Reagendar/{id:guid}/{data:datetime}")]
        public async Task<ActionResult> Cancelar(Guid id, DateTime data)
        {
            _logger.LogInformation("Endpoint para realizar um reagendamento.");
            return CustomResponse(await _agendamentoService.Reagendar(id, data));
        }

        [HttpPut("Cancelar")]
        public async Task<ActionResult> Cancelar(Guid id)
        {
            _logger.LogInformation("Endpoint para cancelar o agendamento por id.");
            return CustomResponse(await _agendamentoService.Cancelar(id));
        }
    }
}
