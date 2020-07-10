using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cursos_Indra.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;



// EndPoint => URL
// https://localhost:5001
// http://localhost:5000

[Route("v1/estudantes")]
public class EstudanteController: ControllerBase
{

    /// <summary>
    /// Ação para obter todas as categorias cadatradas.
    /// </summary>
    [HttpGet]
    [Route("")] 
    [AllowAnonymous]  
    [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] //Linha para não ter cache
    public async Task<ActionResult<List<Estudante>>> Get([FromServices]DataContext context)
    {      
      var estudantes = await context.Estudantes.AsNoTracking().ToListAsync();
      return Ok(estudantes);
    }


    [HttpGet]
    [Route("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<Category>> GetById(int id,[FromServices]DataContext context)
    {        
       var _estudante = await context.Estudantes.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
      return Ok(_estudante);
    }

    [HttpPost]
    [Route("")]
    //[Authorize(Roles = "funcionario")]
    [AllowAnonymous]
    public async Task<ActionResult<Estudante>> Post([FromBody] Estudante model,
    [FromServices]DataContext context)
    {                
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Estudantes.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch 
        {            
            return BadRequest(new { message = "Não foi possível criar o estudante"});
        }

        
    }

    [HttpPut]
    [Route("{id:int}")]
    //[Authorize(Roles = "funcionario")]
    [AllowAnonymous]  
    public async Task<ActionResult<Category>> Put(int id, [FromBody]Estudante model,
    [FromServices]DataContext context)
    {
        //Verifica se o ID informado é o mesmo do modelo
        if( id != model.Id )
            return NotFound(new {message = "Estudante não encontrado"});
        
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Entry<Estudante>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (DbUpdateConcurrencyException)
        {            
            return BadRequest(new { message = "Este registro já foi atualizado"});
        }
        catch 
        {            
            return BadRequest(new { message = "Não foi possível atualizar o estudante"});
        }


    }

    [HttpDelete]
    [Route("{id:int}")]
    //[Authorize(Roles = "funcionario")]
    [AllowAnonymous]  
    public async Task<ActionResult<Estudante>> Delete(int id,
    [FromServices]DataContext context)
    {
        var _estudante = await context.Estudantes.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if(_estudante == null)        
            return NotFound(new {message = "Estudante não encontrado"});

        
        try
        {
            context.Estudantes.Remove(_estudante);
            await context.SaveChangesAsync();
            return Ok(new {message = "Estudante removida com sucesso"});
            
        }
        catch 
        {            
            return BadRequest(new {messsage = "Não foi possível remover o estudante"});
        }

    
    }

}