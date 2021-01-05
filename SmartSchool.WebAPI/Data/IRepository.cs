using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // ALUNOS
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Task<Aluno[]> GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //PROFESSORES
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplinas = false);
        Professor GetProfessorById(int professorId, bool includeProfessor = false);
        Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
    }
}