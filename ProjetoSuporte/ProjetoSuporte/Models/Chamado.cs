using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.Entity;
using System.Text;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;
using System.Web.Mvc;

namespace ProjetoSuporte.Models
{
    public class Chamado
    {

        SqlCeConnection ligacao = new SqlCeConnection(@"Data source = C:\Users\administrator\Desktop\ProjetoSuporte\ProjetoSuporte\App_Data\suporte.sdf ");

        [Display(Name = "Id_Chamado")]
        public int Os_Id { get; set; }

        [Display(Name = "Id_Login")]
        public int Login_Id { get; set; }

        [Display(Name = "Problema")]
        public int Escolha { get; set; }

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [Display(Name = "Detalhes Do Problema")]
        public string Detalhe { get; set; }

        [Display(Name = "Data de Abertura")]
        public DateTime DataA { get; set; }

        [Display(Name = "Data De Fechamento")]
        public DateTime DataF { get; set; }

        [Display(Name = "Nº De Chamado")]
        public int NChamado { get; set; }

        [Display(Name = "Situação")]
        public int Situacao { get; set; }

        [Display(Name = "Prooridade")]
        public int prioridade { get; set; }
        //===========================================================================================================================
        //Exclusivo para gerente e Informática
        [Display(Name = "Setor")]
        public int Setor { get; set; }

        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime PrazoFinal { get; set; }

        public string solucao { get; set; }


        //Métodos
        DadosSuporte dados = new DadosSuporte();
        DateTime data = DateTime.Now;

        public int IncluiDados()
        {

            //string data = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            //DateTime _dataA = Convert.ToDateTime(data);
            DateTime _dataF = Convert.ToDateTime("1900-01-01");
            int NuChamado = CriaNchamado();
            string ID = HttpContext.Current.Session["id"].ToString();
            int id = Convert.ToInt32(ID);
            var query = dados.login.Where(p => p.login_id == id);


            /*
             * O login_id é chave estrangeira de login. Logo ela deve ter o mesmo valor
             * de uma chave primaria de login
             */
            os ch = new os
            {

                login_id = id, os_escolha = Escolha, os_detalhe = Detalhe, os_dataa = DateTime.Now,
                os_dataf = _dataF, os_nos = NuChamado, os_situacao = 1, os_data_resolvendo = _dataF,
                os_data_ok_administrador = _dataF, os_data_ok_usuario = _dataF

            };
            dados.os.Add(ch);
            dados.SaveChanges();

            return NuChamado;

        }
        public void AtualizaDados()
        {

        }
        public void BuscaChamados()
        {

        }
        private int CriaNchamado()
        {
            int Numchamado = 0;
            //Cria um numero de chamado sequencial
            //Busca o ultimo número do chamado
            try
            {
                var chamado = dados.os.Max(p => p.os_nos);
                Numchamado = chamado + 1;
            }
            catch (Exception e)
            {
                Numchamado = 1;
            }

            return Numchamado;

        }

        private int busca()
        {

            ligacao.Open();
            //Cria um numero de chamado sequencial
            //Busca o ultimo número do chamadoS
            string ID = HttpContext.Current.Session["id"].ToString();

            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM os WHERE login_id = " + ID + "", ligacao);
            DataSet dados = new DataSet();

            adaptador.Fill(dados, "os");
            //Verifica se o valor é nulo



            ligacao.Close();
            ligacao.Dispose();
            return 1;
        }

        public int acesso()
        {
            int id = 0;
            int acesso = 0;
            try {
                int ID = Convert.ToInt32(HttpContext.Current.Session["id"]);
                id = ID;
            }
            catch
            {

            }
            login login = new login();
            var valida = (from u in dados.login where u.login_id == id select u).FirstOrDefault();
            //1 - administrador  2 - gerente  3 - normal
            if ((valida.login_acesso == "administrator")||(valida.login_acesso == "1")){
                acesso = 1;
            }else 
            if(valida.login_acesso == "2")
            {
                acesso = 2;
            }else
            if(valida.login_acesso == "3")
            {
                acesso = 3;
            }
            return acesso;
        }

        public List<SelectListItem> listaCombo()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            List<SelectListItem> listaUsuario = new List<SelectListItem>() {
                           new SelectListItem {Text = "Máquina não liga",Value = "1" },
             new SelectListItem { Text = "Pasta da rede", Value = "2" },
             new SelectListItem {Text = "Impressora",Value = "3" },
             new SelectListItem {Text = "RMS",Value = "4" },
             new SelectListItem {Text = "Intra Net",Value = "5" },
             new SelectListItem {Text = "Internet",Value = "6" },
             new SelectListItem {Text = "E-mail",Value = "7" },
             new SelectListItem {Text = "Solicitações",Value = "8" },
             new SelectListItem {Text = "Transferências",Value = "9" },
             new SelectListItem {Text = "Outro",Value = "0" }
            };

            List<SelectListItem> listaManutencao = new List<SelectListItem>() {
                           new SelectListItem {Text = "A definir",Value = "1" },
             new SelectListItem { Text = "Adefinir", Value = "2" },
             new SelectListItem {Text = "A definir",Value = "3" },
             new SelectListItem {Text = "A definir",Value = "4" },
             new SelectListItem {Text = "A definir",Value = "5" },
             new SelectListItem {Text = "A definir",Value = "6" },
             new SelectListItem {Text = "A definir",Value = "7" },
             new SelectListItem {Text = "A definir",Value = "8" },
             new SelectListItem {Text = "A definir",Value = "9" },
             new SelectListItem {Text = "A definir",Value = "0" }
            };

            lista = listaUsuario;
            return lista;
        }

        public List<SelectListItem> listaSetor()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            List<SelectListItem> listaUsuario = new List<SelectListItem>() {
             new SelectListItem {Text = "Informática",Value = "1" },
             new SelectListItem { Text = "manutenção", Value = "2" },
       
            };

            
            lista = listaUsuario;
            return lista;
        }

        public List<SelectListItem> listaTipo()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            List<SelectListItem> listaUsuario = new List<SelectListItem>() {
             new SelectListItem {Text = "PDV",Value = "1" },
             new SelectListItem { Text = "HARDWARE", Value = "2" },
             new SelectListItem { Text = "SISTEMA RMS", Value = "3" },
             new SelectListItem { Text = "SISTEMA EMPORIUM", Value = "4" },
             new SelectListItem { Text = "SISTEMA REDE LÓGICA", Value = "5" },
             new SelectListItem { Text = "REDE ELÉTRICA ESTABILIZADA", Value = "6" },
             new SelectListItem { Text = "IMPRESSORA", Value = "7" },
             new SelectListItem { Text = "CFTV", Value = "8" },
             new SelectListItem { Text = "BALANÇAS ÁREAS DE VENDAS", Value = "9" }

            };


            lista = listaUsuario;
            return lista;
        }

        public List<SelectListItem> listaPrioridade()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            List<SelectListItem> listaUsuario = new List<SelectListItem>() {
             new SelectListItem {Text = "NORMAL",Value = "1" },
             new SelectListItem { Text = "URGENTE", Value = "2" }

            };


            lista = listaUsuario;
            return lista;
        }

    }



}