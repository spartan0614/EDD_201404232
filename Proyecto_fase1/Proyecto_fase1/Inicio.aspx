<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto_fase1.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Naval War | Inicio</title>
		<meta charset="utf-8">
		<link href="Login/css/style.css" rel='stylesheet' type='text/css' />
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
		<link href='http://fonts.googleapis.com/css?family=Open+Sans:600italic,400,300,600,700' rel='stylesheet' type='text/css'>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js" ></script>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <style type="text/css">
            .p-container {
            width: 521px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-xs-12">
            <div class="center-block">
                <div class="login-form">
	                <li>
		                <asp:TextBox ID="Nickname" class="form-control" placeholder="Usuario" runat="server" Width="500px" Height="50px"></asp:TextBox>
				        <a href="#" class=" icon user"></a>&nbsp;
	                </li>
			        <li>
                        <asp:TextBox ID="Contraseña" class="<%--form--%>-password form-control" placeholder="Contraseña" TextMode="Password" runat="server" Width="500px" Height="50px"></asp:TextBox>
			        </li>
                    <div class="form-group">
			            <div class="p-container">
                            <asp:Button ID="iniciarsesion" type="submit" class="btn btn-primary btn-lg" runat="server" Text="Ingresar"/>
			                <div class="clear"> </div>
		                </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
			
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
</body>
</html>
