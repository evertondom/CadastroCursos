using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackCursos.Models;

namespace BackCursos.Data
{
    public class BackCursosContext : DbContext
    {
        public BackCursosContext (DbContextOptions<BackCursosContext> options)
            : base(options)
        {
        }

        public DbSet<BackCursos.Models.Categoria> Categoria { get; set; }

        public DbSet<BackCursos.Models.Curso> Curso { get; set; }

        public DbSet<BackCursos.Models.Log> Log { get; set; }
    }
}
