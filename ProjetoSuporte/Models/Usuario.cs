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
    public class Usuario
    {

        DadosSuporte dados = new DadosSuporte();
        SqlCeConnection ligacao = new SqlCeConnection(@"Data source = :\Users\informatica\Desktop\ProjetoSuporte\ProjetoSuporte\App_Data\suporte.sdf ");

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [Display(Name = "Matrícula")]
        public int   matricula { get; set; }

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "Nome-Usuario")]
        public string     Nome { get; set; }


        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string    Senha { get; set; }

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [Display(Name = "Acesso")]
        public int   Acesso { get; set; }//1 - administrator   2 - administrador  3- usuario

        [Required(ErrorMessage = "O campo precisa ser preenchido")]
        [Display(Name = "Situação")]
        public bool Situacao { get; set; }

        public string Ramal { get; set;}

        public string LoginAtual { get; set; }
        

        //Métodos
        //=========================================================================================================================

        public bool verifica()
        {
            bool n  = true;
            var query = this.dados.login.Where(p => p.login_matricula == matricula).Count();

            if ( query == 0)
            {
                n = false;
            }else
            {
                n = true;
            }

            gravar(n);

            return n;
           
        }

        public void gravar(bool verifica)
        {
            if(verifica == false)
            {
                string data = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
                DateTime _dataA = Convert.ToDateTime(data);

                login ch = new login
                {
                    login_login = Nome,
                    login_senha = Senha,
                    login_acesso = Acesso.ToString(),
                    login_situacao = true,
                    login_matricula = matricula,
                    login_setor = Setor,
                    login_data_criacao = DateTime.Now
                };
                dados.login.Add(ch);
                dados.SaveChanges();
            }    
        }
        //insere os dados no dt_os
        public void gravaDtOs(string id_login, int dtos)
        {
            int _id = Convert.ToInt32(id_login);
            int idlogin = Convert.ToInt32(id_login);

            if (!VerificaDtOs(id_login))
            {

                dt_os ch = new dt_os
                {
                    login_id = Convert.ToInt32(id_login),
                    dt0 =0,dt1 =0, dt2=0,dt3=0,dt4=0,dt5=0,dt6=0,dt7=0,dt8=0,dt9=0
                   
                };
                dados.dt_os.Add(ch);
                dados.SaveChanges();

                var update = (from u in dados.dt_os where u.login_id == _id select u).FirstOrDefault();
                switch (dtos)
                {
                    case 1:
                        update.dt1 = QdtOS(dtos);
                        break;
                    case 2:
                        update.dt2 = QdtOS(dtos);
                        break;
                    case 3:
                        update.dt3 = QdtOS(dtos);
                        break;
                    case 4:
                        update.dt4 = QdtOS(dtos);
                        break;
                    case 5:
                        update.dt5 = QdtOS(dtos);
                        break;
                    case 6:
                        update.dt6 = QdtOS(dtos);
                        break;
                    case 7:
                        update.dt7 = QdtOS(dtos);
                        break;
                    case 8:
                        update.dt8 = QdtOS(dtos);
                        break;
                    case 9:
                        update.dt9 = QdtOS(dtos);
                        break;
                    case 0:
                        update.dt0 = QdtOS(dtos);
                        break;

                }

                dados.SaveChanges();

            }
            else
            {

 
                var update = (from u in dados.dt_os where u.login_id == _id select u).FirstOrDefault();
                switch (dtos)
                {
                    case 1:
                        update.dt1 = QdtOS(dtos);
                        break;
                    case 2:
                        update.dt2 = QdtOS(dtos);
                        break;
                    case 3:
                        update.dt3 = QdtOS(dtos);
                        break;
                    case 4:
                        update.dt4 = QdtOS(dtos);
                        break;
                    case 5:
                        update.dt5 = QdtOS(dtos);
                        break;
                    case 6:
                        update.dt6 = QdtOS(dtos);
                        break;
                    case 7:
                        update.dt7 = QdtOS(dtos);
                        break;
                    case 8:
                        update.dt8 = QdtOS(dtos);
                        break;
                    case 9:
                        update.dt9 = QdtOS(dtos);
                        break;
                    case 0:
                        update.dt0 = QdtOS(dtos);
                        break;

                }

                dados.SaveChanges();

            }
        }

        //verifica dtOs
        public bool VerificaDtOs(string id_login)
        {
            bool n = false;
            int ID = Convert.ToInt32(id_login);
            var query = this.dados.dt_os.Where(p => p.login_id == ID).Count();

            if (query == 0)
            {
                n = false;
            }
            else
            {
                n = true;
            }

            return n;
        }

        //Quantidade de chamados com mesmo pedido
        private int QdtOS(int dt)
        {
            
            int ID = Convert.ToInt32(HttpContext.Current.Session["id"]);
            int qdtos = 0;
            var dd = (from p in dados.dt_os where p.login_id.Equals(ID) select p).First();
            switch (dt)
            {
                case 0:
                    qdtos = Convert.ToInt32(dd.dt0);
                    break;
                case 1:
                    qdtos = Convert.ToInt32(dd.dt1);
                    break;
                case 2:
                    qdtos = Convert.ToInt32(dd.dt2);
                    break;
                case 3:
                    qdtos = Convert.ToInt32(dd.dt3);
                    break;
                case 4:
                    qdtos = Convert.ToInt32(dd.dt4);
                    break;
                case 5:
                    qdtos = Convert.ToInt32(dd.dt5);
                    break;
                case 6:
                    qdtos = Convert.ToInt32(dd.dt6);
                    break;
                case 7:
                    qdtos = Convert.ToInt32(dd.dt7);
                    break;
                case 8:
                    qdtos = Convert.ToInt32(dd.dt8);
                    break;
                case 9:
                    qdtos = Convert.ToInt32(dd.dt9);
                    break;
            }
      

            //Verifica se o valor é nulo
            if (dd == null)
            {
                qdtos = 1;
            }
            else
            {

                qdtos = qdtos + 1;
            }
 
            return qdtos;

        }

        //Verificaa se o login existe
        public bool VerificaLogin()
        {
            bool n = true;
            ligacao.Open();
            SqlCeDataAdapter adaptador = new SqlCeDataAdapter("SELECT * FROM login WHERE login_matricula = " + matricula + " AND login_senha = '"+ Senha +"'", ligacao);
            DataTable dados = new DataTable();
            adaptador.Fill(dados);
            if (dados.Rows.Count == 0)
            {
                n = false;
            }
            else
            {
                n = true;
            }

            ligacao.Close();
            ligacao.Dispose();
            return n;

        }

        public string PegaUsuario()
        {
            string Usuario = "";
            Usuario =   UsuarioRepositorio.GetUsuarioLogado();
           
            return Usuario;
        }

        //filtros
        public List<Usuario>DadosUsuario(int id)
        {

            DadosSuporte dados = new DadosSuporte();

            List<Usuario> query2 = new List<Usuario>();
            var dd = (from p in dados.login where p.login_id == id select p);
            foreach (var d in dd)
            {
                query2.Add(new Usuario()
                {
                    Id = d.login_id,
                    Nome = d.login_login,
                    Setor = d.login_setor,
                    matricula =d.login_matricula,
                    Situacao = d.login_situacao,

                });

            }
                
            return query2;
        }
    }
}