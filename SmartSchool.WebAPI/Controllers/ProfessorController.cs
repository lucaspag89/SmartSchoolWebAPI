using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfessorController : ControllerBase
  {
    public readonly IRepository _repo;
    public ProfessorController(IRepository repo)
    {
      _repo = repo;
    }

    // api/professor
    [HttpGet]
    public IActionResult Get()
    {
      var result = _repo.GetAllProfessores(true);
      return Ok(result);
    }

    // api/professor/byId/(id)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var result = _repo.GetProfessorById(id, false);
      if (result == null) return BadRequest("O professor não foi encontrado!!");

      return Ok(result);
    }

    // api/professor
    [HttpPost]
    public IActionResult Post(Professor professor)
    {
      _repo.Add(professor);
      if (_repo.SaveChanges())
      {
        return Ok(professor);
      };

      return BadRequest("Professor não cadastro!");
    }

    // api/professor
    [HttpPut("{id}")]
    public IActionResult Put(int id, Professor professor)
    {
      var result = _repo.GetProfessorById(id, false);
      if (result == null) return BadRequest("Professor não encontrado!");

      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Ok(professor);
      };

      return BadRequest("Não foi possível atualizar os dados do professor!");
    }

    // api/professor
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Professor professor)
    {
      var prof = _repo.GetProfessorById(id, false);
      if (prof == null) return BadRequest("Professor não encontrado!");

      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Ok(professor);
      };

      return BadRequest("Não foi possível atualizar os dados do professor!");
    }

    // api/professor
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var result = _repo.GetProfessorById(id, false);
      if (result == null) return BadRequest("Professor não encontrado!");

      _repo.Remove(result);
      if (_repo.SaveChanges())
      {
        return Ok("Registro excluído");
      };

      return BadRequest("Não foi possível excluir o registro do professor!");
    }
  }
}