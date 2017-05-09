using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class ProblemasRepository
    {

        public static IList<problemas> ListaCidade(string SiglaUf)
        {
            List<problemas> cidades = new List<problemas>();
            cidades.Add(new problemas("1", "RJ", "Angra dos Reis"));
            cidades.Add(new problemas("2", "RJ", "Rio de Janeiro"));
            cidades.Add(new problemas("3", "RJ", "Barra Mansa"));
            cidades.Add(new problemas("4", "SP", "São Paulo"));
            cidades.Add(new problemas("5", "SP", "Sertãozinho"));
            cidades.Add(new problemas("6", "SP", "Osasco"));
            cidades.Add(new problemas("7", "MG", "Belo Horizonte"));
            cidades.Add(new problemas("8", "MG", "Poços de Caldas"));
            cidades.Add(new problemas("9", "MG", "Betim"));
            return cidades.Where(x => x.SiglaUf == SiglaUf).ToList();

        }

    }
}