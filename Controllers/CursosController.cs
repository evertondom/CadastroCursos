using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackCursos.Data;
using BackCursos.Models;

namespace BackCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly BackCursosContext _context;

        public CursosController(BackCursosContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {

            var existeCurso = _context.Curso.Any(c => (c.DataInicial <= curso.DataInicial && c.DataFinal >= curso.DataInicial) || (c.DataInicial <= curso.DataFinal && c.DataFinal >= curso.DataInicial));
            


            if (existeCurso)
            {
                return BadRequest(new { Mensagem = "Existe(m) curso(s) planejado(s) dentro do período informado" });
            }

            if (curso.DataInicial < DateTime.Now)
            {
                return BadRequest(new { Atenção = "A Data não pode ser menor que a Atual" });
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                var logger = await _context.Log.FirstOrDefaultAsync(res => res.CursoId == curso.CursoId);
                logger.DataAtualizacao = DateTime.Now;
                _context.Log.Update(logger);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {

            var existeCurso = _context.Curso.Any(c => (c.DataInicial <= curso.DataInicial && c.DataFinal >= curso.DataInicial) || (c.DataInicial <= curso.DataFinal && c.DataFinal >= curso.DataInicial));
            if(existeCurso)
            {
                return BadRequest(new { Atenção = "Existe(m) curso(s) planejado(s) dentro do período informado" });
            }

            if (curso.DataInicial < DateTime.Now)
            {
                return BadRequest(new { Atenção = "A Data não pode ser menor que a Atual" });
            }


            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            var logger = new Log();
            logger.CursoId = curso.CursoId;
            logger.DataInclusao = DateTime.Now;
            _context.Log.Add(logger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.CursoId }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.CursoId == id);
        }
    }
}
