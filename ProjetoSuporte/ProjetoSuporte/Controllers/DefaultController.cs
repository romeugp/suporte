using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoSuporte.Models;


namespace ProjetoSuporte.Controllers
{

    public class DefaultController : Controller
    {
        // GET: Default

        public ActionResult Index()
        {
           
            return View();
        }  

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contatos()
        {
            return View();
        }
        public PartialViewResult Menu()
        {
            
            return PartialView();
            
        }
        public ActionResult Negado()
        {
            return View();
        }
    }
}