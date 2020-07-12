using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Cursos_Indra.Services;

using System;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace Cursos_Indra.Controllers
{
    [Route("v1/matriculas")]
    public class MatriculaController: ControllerBase
    {
        /**/                                
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
        [Route("estudante/{id:int}")]
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
                    
                    model.status = "Pg Ok";
                    context.Matriculas.Add(model);


                    var _estudante = await context.Estudantes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(model.EstudanteId));
                    var _curso = await context.Cursos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(model.EstudanteId));

                    //Checar E-mail                       
                    if (EmailService.EmailPagamento(_estudante, _curso))
                    {
                        model.status += " - Email Ok";
                    }
                    
                    
                    await context.SaveChangesAsync();
                    Console.WriteLine("Nome do Estudante: 3 " + model.Estudante.nome);

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