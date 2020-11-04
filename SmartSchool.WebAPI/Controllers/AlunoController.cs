using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTO;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    public readonly IRepository _repo;

    public AlunoController(IRepository repo)
    {
      _repo = repo;
    }

    // api/aluno
    [HttpGet]
    public IActionResult Get()
    {
      var alunos = _repo.GetAllAlunos(true);
      var alunosRetorno = new List<AlunoDTO>();

      foreach (var aluno in alunos)
      {
        alunosRetorno.Add(new AlunoDTO()
        {
          Id = aluno.Id,

        });
      }

      return Ok(alunos);
    }

    // api/aluno/(id)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _repo.GetAlunoById(id, false);
      if (result == null) return BadRequest("O Aluno não foi encontrado!!");

      return Ok(result);
    }

    // api/aluno
    [HttpPost]
    public IActionResult Post(Aluno aluno)
    {
      _repo.Add(aluno);
      if (_repo.SaveChanges())
      {
        return Ok(aluno);
      };

      return BadRequest("Aluno não cadastrado!");
    }

    // api/aluno
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
      var result = _repo.GetAlunoById(id, false);
      if (result == null) return BadRequest("Aluno não encontrado!");

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Ok(aluno);
      };

      return BadRequest("Não foi possível atualizar os dados do aluno!");
    }

    // api/aluno
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
      var result = _repo.GetAlunoById(id, false);
      if (result == null) return BadRequest("Aluno não encontrado!");

      _repo.Update(aluno);
      _repo.SaveChanges();
      return Ok(aluno);
    }

    // api/aluno
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _repo.GetAlunoById(id, false);
      if (result == null) return BadRequest("Aluno não encontrado!");

      _repo.Remove(result);
      if (_repo.SaveChanges())
      {
        return Ok("Registro excluído");
      };

      return BadRequest("Não foi possível excluir o registro do aluno!");
    }
  }
}