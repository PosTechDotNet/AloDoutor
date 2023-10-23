using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Core.Usuario;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Authorize]
    [Route("api")]
    public class AgendamentoController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper, IAgendamentoRepository agendamentoRepository, IAspNetUser user)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
            _agendamentoRepository = agendamentoRepository;
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _agendamentoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _agendamentoRepository.ObterPorId(id));
        }

        [HttpGet("Por-status/{status:int}")]
        public async Task<ActionResult> ObterAgendamentoPorStatus(int status)
        {
            return CustomResponse(_mapper.Map<IEnumerable<AgendamentoViewModel>>(await _agendamentoRepository.ObterAgendamentosPorIStatus(status)));
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Adicionar(AgendamentoDTO agendamentoDTO)
        {
            return CustomResponse(await _agendamentoService.Adicionar(_mapper.Map<Agendamento>(agendamentoDTO)));
        }

        [HttpPut("Reagendar/{id:guid}/{data:datetime}")]
        public async Task<ActionResult> Cancelar(Guid id, DateTime data)
        {
            return CustomResponse(await _agendamentoService.Reagendar(id, data));
        }

        [HttpPut("Cancelar")]
        public async Task<ActionResult> Cancelar(Guid id)
        {
            return CustomResponse(await _agendamentoService.Cancelar(id));
        }
    }
}
