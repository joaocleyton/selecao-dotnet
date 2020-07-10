using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



// EndPoint => URL
// https://localhost:5001
// http://localhost:5000

[Route("v1/categorias")]
public class CategoryController: ControllerBase
{

    /// <summary>
    /// Ação para obter todas as categorias de cursos cadatradas.
    /// </summary>
    [HttpGet]
    [Route("")] 
    [AllowAnonymous]  
    [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] //Linha para não ter cache
    public async Task<ActionResult<List<Category>>> Get([FromServices]DataContext context)
    {
      
      var categories = await context.Categories.AsNoTracking().ToListAsync();
      return Ok(categories);

    }


    [HttpGet]
    [Route("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<Category>> GetById(int id,[FromServices]DataContext context)
    {        
       var _category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
      return Ok(_category);
    }

    [HttpPost]
    [Route("")]
    //[Authorize(Roles = "funcionario")]
    public async Task<ActionResult<Category>> Post([FromBody] Category model,
    [FromServices]DataContext context)
    {                
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch 
        {            
            return BadRequest(new { message = "Não foi possível criar a categoria"});
        }

        
    }

    [HttpPut]
    [Route("{id:int}")]
    //[Authorize(Roles = "funcionario")]
    public async Task<ActionResult<Category>> Put(int id, [FromBody]Category model,
    [FromServices]DataContext context)
    {
        //Verifica se o ID informado é o mesmo do modelo
        if( id != model.Id )
            return NotFound(new {message = "Categoria não encontrada"});
        
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (DbUpdateConcurrencyException)
        {            
            return BadRequest(new { message = "Este registro já foi atualizado"});
        }
        catch 
        {            
            return BadRequest(new { message = "Não foi possível atualizar a categoria"});
        }


    }

    [HttpDelete]
    [Route("{id:int}")]
    //[Authorize(Roles = "funcionario")]
    public async Task<ActionResult<Category>> Delete(int id,
    [FromServices]DataContext context)
    {
        var _category = await context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if(_category == null)        
            return NotFound(new {message = "Categoria não encontrada"});

        
        try
        {
            context.Categories.Remove(_category);
            await context.SaveChangesAsync();
            return Ok(new {message = "Categoria removida com sucesso"});
            
        }
        catch 
        {            
            return BadRequest(new {messsage = "Não foi possível remover a categoria"});
        }

    
    }

}