using AloDoutor.Dto;
using AloDoutor.Entity;
using AloDoutor.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AloDoutor.Controllers;

[ApiController]
[Route("Paciente")]
public class CadastroPacienteController : ControllerBase
{
    private IRepository<Paciente> _pacienteRepository;

    public CadastroPacienteController(IRepository<Paciente> pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    [HttpPost("Cadastrar-Paciente")]
    public IActionResult CadastrarPaciente(CadastrarPacienteDTO pacienteDTO)
    {
        _pacienteRepository.Cadastrar(new Paciente(pacienteDTO));
        var mensagem = $"Paciente cadastrado com sucesso! | Nome: {pacienteDTO.Nome}";
        return Ok(mensagem);
    }

    [HttpPut("Alterar-Paciente")]
    public IActionResult AlterarPaciente(AlterarPacienteDTO pacienteDTO)
    {
        _pacienteRepository.Alterar(new Paciente(pacienteDTO));
        return Ok("Paciente alterado com sucesso!");
    }

    [HttpDelete("Deletar-Paciente")]
    public IActionResult DeletarPaciente(int id)
    {
        _pacienteRepository.Deletar(id);
        return Ok("Paciente deletado com sucesso!");
    }

    [HttpGet("Obter-todos-pacientes")]
    public IActionResult ObterPacientes()
    {
        try
        {
            return Ok(_pacienteRepository.ObterTodos());
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("Obter-paciente-por-id")]
    public IActionResult ObterPacientePorId(int id)
    {
        return Ok(_pacienteRepository.ObterPorId(id));
    }
}