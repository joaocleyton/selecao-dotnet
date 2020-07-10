using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Cursos_Indra.Controllers
{
    [Route("v1/cartao")]
    public class CartaoController: ControllerBase
    {
        [HttpGet]
        [Route("")]   
        [AllowAnonymous]
        //[Authorize(Roles = "funcionario")]
        public async Task<ActionResult<List<Cartao>>> Get([FromServices]DataContext context)
        {      
            var _cartao = await context
                 .Cartoes
                .Include(c => c.Estudante)
                .AsNoTracking().ToListAsync();
            
            return Ok(_cartao);

        }


        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        //[Authorize(Roles = "funcionario")]
        public async Task<ActionResult<Cartao>> GetById(int id, [FromServices]DataContext context )
        {

            try
            {                                                            
                var _cartao = await context.Cartoes.Include(c => c.Estudante).AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

                if( _cartao!= null)
                    return _cartao;
                else    
                    return BadRequest(new { message = "Não encontrar o Cartão"});            
                }
            catch (System.Exception)
            {                
                 return BadRequest(new { message = "Erro ao procurar o Cartão"});  
            }
            
        }


        [HttpGet] 
        [Route("estudante/{id:int}")]
        [AllowAnonymous]
        //[Authorize(Roles = "funcionario")]
        public async Task<ActionResult<List<Cartao>>> GetByEstudante(int id, [FromServices]DataContext context )
        {
            var _cartoes = await context
            .Cartoes
            .Include(c => c.Estudante)
            .AsNoTracking()
            .Where(x => x.EstudanteId == id)
            .ToListAsync();

            return _cartoes;
        }


        [HttpPost]
        [Route("")]
        //[Authorize(Roles = "estudante")]
        [AllowAnonymous]
        public async Task<ActionResult<Cartao>> Post([FromServices] DataContext context, [FromBody] Cartao model)
        {
            if(ModelState.IsValid)
            {
                context.Cartoes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


    }
}