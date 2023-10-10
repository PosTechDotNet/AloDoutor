using AloDoutor.Api.Extentions;
using AloDoutor.Domain.Entity;
using AloDoutor.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Api.Controllers
{
    [Route("api/especialidade")]
    public class EspecialidadeController : MainController
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IEspecialidadeService _especialidadeService;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository, IEspecialidadeService especialidadeService)
        {
            _especialidadeRepository = especialidadeRepository;
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(await _especialidadeRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _especialidadeRepository.ObterTodos());
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(Especialidade especialidade)
        {
            return CustomResponse(await _especialidadeService.Adicionar(especialidade));
        }

        [HttpPut]
        public async  Task<ActionResult> Atualizar(Especialidade especialidade)
        {
            return CustomResponse(await _especialidadeService.Atualizar(especialidade));
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(Guid id)
        {
            return CustomResponse(await _especialidadeService.Remover(id));
        }
    }
}
