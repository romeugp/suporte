using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class Setor
    {

        public Setor(string siglaUf, string nome)
        {
            this.Nome = nome;
            this.SiglaUf = siglaUf;
        }
        public string SiglaUf { get; set; }
        public string Nome { get; set; }

    }
}