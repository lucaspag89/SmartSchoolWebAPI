using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    public readonly IMapper _mapper;

    public AlunoController(IRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    // api/aluno
    [HttpGet]
    public IActionResult Get()
    {
      var alunos = _repo.GetAllAlunos(true);

      return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
    }

    // api/aluno/(id)
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = _repo.GetAlunoById(id, false);
      if (aluno == null) return BadRequest("O Aluno não foi encontrado!!");

      var alunoDto = _mapper.Map<AlunoDTO>(aluno);

      return Ok(alunoDto);
    }

    // api/aluno
    [HttpPost]
    public IActionResult Post(AlunoRegistrarDTO model)
    {
      var aluno = _mapper.Map<Aluno>(model);

      _repo.Add(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
      };

      return BadRequest("Aluno não cadastrado!");
    }


    // api/aluno
    [HttpPut("{id}")]
    public IActionResult Put(int id, AlunoRegistrarDTO model)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado!");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
      };

      return BadRequest("Não foi possível atualizar os dados do aluno!");
    }

    // api/aluno
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, AlunoRegistrarDTO model)
    {
      var aluno = _repo.GetAlunoById(id, false);
      if (aluno == null) return BadRequest("Aluno não encontrado!");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDTO>(aluno));
      };

      return BadRequest("Não foi possível atualizar os dados do aluno!");
    }

    // api/aluno
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _repo.GetAlunoById(id, false);
      if (aluno == null) return BadRequest("Aluno não encontrado!");

      _repo.Delete(aluno);
      if (_repo.SaveChanges())
      {
        return Ok("Registro excluído");
      };

      return BadRequest("Não foi possível excluir o registro do aluno!");
    }
  }
}