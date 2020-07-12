using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cursos_Indra.Dados;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Cursos_Indra.Services;

namespace Cursos_Indra.Services
{
       

    public static class EmailService
    {

        const string emailServico = "joaocleyton@gmail.com";

        public static Boolean EmailPagamento(Estudante estudante, Curso curso)
        {            
            
           try
           {
                if(estudante.email != null){
                try
                {
                    Execute(estudante, curso).Wait();                                                
                    return true;    
                }
                catch (System.Exception)
                {                    
                    return false;
                }
                
            }
            else{
                return false;
            }
           }
           catch (System.Exception)
           {
               return false;
               //throw;
           }            
        }
        
        static async Task Execute(Estudante estudante, Curso curso)
        {
            //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailServico, "Example User");
            var subject = "Matricula para o Curso " + curso.Title + " foi realizada com Sucesso";
            var to = new EmailAddress(estudante.email, estudante.nome);
            var plainTextContent = "atricula realizada";
            var htmlContent = "<strong>Matricula realizada</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);        
        }

        
    }
}