using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class SetorRepository
    {

        public static IList<Setor> ListaUf()
        {
            List<Setor> setores = new List<Setor>();
            setores.Add(new Setor("info", "Informática"));
            setores.Add(new Setor("manu", "Manutenção"));
            setores.Add(new Setor("MG", "Minas Gerais"));
            return setores;

        }

    }
}