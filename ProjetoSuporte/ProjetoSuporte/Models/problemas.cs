using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class problemas
    {

        public problemas(string id, string siglaUf, string nome)
        {
            this.Id = id;
            this.SiglaUf = siglaUf;
            this.Nome = nome;
        }
        public string Id { get; set; }
        public string SiglaUf { get; set; }
        public string Nome { get; set; }

    }
}