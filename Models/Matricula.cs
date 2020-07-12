using System.ComponentModel.DataAnnotations;
using System;

public  class Matricula
{

    [Key]
    public int Id {get;set;}

            
    public string status {get; set;}

    [Required(ErrorMessage = "Data da Matricula é um obrigatório")]    
    public DateTime dataMatricula {get;set;}

    [Required(ErrorMessage = "Id do Estudante é um campo obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Estudante inválido")]
    public int EstudanteId {get;set;}
    public Estudante Estudante {get;set;}

    [Required(ErrorMessage = "Id do Curso é um campo obrigatório")]
    [Range(1,int.MaxValue, ErrorMessage="Curso inválida")]
    public int CursoId {get;set;}

    public Estudante Curso {get;set;}

}