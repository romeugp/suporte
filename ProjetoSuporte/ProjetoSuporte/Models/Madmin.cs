using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlServerCe;
using ProjetoSuporte.Security;
using ProjetoSuporte.Repositories;

namespace ProjetoSuporte.Models
{
    public class Madmin
    {

        DadosSuporte dados = new DadosSuporte();
        SqlCeConnection ligacao = new SqlCeConnection(@"Data source = C:\Users\rafaelvieira\Desktop\ProjetoSuporte\ProjetoSuporte\App_Data\suporte.sdf");

        public int Os_Id { get; set; }

        public int Login_Id { get; set; }

        public string Escolha { get; set; }

        public string Detalhe { get; set; }

        public DateTime DataA { get; set; }

        public DateTime DataF { get; set; }

        public int NChamado { get; set; }

        public string Situacao { get; set; }

        public string solucao { get; set; }

        public List<Mchamado> query()
        {
            
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os select p;
            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Ativo",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Inativo",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }
        //Filtros
        int id = Convert.ToInt32(HttpContext.Current.Session["id"]);

        //Filtra os primeiros 400 registros
        public List<Mchamado> Q400()
        {
            DadosSuporte dados = new DadosSuporte();
           
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = (from p in dados.os where p.os_situacao == 1 || p.os_situacao == 3 select p).Take(200);

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamento",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //Filtra pelo nº do chamado
        public List<Mchamado> QNChamado(int NChamado)
        {
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os where p.os_nos.Equals(nChamado) && p.login_id.Equals(id) select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamento",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //Filtra somente os abertos
        public List<Mchamado> QAbertos()
        {
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os where p.os_situacao.Equals(1) && p.login_id.Equals(id) select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamento",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //Filtra somente os fechados
        public List<Mchamado> QFechados()
        {
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os where p.os_situacao.Equals(2) && p.login_id.Equals(id) select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamento",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //Somente abertos do mes
        public List<Mchamado> QAbertoMes(int Mes)
        {
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(1) &&
    p.os_dataa.Month.Equals(mes) && p.login_id.Equals(id)
                     select p;
            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }


        //Filtra os fechados do mês
        public List<Mchamado> QFechadosMes(int Mes)
        {
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(2) &&
  p.os_dataa.Month.Equals(mes) && p.login_id.Equals(id)
                     select p;


            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //somente os abertos do mes do ano
        public List<Mchamado> QAbertoMesAno(int Mes, int Ano)
        {
            int ano = Ano;
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(1) &&
                        p.os_dataa.Month.Equals(mes) &&
                        p.os_dataa.Year.Equals(ano) &&
                        p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //somente os fechados do mes do ano
        public List<Mchamado> QFechadoMesAno(int Mes, int Ano)
        {
            int ano = Ano;
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(2) &&
                        p.os_dataa.Month.Equals(mes) &&
                        p.os_dataa.Year.Equals(ano) &&
                        p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //somente os abertos do ano
        public List<Mchamado> QAbertosAno(int Ano)
        {
            int ano = Ano;

            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(1) &&
                        p.os_dataa.Year.Equals(ano) &&
                        p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //somente os fechados do ano
        public List<Mchamado> QFechadosAno(int Ano)
        {
            int ano = Ano;

            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_situacao.Equals(2) &&
                        p.os_dataa.Year.Equals(ano) &&
                        p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //todos do mes do ano
        public List<Mchamado> QTodosMesAno(int Mes, int Ano)
        {
            int ano = Ano;
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_dataa.Month.Equals(mes) &&
                     p.os_dataa.Year.Equals(ano) &&
                     p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //todos do mes
        public List<Mchamado> QTodosMes(int Mes)
        {
            int mes = Mes;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_dataa.Month.Equals(mes) &&
                     p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //todos do ano
        public List<Mchamado> QTodosAno(int Ano)
        {
            int ano = Ano;
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os
                     where p.os_dataa.Year.Equals(ano) &&
                     p.login_id.Equals(id)
                     select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamnto",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        //todos os em andamento
        public List<Mchamado> QAndamento()
        {
            int nChamado = NChamado;
            DadosSuporte dados = new DadosSuporte();
            List<Mchamado> query2 = new List<Mchamado>();
            var dd = from p in dados.os where p.os_situacao.Equals(3) && p.login_id.Equals(id) select p;

            string escolha = "erro";

            foreach (var d in dd)
            {
                switch (d.os_escolha)
                {
                    case 1:
                        escolha = "Máquina não liga";
                        break;
                    case 2:
                        escolha = "Pasta da rede";
                        break;
                    case 3:
                        escolha = "Impressora";
                        break;
                    case 4:
                        escolha = "RMS Fora";
                        break;
                    case 5:
                        escolha = "Folhão Fora";
                        break;
                    case 6:
                        escolha = "Internet Fora";
                        break;
                    case 7:
                        escolha = "E-mail Fora";
                        break;
                    case 8:
                        escolha = "Mouse/Teclado Ruim";
                        break;
                    case 9:
                        escolha = "Transferência Login";
                        break;
                    case 0:
                        escolha = "Outro";
                        break;

                }

                if (d.os_situacao == 1)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Aberto",
                        Os_Id = d.os_id
                    });
                }
                else
                if (d.os_situacao == 2)
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Fechado",
                        Os_Id = d.os_id
                    });
                }
                else
                {
                    query2.Add(new Mchamado()
                    {
                        Login_Id = d.login_id,
                        DataA = d.os_dataa,
                        DataF = d.os_dataf,
                        Detalhe = d.os_detalhe,
                        Escolha = escolha,
                        NChamado = d.os_nos,
                        Situacao = "Andamento",
                        Os_Id = d.os_id
                    });
                }


            }

            return query2;
        }

        public void SalvaAndamento(int id, int os)
        {

            var update = (from u in dados.os where u.os_nos == os select u).FirstOrDefault();
            update.os_resolvendo_id = id;
            update.os_data_resolvendo = DateTime.Now;

            dados.SaveChanges();

        }

        public void FechaChamado(int id, int os,string solucao)
        {

            var update = (from u in dados.os where u.os_nos == os select u).FirstOrDefault();
            update.os_ok_administrador = true;
            update.os_solucao = solucao;
            update.os_situacao = 2;
            update.os_data_ok_administrador = DateTime.Now;

            dados.SaveChanges();

        }


    }
}