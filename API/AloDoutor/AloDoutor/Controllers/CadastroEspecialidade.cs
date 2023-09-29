using AloDoutor.Dto;
using AloDoutor.Entity;
using AloDoutor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Controllers;

[ApiController]
[Route("Especialidade")]
public class CadastroEspecialidade :  ControllerBase
{
    private IRepository<EspecialidadeMedico> _especialidadeRepository;

    public CadastroEspecialidade(IRepository<EspecialidadeMedico> especialidadeRepository)
    {
        _especialidadeRepository = especialidadeRepository;
    }

    [HttpPost("Cadastro-Especialidade")]
    public IActionResult CadastrarEspecialidade(CadastrarEspecialidadeDTO especialidadeDTO)
    {
        _especialidadeRepository.Cadastrar(new EspecialidadeMedico(especialidadeDTO));
        return Ok();
    }

    [HttpPut("Alterar-Especialidade")]
    public IActionResult AlterarEspecialidade(AlterarEspecialidadeDTO especialidadeDTO)
    {
        _especialidadeRepository.Alterar(new EspecialidadeMedico(especialidadeDTO));
        return Ok("Especialidade alterada com sucesso!");
    }

    [HttpDelete("Deleta-Especialidade")]
    public IActionResult DeletaEspecialidade(int id)
    {
        _especialidadeRepository.Deletar(id);
        return Ok("Especialidade deletada com sucesso!");
    }

    [HttpGet("Obter-todas-especialidades")]
    public IActionResult ObtemTodasEspecialidades()
    {
        try
        {
            return Ok(_especialidadeRepository.ObterTodos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
