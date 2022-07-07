using System;
using System.ComponentModel.DataAnnotations;

namespace BackCursos.Models
{
    public class Curso
    {
        public int CursoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A descrição deve ter entre 6 e 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayFormat(DataFormatString ="dd/MM/yyyy")]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataFinal { get; set; }

        public int QtdAlunos { get; set; }

        
        Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
