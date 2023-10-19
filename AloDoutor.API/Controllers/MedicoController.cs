using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("Medico")]
    public class MedicoController :  MainController
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicoController(IMedicoRepository medicoRepository, IMapper mapper, IMedicoService medicoService)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos()));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id)));
        }

        [HttpGet("MedicoEspecialidades/{idMedico:guid}")]
        public async Task<ActionResult> ObterMedicoEspecialidadePorIdMedico(Guid idMedico)
        {
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterEspecialidadesPorIdMedico(idMedico)));
        }

        [HttpGet("Agendamento/{idMedico:guid}")]
        public async Task<ActionResult> ObterAgendamentoPorMedico(Guid idMedico)
        {
            return CustomResponse(_mapper.Map<MedicoViewModel>(await _medicoRepository.ObterAgendamentosPorIdMedico(idMedico)));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(MedicoDTO medicoDTO)
        {
            return CustomResponse(await _medicoService.Adicionar(_mapper.Map<Medico>(medicoDTO)));
        }

        [HttpPut()]
        public async Task<ActionResult> Atualizar(MedicoDTO medicoDTO)
        {
            return CustomResponse(await _medicoService.Atualizar(_mapper.Map<Medico>(medicoDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            return CustomResponse(await _medicoService.Remover(id));
        }
    }
}
