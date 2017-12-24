<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Proyecto_fase1.Administrador" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Naval War | Administrador</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href="./css/bootstrap.min.css" rel="stylesheet">
    <link href="./css/main.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand" href="#">Administrador</a>
            </nav>
        </div>

        <div class="container">
           <%-- <div class="col-xs-6 col-sm-3  col-md-12">--%>
                <form>
                    <div class="form-group"> 
                        <asp:Button ID="SubirUsuarios" type="submit" class="btn btn-secondary btn-sm" runat="server" Text="Buscar" Height="25px"/></asp:Button>
                        
                        <asp:TextBox ID="FileUsers" class="form-control mb-2 mr-sm-2 mb-sm-0" placeholder="Usuarios" runat="server" Width="250px" Height="25px"></asp:TextBox>
                    </div>
                </form>
           <%-- </div>--%>
        </div>

    </form>
</body>
</html>
