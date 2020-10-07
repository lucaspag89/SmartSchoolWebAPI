using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
  public interface IRepository
  {
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Remove<T>(T entity) where T : class;
    bool SaveChanges();

    // ALUNOS
    Aluno[] GetAllAlunos(bool includeProfessor = false);
    Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
    Aluno GetAllAlunoById(int alunoId, bool includeProfessor = false);

    //PROFESSORES
    Professor[] GetAllProfessores(bool includeAlunos = false);
    Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplinas = false);
    Professor GetAllProfessorById(int professorId, bool includeProfessor = false);
  }
}