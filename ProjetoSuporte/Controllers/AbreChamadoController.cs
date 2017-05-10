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
        public ActionResult AbreChamado(AbreChamadosViewModel abreModel)
        {

            //var ret = new List<Setor>();
            //ret.AddRange(_listaSetor);
            //ret.Insert(0, new Setor() { id = -1, nome = "--" });



            return View(abreModel);
        }

       [HttpPost]
       public ActionResult ObterTipos(int idSetor)
        {
            AbreChamadosViewModel c = new AbreChamadosViewModel();
            return Json(c._listaTipo.FindAll(x => x.IdSetor == idSetor));

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