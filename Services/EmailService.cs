using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cursos_Indra.Dados;
using Microsoft.IdentityModel.Tokens;


namespace Cursos_Indra.Services
{
    public static class EmailService
    {

        public static Boolean EnviarEmail(Matricula matricula)
        {            
            
            if(matricula.Estudante.email != null){
                
                return true;
            }
            else{
                return false;
            }

            

        }
        
    }
}