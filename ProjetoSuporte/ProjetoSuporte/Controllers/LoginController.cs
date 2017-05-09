using ProjetoSuporte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlServerCe;
using ProjetoSuporte.Repositories;

namespace ProjetoSuporte.Controllers
{
    public class LoginController : Controller
    {
        DadosSuporte dados = new DadosSuporte();
       
        ProjetoSuporte.Models.BuscaChamado busca = new BuscaChamado();
        Usuario usuario = new Usuario();
        
        // GET: Login
        //[Authorize]
        public ActionResult CriarLogin(Usuario usuario)
        {
            
            return View(usuario);
        }

        //[Authorize]
        public ActionResult Cria(Usuario usuario)
        {
            if (ModelState.IsValid == false)
            {
                return View("~/Views/Login/CriarLogin.cshtml", usuario);
            }
           
            return View(usuario);
        }
        
        public ActionResult Usuario(Usuario usuario)
        {
            //if((usuario.matricula == 8080) && usuario.Senha == "orion123")
            //{
            //    //Response.Redirect("~/Views/AbreChamado/AbreChamado.cshtml");

            //    return View("~/Views/Login/Admin.cshtml",busca);
            //} 
            if(UsuarioRepositorio.AutenticaUsuarioAdmin(usuario.matricula,usuario.Senha) == true || Convert.ToInt32(Session["autorizacao"]) == 2)
            {
                return View("~/Views/Login/Admin.cshtml", busca);
            }else
            if (UsuarioRepositorio.AutenticaUsuario(usuario.matricula,usuario.Senha) == true)
            {
                return View(usuario);
            }
           string t = UsuarioRepositorio.GetUsuarioLogado();
            ModelState.AddModelError("matricula", "Login ou Senha incorreta");
            return View("~/Views/Default/Index.cshtml", usuario);

           
        }


        public PartialViewResult Menu()
        {

            return PartialView();
        }

        public PartialViewResult Menu2()
        {

            return PartialView();
        }

        public PartialViewResult MenuAdmin()
        {

            return PartialView();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            UsuarioRepositorio.Deslogar();
            return View("~/Views/Default/Index.cshtml");
        }

        public ActionResult Admin(BuscaChamado modelo)
        {
            if (UsuarioRepositorio.AutenticaUsuarioAdmin(usuario.matricula, usuario.Senha) == true)
            {
                return View(busca);
                //return View("~/Views/Login/Admin.cshtml", busca);
            }
            else
           if (UsuarioRepositorio.AutenticaUsuario(usuario.matricula, usuario.Senha) == true)
            {
                return View(usuario);
            }
            string t = UsuarioRepositorio.GetUsuarioLogado();
            ModelState.AddModelError("matricula", "Login ou Senha incorreta");
            return View("~/Views/Default/Index.cshtml", usuario);


            //return View(modelo);
        }
        public ActionResult detalhesAdmin(Mchamado modelo)
        {
            return View(modelo);

        }
        public ActionResult resolver()
        {

            int situacao = Convert.ToInt32(Session["situacao"]);

            if (situacao == 3)
            {
                return View("~/Views/Login/Fechar.cshtml");
            }

            return View();
        }

        ProjetoSuporte.Models.Madmin mAdmin = new Madmin();
        public ActionResult Fechar(Madmin modelo)
        {
            return View(modelo);
        }


        public ActionResult Fecha2(Madmin modelo)
        {
            return View(modelo);
        }

        public ActionResult FechaUsuario(Madmin modelo,string id)
        {
            ViewBag.id = id;
            if (Request.IsAjaxRequest())
            {
                return PartialView("FechaUsuario2");
            }
            return View(modelo);
        }
        public ActionResult FechaUsuario2( )
        {
            
            return PartialView();
        }

        public ActionResult MenuFechaUsuario()
        {
            return PartialView();
        }

        //[Authorize]
        public ActionResult Chat(string nome)
        {
            
            string name = "Rafael";
            Session["nome"] = name;
            //try
            //{
            //    name = HttpContext.Session["nome"].ToString();
            //}
            //catch (Exception e)
            //{

            //}

            if ((name != null) && (name != string.Empty))
            {
                return View();
            }
            else
            {
                return View("~/Views/Default/Index.cshtml", usuario);

            }


        }
    }
}