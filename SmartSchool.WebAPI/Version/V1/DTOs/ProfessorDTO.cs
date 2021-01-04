using System.Collections.Generic;

namespace SmartSchool.WebAPI.V1.DTOs
{
  public class ProfessorDTO
  {
    public int Id { get; set; }
    public int Registro { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public bool Ativo { get; set; } = true;
  }
}