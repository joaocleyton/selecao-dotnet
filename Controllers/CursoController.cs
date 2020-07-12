using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Cursos_Indra.Controllers
{
    [Route("v1/cursos")]
    public class CursoController: ControllerBase
    {
        [HttpGet]
        [Route("")]   
        [AllowAnonymous]
        public async Task<ActionResult<List<Curso>>> Get([FromServices]DataContext context)
        {      
            var _cursos = await context
                 .Cursos
                .Include(c => c.Category)
                .AsNoTracking().ToListAsync();
            
            return Ok(_cursos);

        }


        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Curso>> GetById(int id, [FromServices]DataContext context )
        {

            try
            {                                                            
                var _product = await context.Cursos.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

                if( _product!= null)
                    return _product;
                else    
                    return BadRequest(new { message = "Não encontrou o Curso"});            
                }
            catch (System.Exception)
            {                
                 return BadRequest(new { message = "Erro ao procurar o Curso"});  
            }
            
        }


        [HttpGet]
        [Route("categorias/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Curso>>> GetByCategory(int id, [FromServices]DataContext context )
        {
            var _cursos = await context
            .Cursos
            .Include(c => c.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();

            return _cursos;
        }


        [HttpPost]
        [Route("")]
        //[Authorize(Roles = "funcionario")]
        public async Task<ActionResult<Curso>> Post([FromServices] DataContext context, [FromBody] Curso model)
        {
            if(ModelState.IsValid)
            {
                context.Cursos.Add(model);
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