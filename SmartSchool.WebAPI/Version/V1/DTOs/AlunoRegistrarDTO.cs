using System;

namespace SmartSchool.WebAPI.V1.DTOs
{
    /// <summary>
    /// Este é o DTO de Aluno para registros.
    /// </summary>
    public class AlunoRegistrarDTO
    {
        /// <summary>
        /// Identificador e chave do banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno.
        /// </summary>
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}