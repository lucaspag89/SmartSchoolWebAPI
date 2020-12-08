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

    public void Delete<T>(T entity) where T : class
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

      query = query.AsNoTracking()
          .OrderBy(a => a.Id);

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

    public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
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
          .Where(aluno => aluno.Id == alunoId);

      return query.FirstOrDefault();
    }

    public Professor[] GetAllProfessores(bool includeAlunos = false)
    {
      IQueryable<Professor> query = _context.Professores;

      if (includeAlunos)
      {
        query = query.Include(p => p.Disciplinas)
            .ThenInclude(d => d.AlunoDisciplinas)
            .ThenInclude(ad => ad.Aluno);
      }

      query = query.AsNoTracking()
          .OrderBy(p => p.Id);

      return query.ToArray();
    }

    public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplinas = false)
    {
      IQueryable<Professor> query = _context.Professores;

      if (includeDisciplinas)
      {
        query = query.Include(p => p.Disciplinas)
            .ThenInclude(d => d.AlunoDisciplinas)
            .ThenInclude(ad => ad.Aluno);
      }

      query = query.AsNoTracking()
          .OrderBy(aluno => aluno.Id)
          .Where(aluno => aluno.Disciplinas
              .Any(d => d.AlunoDisciplinas
              .Any(ad => ad.DisciplinaId == disciplinaId)));

      return query.ToArray();
    }

    public Professor GetProfessorById(int professorId, bool includeProfessor = false)
    {
      IQueryable<Professor> query = _context.Professores;

      if (includeProfessor)
      {
        query = query.Include(p => p.Disciplinas)
            .ThenInclude(d => d.AlunoDisciplinas)
            .ThenInclude(ad => ad.Aluno);
      }

      query = query.AsNoTracking()
          .OrderBy(a => a.Id)
          .Where(professor => professor.Id == professorId);

      return query.FirstOrDefault();
    }
  }
}