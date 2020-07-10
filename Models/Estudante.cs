using System.ComponentModel.DataAnnotations;


    public class Estudante
    {
    
    [Key]
    public int Id {get;set;}


    [Required(ErrorMessage="Este campo é obrigatório")]
    [MaxLength(100,ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    public string nome {get;set;}


    [Required(ErrorMessage="Este campo é obritatório")]
    [MaxLength(100, ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3,ErrorMessage="Este campo deve conter entre 3 e 20 caracteres")]
    public string email {get;set;}

    
    }
