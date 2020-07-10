using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cursos_Indra.Dados;

namespace Cursos_Indra.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {

            
            var categoria = new Category {Id=1, Title = "Informática"};
            var curso = new Curso {Id=1, Category = categoria, Title = "Curso de Informática", Price = 299, Description="Informática"};
            
            
            context.Categories.Add(categoria);
            context.Cursos.Add(curso);

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados Configurados"

            });

            

        }


        
    }
}