using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Extentions;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AloDoutor.Domain.Services;
using AloDoutor.Infra.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("Paciente")]
    public class PacienteController : MainController
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository pascienteRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteRepository = pascienteRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _pacienteRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _pacienteRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(PacienteDTO pacienteDTO)
        {
            return CustomResponse(await _pacienteService.Adicionar(_mapper.Map<Paciente>(pacienteDTO)));
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(PacienteDTO pacienteDTO)
        {
            return CustomResponse(await _pacienteService.Atualizar(_mapper.Map<Paciente>(pacienteDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            return CustomResponse(await _pacienteService.Remover(id));
        }
    }
}
