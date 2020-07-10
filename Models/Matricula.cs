using System.ComponentModel.DataAnnotations;
using System;

public  class Matricula
{

    [Key]
    public int Id {get;set;}

            
    public string status {get; set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]    
    public DateTime dataMatricula {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Estudante inválido")]
    public int EstudanteId {get;set;}
    public Estudante Estudante {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Curso inválida")]
    public int CursoId {get;set;}

    public Estudante Curso {get;set;}

}