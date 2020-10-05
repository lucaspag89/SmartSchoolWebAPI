using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
  public class Repository : IRepository
  {
    private readonly SmartSchoolContext _context;

    public Repository(SmartSchoolContext context)
    {
      _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }

    public void Remove<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() > 0);
    }

    public Aluno[] GetAllAlunos(bool includeProfessor = false)
    {
      IQueryable<Aluno> query = _context.Alunos;

      if (includeProfessor)
      {
        query = query.Include(a => a.AlunoDisciplinas)
          .ThenInclude(ad => ad.Disciplina)
          .ThenInclude(d => d.Professor);
      }

      query = query.AsNoTracking().OrderBy(a => a.Id);

      return query.ToArray();
    }

    public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
    {
      IQueryable<Aluno> query = _context.Alunos;

      if (includeProfessor)
      {
        query = query.Include(a => a.AlunoDisciplinas)
          .ThenInclude(ad => ad.Disciplina)
          .ThenInclude(d => d.Professor);
      }

      query = query.AsNoTracking()
        .OrderBy(a => a.Id)
        .Where(aluno => aluno.AlunoDisciplinas
          .Any(ad => ad.DisciplinaId == disciplinaId));

      return query.ToArray();
    }

    public Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false)
    {
      IQueryable<Aluno> query = _context.Alunos;

      if (includeProfessor)
      {
        query = query.Include(a => a.AlunoDisciplinas)
          .ThenInclude(ad => ad.Disciplina)
          .ThenInclude(d => d.Professor);
      }

      query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.Id == alunoId);

      return query.FirstOrDefault();
    }

    public Professor[] GetAllProfessores()
    {
      throw new System.NotImplementedException();
    }

    public Professor[] GetAllProfessoresByDisciplinaId()
    {
      throw new System.NotImplementedException();
    }

    public Professor[] GetAllProfessorById()
    {
      throw new System.NotImplementedException();
    }
  }
}