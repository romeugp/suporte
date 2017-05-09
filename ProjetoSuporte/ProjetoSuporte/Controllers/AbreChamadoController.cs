using ProjetoSuporte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSuporte.Controllers
{
    public class AbreChamadoController : Controller
    {
        ProjetoSuporte.Models.BuscaChamado busca = new BuscaChamado();
        Chamado chamado = new Chamado();//Modelo da classe Chamado
       

        // GET: AbreChamado
        [Authorize]
        public ActionResult AbreChamado(Chamado chamado)
        {
            
            return View(chamado);
        }

        public ActionResult CountryList()
        {
            IQueryable countries = Country.GetCountries();
            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json(new SelectList(
                   countries,
                   "CountryCode",
                   "CountryName"), JsonRequestBehavior.AllowGet
                    );
            }
            return View(countries);
        }

        public ActionResult StateList(string CountryCode)
        {
            IQueryable states = State.GetState().Where(x => x.CountryCode == CountryCode);
            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(
                    states,
                    "StateID",
                    "StateName"), JsonRequestBehavior.AllowGet
                    );
            return View(states);
        }

        [Authorize]
        public ActionResult InsereDados(Chamado chamado)
        {
           if(chamado.Detalhe == null)
            {
                return View("~/Views/AbreChamado/AbreChamado.cshtml");
            }
            return View(chamado);
        }

        [Authorize]
        public ActionResult AcompanhaChamado(BuscaChamado modelo)
        {

            return View(modelo);
        }

        [Authorize]
        public ActionResult Detalhes(int? id)
        {
           
            return View(id);
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }

        public PartialViewResult Menu2()
        {
            return PartialView();
        }

        public PartialViewResult MenuDetalhes()
        {
            return PartialView();
        }
        public PartialViewResult MenuResolver()
        {
            return PartialView();
        }


    }
}