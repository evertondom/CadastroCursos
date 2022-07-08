using System;
using System.ComponentModel.DataAnnotations;

namespace BackCursos.Models
{
    public class Log
    {
        public int LogId { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataInclusao { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DataAtualizacao { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
