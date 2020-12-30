using AutoMapper;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.V1.DTO;

namespace SmartSchool.WebAPI.Helpers
{
  public class SmartSchoolProfile : Profile
  {
    public SmartSchoolProfile()
    {
      //Mapeamento do aluno
      CreateMap<Aluno, AlunoDTO>()
      .ForMember(
        dest => dest.Nome,
        opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
      )
      .ForMember(
        dest => dest.Idade,
        opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
      );

      CreateMap<AlunoDTO, Aluno>();

      CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();

      //Mapeamento do professor
      CreateMap<Professor, ProfessorDTO>()
      .ForMember(
        dest => dest.Nome,
        opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
      );

      CreateMap<ProfessorDTO, Professor>();

      CreateMap<Professor, ProfessorRegistrarDTO>().ReverseMap();
    }
  }
}