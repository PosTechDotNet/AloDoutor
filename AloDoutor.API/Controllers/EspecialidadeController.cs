﻿using AloDoutor.Api.Application.DTO;
using AloDoutor.Api.Extentions;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("api/especialidade")]
    public class EspecialidadeController : MainController
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IEspecialidadeService _especialidadeService;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IEspecialidadeService especialidadeService, IMapper mapper)
        {
            _especialidadeRepository = especialidadeRepository;
            _especialidadeService = especialidadeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _especialidadeRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _especialidadeRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(EspecialidadeDTO especialidadeDTO)
        {
            return CustomResponse(await _especialidadeService.Adicionar(_mapper.Map<Especialidade>(especialidadeDTO)));
        }

        [HttpPut]
        public async  Task<ActionResult> Atualizar(EspecialidadeDTO especialidadeDTO)
        {
            return CustomResponse(await _especialidadeService.Atualizar(_mapper.Map<Especialidade>(especialidadeDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            return CustomResponse(await _especialidadeService.Remover(id));
        }
    }
}
