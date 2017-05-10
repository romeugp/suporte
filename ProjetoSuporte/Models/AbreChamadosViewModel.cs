using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class AbreChamadosViewModel
    {
        public Chamado Chamado { get; set; }
        public Setor Setor { get; set; }
        public Tipo Tipo { get; set; }

        public List<ProjetoSuporte.Models.Setor> _listaSetor = new List<ProjetoSuporte.Models.Setor>()
        {
            new Setor(){id = 0, nome = "--"},
            new Setor(){id = 1, nome = "Informática"},
            new Setor(){id = 2, nome = "Manutenção"}
        };

        public List<ProjetoSuporte.Models.Tipo> _listaTipo = new List<ProjetoSuporte.Models.Tipo>()
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
            new Tipo(){Id = 10, Nome = "Coisas da manutenção",IdSetor = 2}

        };
    }
}