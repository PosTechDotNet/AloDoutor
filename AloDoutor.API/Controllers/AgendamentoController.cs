using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Extentions;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("api/agendamento")]
    public class AgendamentoController : MainController
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Adicionar(AgendamentoDTO agendamentoDTO)
        {
            return CustomResponse(await _agendamentoService.Adicionar(_mapper.Map<Agendamento>(agendamentoDTO)));
        }

        [HttpPut("Cancelar")]
        public async Task<ActionResult> Cancelar(Guid id)
        {
            return CustomResponse(await _agendamentoService.Cancelar(id));
        }
    }
}
