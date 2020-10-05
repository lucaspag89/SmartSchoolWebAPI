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
      return Ok(_context.Alunos);
    }

    // api/aluno/byId/(id)
    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("O Aluno não foi encontrado!!");

      return Ok(aluno);
    }

    //querystring
    // api/aluno/byName?nome=Marcos&sobrenome=Almeida
    [HttpGet("byName")]
    public IActionResult GetByName(string nome, string sobrenome)
    {
      var aluno = _context.Alunos.FirstOrDefault(a =>
        a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
      );
      if (aluno == null) return BadRequest("O Aluno não foi encontrado!!");

      return Ok(aluno);
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
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (alu == null) return BadRequest("Aluno não encontrado!");

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
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (alu == null) return BadRequest("Aluno não encontrado!");

      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }

    // api/aluno
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("Aluno não encontrado!");

      _repo.Remove(aluno);
      if (_repo.SaveChanges())
      {
        return Ok("Registro excluído");
      };

      return BadRequest("Não foi possível excluir o registro do aluno!");
    }
  }
}