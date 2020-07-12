using System.ComponentModel.DataAnnotations;


    public class Estudante
    {
    
    [Key]
    public int Id {get;set;}


    [Required(ErrorMessage="Nome do estudante é um campo obrigatório")]
    [MaxLength(100,ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    public string nome {get;set;}


    [Required(ErrorMessage="E-mail do esudante é um campo obritatório")]
    [MaxLength(100, ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3,ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    public string email {get;set;}

    
    }
