using System.ComponentModel.DataAnnotations;

public  class Cartao
{

    [Key]
    public int Id {get;set;}

    [Required(ErrorMessage="Numero do cartão é um campo obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter 3 e 60 caractares")]
    [MinLength(3, ErrorMessage="Este campo deve conter 3 e 60 caractares")]
    public string numero {get; set;}


    [MaxLength(1024, ErrorMessage="Este campo deve conter no máximo 1024 caracteres")]    
    [Required(ErrorMessage="Nome do cartão é um campo obrigatório")]
    public string nome {get; set;}

    [Required(ErrorMessage="Vencimento é um campo obritório")]        
    public string Vencimento {get;set;}

    [Required(ErrorMessage="Código de Segurança é um campo obritório")]    
    public string codSeguranca {get;set;}

    [Required(ErrorMessage = "Estudante é um campo obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Categoria inválida")]
    public int EstudanteId {get;set;}

    public Estudante Estudante {get;set;}



}