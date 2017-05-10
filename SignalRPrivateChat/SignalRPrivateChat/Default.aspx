<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SignalRPrivateChat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Private Chat App</title>
    
    <link href="<%=Page.ResolveUrl("~") %>Styles/bootstrap.css" rel="stylesheet" />
    <link href="<%=Page.ResolveUrl("~") %>Styles/style.css" rel="stylesheet" />
    <script src="<%=Page.ResolveUrl("~") %>Scripts/jquery.js"></script>
    <script src="<%=Page.ResolveUrl("~") %>Scripts/bootstrap.min.js"></script>
    
</head>
<body>
    <figure class="site-title"> <a href="http://www.supermercadosinter.com.br/" target="_blank"> <img src="images/logo-Inter.png"/> </a> </figure>
    <form id="form1" runat="server">

        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Por Favor Confirme SUa Identidade</h3>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <fieldset>
                                    <div class="form-group">
                                        <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlUsers" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Rafael</asp:ListItem>
                                            <asp:ListItem Value="1">Rafael</asp:ListItem>
                                             <asp:ListItem Value="2">Ingrid</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" ValidationGroup="valgrp" ControlToValidate="ddlUsers" InitialValue="0" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Select User."></asp:RequiredFieldValidator>
                                    </div>
                                    <!-- Change this to a button or input when using this as a form -->
                                    <asp:Button ID="btnLogin" CssClass="btn btn-lg btn-success btn-block" ValidationGroup="valgrp" Text="Login" runat="server" OnClick="btnLogin_Click" />
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

       <footer id="rodape">           
                    <p id="rodape2">Tel:2107-8049 &nbsp;&nbsp; 2107-8026 &nbsp;&nbsp;2107-8023<br/> &copy; <%=@DateTime.Now.Year%> - Informática Inter</p>       
       </footer>

</body>
</html>
