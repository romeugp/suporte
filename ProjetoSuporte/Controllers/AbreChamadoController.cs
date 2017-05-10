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

        private List<Setor> _listaSetor = new List<Setor>()
        {
            new Setor(){id = 1, nome = "Informática"},
            new Setor(){id = 2, nome = "Manutenção"}
        };

        private List<Tipo> _listaTipo = new List<Tipo>()
        {
            new Tipo(){Id = 1, Nome = "PDV",IdSetor = 1},
            new Tipo(){Id = 2, Nome = "HARDWARE",IdSetor = 1},
            new Tipo(){Id = 3, Nome = "SISTEMA RMS"},
            new Tipo(){Id = 4, Nome = "SISTEMA EMPORIUM",IdSetor = 1},
            new Tipo(){Id = 5, Nome = "REDE LÓGICA",IdSetor = 1},
            new Tipo(){Id = 6, Nome = "REDE ELÉTRICA ESTABILIZADA",IdSetor = 1},
            new Tipo(){Id = 7, Nome = "IMPRESSORA",IdSetor = 1},
            new Tipo(){Id = 8, Nome = "CFTV",IdSetor = 1},
            new Tipo(){Id = 9, Nome = "BALANÇAS ÁREA DE VENDAS",IdSetor = 1},
            new Tipo(){Id = 10, Nome = "teste",IdSetor = 2}

        };

        // GET: AbreChamado

        
        [Authorize]      
        public ActionResult AbreChamado(Chamado chamado)
        {
            var ret = new List<Setor>();
            ret.AddRange(_listaSetor);
            ret.Insert(0, new Setor() { id = -1, nome = "--" });


            return View(ret);
        }

       [HttpPost]
       public ActionResult ObterTipos(int idSetor)
        {
            return Json(_listaTipo.FindAll(x => x.IdSetor == idSetor));

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