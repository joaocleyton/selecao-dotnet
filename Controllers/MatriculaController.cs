using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Cursos_Indra.Services;

namespace Cursos_Indra.Controllers
{
    [Route("v1/matriculas")]
    public class MatriculaController: ControllerBase
    {
        [HttpGet]
        [Route("")]   
        [AllowAnonymous]
        public async Task<ActionResult<List<Matricula>>> Get([FromServices]DataContext context)
        {      
            var _matriculas = await context
                 .Matriculas
                .Include(c => c.Curso)
                .Include(e => e.Estudante)
                .AsNoTracking().ToListAsync();
            
            return Ok(_matriculas);

        }


        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Matricula>> GetById(int id, [FromServices]DataContext context )
        {

            try
            {                                                            
                var _matriculas = await context.Matriculas.Include(c => c.Curso).Include(e => e.Estudante).AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

                if( _matriculas!= null)
                    return _matriculas;
                else    
                    return BadRequest(new { message = "Não encontrar o Curso"});            
                }
            catch (System.Exception)
            {                
                 return BadRequest(new { message = "Erro ao procurar o Curso"});  
            }
            
        }


        [HttpGet]
        [Route("alunos/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Matricula>>> GetByAlunos(int id, [FromServices]DataContext context )
        {
            var _matriculas = await context
            .Matriculas
            .Include(c => c.Curso)
            .Include(e => e.Estudante)
            .AsNoTracking()
            .Where(x => x.EstudanteId == id)
            .ToListAsync();

            return _matriculas;
        }


        [HttpPost]
        [Route("")]
        //[Authorize(Roles = "estudante")]
        [AllowAnonymous]
        public async Task<ActionResult<Matricula>> Post([FromServices] DataContext context, [FromBody] Matricula model)
        {
            if(ModelState.IsValid)
            {               
                 var _cartao = await context.Cartoes.Include(c => c.Estudante).AsNoTracking().FirstOrDefaultAsync(x => x.EstudanteId.Equals(model.EstudanteId));

                //Checar Pagamentos                
                if (PagamentoService.EnviarPagamento(_cartao))
                {
                    //Checar E-mail                
                   if (EmailService.EnviarEmail(model))
                    {
                        model.status = "Pg Ok - Email Ok";
                    }
                    
                    context.Matriculas.Add(model);
                    await context.SaveChangesAsync();

                }                
                            
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


    }
}