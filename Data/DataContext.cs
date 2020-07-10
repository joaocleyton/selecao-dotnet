using Microsoft.EntityFrameworkCore;


namespace Cursos_Indra.Dados
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {            
        }


        //Dbset representação da Tabela em Memória
        public DbSet<Curso> Cursos {get; set;}

        public DbSet<Category> Categories {get; set;}

        public DbSet<Estudante> Estudantes {get; set;}

        public DbSet<Cartao> Cartoes {get; set;}

        public DbSet<Matricula> Matriculas {get;set;}


    }
}