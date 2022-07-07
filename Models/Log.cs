using System;
using System.ComponentModel.DataAnnotations;

namespace BackCursos.Models
{
    public class Log
    {
        public int LogId { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataInclusao { get; set; }

        [DisplayFormat(DataFormatString ="dd/MM/yyyy")]
        public DateTime DataAtualizacao { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
