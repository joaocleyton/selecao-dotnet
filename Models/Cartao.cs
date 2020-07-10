using System.ComponentModel.DataAnnotations;

public  class Cartao
{

    [Key]
    public int Id {get;set;}

    [Required(ErrorMessage="Este campo é obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter 3 e 60 caractares")]
    [MinLength(3, ErrorMessage="Este campo deve conter 3 e 60 caractares")]
    public string numero {get; set;}


    [MaxLength(1024, ErrorMessage="Este campo deve conter no máximo 1024 caracteres")]    
    public string nome {get; set;}

    [Required(ErrorMessage="Este campo é obritório")]    
    public string Vencimento {get;set;}

    [Required(ErrorMessage="Este campo é obritório")]    
    public string codSeguranca {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Categoria inválida")]
    public int EstudanteId {get;set;}

    public Estudante Estudante {get;set;}



}