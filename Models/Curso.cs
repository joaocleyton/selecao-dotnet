using System.ComponentModel.DataAnnotations;

public class Curso
{

    [Key]
    public int Id {get;set;}

    [Required(ErrorMessage="Titulo é um campo obrigatório")]
    [MinLength(3, ErrorMessage="Este campo deve conter 3 e 60 caractares")]
    [MaxLength(60, ErrorMessage="Este campo deve conter 3 e 60 caractares")]    
    public string Title {get; set;}


    [MaxLength(1024, ErrorMessage="Este campo deve conter no máximo 1024 caracteres")]    
    public string Description {get; set;}


    [Required(ErrorMessage="Preço é um campo obritório")]    
    public decimal Price {get;set;}

    [Required(ErrorMessage = "Categoria é um campo obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Categoria inválida")]
    public int CategoryId {get;set;}

    public Category Category {get;set;}



}