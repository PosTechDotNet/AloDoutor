﻿using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Application.ViewModel;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Authorize]
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

        [HttpGet("Agendamento/{idPaciente:guid}")]
        public async Task<ActionResult> ObterAgendamentoPorPaciente(Guid idPaciente)
        {
            return CustomResponse(_mapper.Map<PacienteViewModel>(await _pacienteRepository.ObterAgendamentosPorIdPaciente(idPaciente)));
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
