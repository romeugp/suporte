using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjetoSuporte.Repositories
{
    public class UsuarioRepositorio
    {
       
        public static bool AutenticaUsuario(int Login,string Senha)
        {
           
            DadosSuporte dados = new DadosSuporte();
            var Query = (from u in dados.login where u.login_matricula == Login &&
                         u.login_senha == Senha &&
                         u.login_situacao == true
                         select u).SingleOrDefault();
            if (Query != null)
            {
                if (Query.login_senha != Senha)
                {
                    Query = null;
                }
            }
            //Usuario não existe ou a senha está incorreta
            if (Query == null)
            {
                return false;
            }

            //Guarda o id atual
            HttpContext.Current.Session.Add("id", Query.login_id);
            ////Guarda o nome
            HttpContext.Current.Session.Add("nome", Query.login_login);
            //Guarda Matrícula
            HttpContext.Current.Session.Add("matricula", Query.login_matricula);

            //seta um cookie encriptado com o login do usuario autenticado
            FormsAuthentication.SetAuthCookie(Query.login_matricula.ToString(), false);

            return true;
        }

        public static bool AutenticaUsuarioAdmin(int Login, string Senha)
       {

            DadosSuporte dados = new DadosSuporte();
            var Query = (from u in dados.login
                         where u.login_matricula == Login &&
            u.login_senha == Senha && u.login_acesso == "1" &&
            u.login_situacao == true select u ).SingleOrDefault();
            if(Query != null)
            {
                if (Query.login_senha != Senha)
                {
                    Query = null;
                }
            }
           
            //Usuario não existe ou a senha está incorreta
            if (Query == null)
            {
                return false;
                
            }

            //Guarda o id atual
            HttpContext.Current.Session.Add("id",Query.login_id);
            ////Guarda o nome
            HttpContext.Current.Session.Add("nome", Query.login_login);
            //Guarda Matrícula
            HttpContext.Current.Session.Add("matricula", Query.login_matricula);
            //Autoriazão de administrador
            HttpContext.Current.Session.Add("autorizacao", Query.login_acesso);
            string n = HttpContext.Current.Session["autorizacao"].ToString();
            //seta um cookie encriptado com o login do usuario autenticado
            FormsAuthentication.SetAuthCookie(Query.login_matricula.ToString(), false);

            return true;
        }
        //Pega os dados do usuario logado
        public static string  GetUsuarioLogado()
        {
            //Pega o usuario logado
            string _Login = HttpContext.Current.User.Identity.Name;
            //Não existe usuario Logado
            if(_Login == "")
            {
                return null;
            }
            else
            {
                DadosSuporte dadosUsuario = new DadosSuporte();
               var DadosUsuario = (from u in dadosUsuario.login
                                where u.login_matricula.ToString() == _Login
                                select u).SingleOrDefault();
                String usuario = DadosUsuario.login_matricula.ToString();

                return usuario;
            }
        }
        //Faz Logoff
        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
        }
    }
}