<%@ Page Title="" Language="C#" MasterPageFile="~/paginaprincipal/Site1.Master" AutoEventWireup="true" CodeBehind="asignacion.aspx.cs" Inherits="ExamenFinal.capaVistas.asignacion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="menuprincipal" runat="server">


    
        <link href="../css/formularios.css" rel="stylesheet" />

 <form id="form1" runat="server">
        <Style>
 #usuario {
background-color: crimson; 
color: white; 
font-weight: bold; 

 }
    </Style>
       <h2>USUARIOS REGISTRADOS</h2>
  <br />
  <asp:GridView ID="GridView1" runat="server"></asp:GridView>
  <br />

  Código:
     <br />
  <asp:TextBox ID="tCodigoUsuario" Type="number" runat="server"></asp:TextBox>
  <br />

  Nombre:
     <br />
  <asp:TextBox ID="tNombreUsuario" runat="server"></asp:TextBox>
  <br />

  Correo Electrónico:
     <asp:TextBox ID="tCorreoElectronico" runat="server"></asp:TextBox>
 
  <br />

  Teléfono:
     <br />
  <asp:TextBox ID="tTelefono" runat="server"></asp:TextBox>
  <br />
     <br />
  <asp:CheckBox ID="MInactivos" runat="server" Text="Mostrar Inactivos" AutoPostBack="True"  />

  <br />
 

  <asp:Button ID="bAgregarUsuario" runat="server" Text="Agregar"    />
  <asp:Button ID="bModificarUsuario" runat="server" Text="Modificar"   />
  <asp:Button ID="bBorrarUsuario" runat="server" Text="Borrar"  />
<asp:Button ID="CamActividad" runat="server" Text="Activar"  />




 </form>

</asp:Content>
