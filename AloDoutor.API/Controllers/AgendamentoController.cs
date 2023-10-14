using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Extentions;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AloDoutor.Infra.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("api")]
    public class AgendamentoController : MainController
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper, IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
            _agendamentoRepository = agendamentoRepository;
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
