using System.ComponentModel.DataAnnotations;

public class Category
{

    [Key]
    public int Id {get; set;}


    [Required(ErrorMessage="Descrição da cateoria é um campo obrigatório")]
    [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caracteres")]
    [MinLength(3, ErrorMessage="Esse campo deve conter entre 3 e 60 caracateres")]

    public string Title {get; set;}

}