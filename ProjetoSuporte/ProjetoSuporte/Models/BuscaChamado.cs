using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlServerCe;

namespace ProjetoSuporte.Models
{
    
    public class BuscaChamado
    {
        [Display(Name = "nº chamado")]
        public int nchamado { get; set; }
        public int status { get; set; }
        public int dia { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int linhas { get; set; }
        public int id { get; set; }

        public string BuscaMes(string data)
        {
            string Mes = "Nº não localizado";
            string palavra1 = "ai";
            string palavra2 = "ad";
            string texto = "";

            // Esta variável vai conter a linha que o teu ficheiro.
            string linha = "ai teste ad";
            //<cStat>100</cStat>

            int pos1 = linha.IndexOf(palavra1);
            if (pos1 >= 0)
            {
                // Se entrou aqui é porque encontrou a primeira palavra
                // EDIT: Correcção de um erro na linha seguinte
                int pos2 = linha.IndexOf(palavra2, pos1);
                if (pos2 >= 0)
                {
                    // Se entrou aqui é porque encontrou a segunda palavra
                    texto = linha.Substring(pos1, pos2 - pos1 + 1);
                    // Agora é adicionares o conteúdo da variável texto no array

                }
                Mes = String.Join("", System.Text.RegularExpressions.Regex.Split(texto, @"[^\d]"));
                return Mes;

               
            }
            else
            {
                return Mes;
            }

        }

    }
  
}