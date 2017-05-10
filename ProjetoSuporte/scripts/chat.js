/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="jquery.signalR-2.2.1.js" />
$(function () {
    var chat = $.connection.chatHub;

    chat.client.publicarMensagem = function (nome, mensagem) {
        var containerNome = $('<span/>').text(nome).html(); //Nome do usuário
        var containerMensagem = $('<div/>').text(mensagem).html(); //Local de digitar mensagem

        //Mostra a mensagem na tela
        $("#conversa").append(
            '<li><strong id="linome">'
            + containerNome +
            '</strong><p id="limensagem">'
            + containerMensagem + '</p></li>');
    };

    $.connection.hub.start().done(function () {

        $(document).keypress(function (e) {
            if (e.which == 13) {
                var nome = $("#nome").val();
                var mensagem = $("#mensagem").val();

                chat.server.enviarMensagem(nome, mensagem);

                $("#mensagem").val('');
            }
        });


    });

});