<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GameClient.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrador</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
                <div class="jumbotron" style="border:1px solid #a9074d; box-shadow:0px 2px 5px #d178f8">
                    <h1>Naval War<h1>
                    <h3>Administrador<h3>
                </div>
                <h1 class="display-4">Usuarios</h1>
                <div class="container">
                   <div class="row">
                       <%--Agregar usuario--%>
                       <div class="col">  
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1">Nickname</span>
                                <asp:TextBox ID="txtNickname"  placeholder="Nickname" runat="server" CssClass="form-control" aria-label="Nickname" aria-describedby="basic-addon1"></asp:TextBox>
                            </div>
                            <br>    
                            <div class="input-group">
                                <asp:TextBox ID="txtPassword"  placeholder="Contraseña" runat="server" CssClass="form-control" aria-label="Nickname" aria-describedby="basic-addon2"></asp:TextBox>
                                <span class="input-group-addon" id="basic-addon2">Contraseña</span>
                            </div>
                            <br>
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon3">@ejemplo.com</span>
                                <asp:TextBox ID="txtCorreo"  placeholder="Correo electronico" runat="server" CssClass="form-control" aria-label="Correo" aria-describedby="basic-addon1"></asp:TextBox>
                            </div>
                            <br>
                            <asp:Button ID="btnAddUser" runat="server" Text="Agregar usuario" CssClass="btn btn-danger"/>
                       </div>
                       <%--Eliminar usuario--%>
                       <br>
                       <div class="col">
                             <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1">Nickname</span>
                                <asp:TextBox ID="txtEliminar"  placeholder="Usuario a eliminar" runat="server" CssClass="form-control" aria-label="Nickname" aria-describedby="basic-addon1"></asp:TextBox>
                            </div>
                            <br>  
                            <asp:Button ID="btnDeleteUser" runat="server" Text="Eliminar usuario" CssClass="btn btn-danger"/>
                       </div>
                       <%--Modificar usuario--%>
                       <br>
                       <div class="col">
                             
                       </div>
                  </div>
                  <div class="row">
                        <%--Imagen del árbol--%>
                        <div class="col-8">
                            <asp:Image ID="imgBinario" runat="server" src="images/Fog.jpg" alt=""/>
                       </div>
                        <%--Datos del árbol--%>
                        <div class="col-4">

                        </div>
                  </div>
               </div>
          </div>
    </form>
</body>
</html>
