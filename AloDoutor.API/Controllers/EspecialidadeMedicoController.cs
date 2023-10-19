using AloDoutor.Api.Application.DTO;
using AloDoutor.Core.Controllers;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{

    [Route("api/especialidade-medico")]
    public class EspecialidadeMedicoController : MainController
    {
        private readonly IEspecialidadeMedicoRepository _especialidadeMedicoRepository;
        private readonly IEspecialidadeMedicoService _especialidadeMedicoService;
        private readonly IMapper _mapper;

        public EspecialidadeMedicoController(IEspecialidadeMedicoRepository especialidadeMedicoRepository, IMapper mapper, IEspecialidadeMedicoService especialidadeMedicoService)
        {
            _especialidadeMedicoRepository = especialidadeMedicoRepository;
            _mapper = mapper;
            _especialidadeMedicoService = especialidadeMedicoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _especialidadeMedicoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _especialidadeMedicoRepository.ObterPorId(id));
        }
       
        [HttpPost]
        public async Task<ActionResult> Adicionar(EspecialidadeMedicoDTO especialidadeDTO)
        {
            return CustomResponse(await _especialidadeMedicoService.Adicionar(_mapper.Map<EspecialidadeMedico>(especialidadeDTO)));
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(EspecialidadeMedicoDTO especialidadeDTO)
        {
            return CustomResponse(await _especialidadeMedicoService.Atualizar(_mapper.Map<EspecialidadeMedico>(especialidadeDTO)));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            return CustomResponse(await _especialidadeMedicoService.Remover(id));
        }
    }
}
