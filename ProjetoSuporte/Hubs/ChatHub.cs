using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ProjetoSuporte.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();

        }

        public void EnviarMensagem(string nome, string mensagem, string connId)
        {
            Clients.All.publicarMensagem(nome, mensagem);
            Clients.Client(connId).appendNewMessage(nome, mensagem);
            
        }


    }
}