using AloDoutor.Dto;
using AloDoutor.Entity;
using AloDoutor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Controllers;

[ApiController]
[Route("Medico")]
public class CadastroMedicoController : ControllerBase
{
    private IRepository<Medico> _medicoRepository;

    public CadastroMedicoController(IRepository<Medico> medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    [HttpPost("Cadastrar-Medico")]
    public IActionResult CadastrarMedico(CadastrarMedicoDTO medicoDTO)
    {
        _medicoRepository.Cadastrar(new Medico(medicoDTO));
        var mensagem = $"Medico cadastrado com sucesso! | Nome: {medicoDTO.Nome}";
        return Ok(mensagem);
    }



    [HttpPut("Alterar-Medico")]
    public IActionResult AlterarMedico(AlterarMedicoDTO medicoDTO)
    {
        _medicoRepository.Alterar(new Medico(medicoDTO));
        return Ok("Medico alterado com sucesso!");
    }

    [HttpDelete("Deletar-Medico")]
    public IActionResult DeletarMedico(int id)
    {
        _medicoRepository.Deletar(id);
        return Ok("Medico deletado com sucesso!");
    }

    [HttpGet("Obter-todos-medicos")]
    public IActionResult ObterMedicos()
    {
        try
        {
            return Ok(_medicoRepository.ObterTodosMedicos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Obter-medico-por-id")]
    public IActionResult ObterMedicoPorId(int id)
    {
        return Ok(_medicoRepository.ObterMedicoPorId(id));
    }
}