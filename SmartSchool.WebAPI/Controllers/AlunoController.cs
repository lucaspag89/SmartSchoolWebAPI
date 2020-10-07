using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    private readonly SmartSchoolContext _context;
    public readonly IRepository _repo;

    public AlunoController(SmartSchoolContext context, IRepository repo)
    {
      _repo = repo;
      _context = context;
    }

    // api/aluno
    [HttpGet]
    public IActionResult Get()
    {
      var result = _repo.GetAllAlunos(true);

      return Ok(result);
    }

    // api/aluno/(id)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _repo.GetAllAlunoById(id, false);
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
      var result = _repo.GetAllAlunoById(id);
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
      var result = _repo.GetAllAlunoById(id);
      if (result == null) return BadRequest("Aluno não encontrado!");

      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }

    // api/aluno
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _repo.GetAllAlunoById(id);
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