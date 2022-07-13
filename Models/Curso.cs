using System;
using System.ComponentModel.DataAnnotations;

namespace BackCursos.Models
{
    public class Curso
    {

        public int CursoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        public int QtdAlunos { get; set; }

        public bool Ativo { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
