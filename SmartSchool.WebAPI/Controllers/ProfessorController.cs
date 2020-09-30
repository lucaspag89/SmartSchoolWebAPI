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
    private readonly SmartSchoolContext _context;

    public ProfessorController(SmartSchoolContext context)
    {
      _context = context;
    }

    // api/professor
    [HttpGet]
    public IActionResult GetAction()
    {
      return Ok(_context.Professores);
    }

    // api/professor/byId/(id)
    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
      var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
      if (professor == null) return BadRequest("Professor não encontrado!");

      return Ok(professor);
    }

    //querystring
    // api/professor/byName?nome=Marcos
    [HttpGet("byName")]
    public IActionResult GetByName(string nome)
    {
      var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
      if (professor == null) return BadRequest("Professor não encontrado!");

      return Ok(professor);
    }

    // api/professor
    [HttpPost]
    public IActionResult Post(Professor professor)
    {
      _context.Add(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    // api/professor
    [HttpPut("{id}")]
    public IActionResult Put(int id, Professor professor)
    {
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (prof == null) return BadRequest("Professor não encontrado!");

      _context.Update(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    // api/professor
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Professor professor)
    {
      var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (prof == null) return BadRequest("Professor não encontrado!");

      _context.Update(professor);
      _context.SaveChanges();
      return Ok(professor);
    }

    // api/professor
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
      if (professor == null) return BadRequest("Professor não encontrado!");

      _context.Remove(professor);
      _context.SaveChanges();
      return Ok();
    }
  }
}