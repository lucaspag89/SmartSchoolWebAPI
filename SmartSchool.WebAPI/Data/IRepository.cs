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
    Aluno[] GetAllAlunos();
    Aluno[] GetAllAlunosByDisciplinaId();
    Aluno[] GetAllAlunoById();

    //PROFESSORES
    Professor[] GetAllProfessores();
    Professor[] GetAllProfessoresByDisciplinaId();
    Professor[] GetAllProfessorById();
  }
}