<%@ Page Title="" Language="C#" MasterPageFile="~/adm/ManageUser.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="CeuEscuro.UI.adm.Film" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblSession" runat="server" Text=""></asp:Label>

    <%--formulario--%>
    <ul>
        <li>
            <asp:TextBox ID="txtId" placeholder="Id:" runat="server"></asp:TextBox>
        </li>
        <li>
            <asp:TextBox ID="txtTitulo" placeholder="Titulo:" MaxLength="150" runat="server"></asp:TextBox>
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
        </li>
        <li>
            <asp:TextBox ID="txtProdutora" placeholder="Produtora:" MaxLength="150" runat="server"></asp:TextBox>
            <asp:Label ID="lblProdutora" runat="server" Text=""></asp:Label>
        </li>
        <%--<li>
       <asp:TextBox ID="txtSenha" placeholder="Senha:" MaxLength="6" runat="server"></asp:TextBox>
        <asp:Label ID="lblSenha" runat="server" Text=""></asp:Label>
   </li>--%>
        <%-- <li>
       <asp:TextBox ID="txtDataNascUsuario" onkeypress="$(this).mask('00/00/0000')" placeholder="Data de nascimento:" runat="server"></asp:TextBox>
        <asp:Label ID="lblDataNascUsuario" runat="server" Text=""></asp:Label>
   </li>--%>
        <li>
            <span>Selecione a Classificação:</span>
        </li>

        <li>
            <asp:DropDownList
                ID="ddlClassif"
                Width="160px"
                Height="27px"
                AutoPostBack="false"
                DataValueField="Id"
                DataTextField="DescricaoClassif"
                runat="server">
            </asp:DropDownList>
        </li>

        <li>
            <span>Selecione o Gênero:</span>
        </li>

        <li>
            <asp:DropDownList
                ID="ddlGenero"
                Width="160px"
                Height="27px"
                AutoPostBack="false"
                DataValueField="Id"
                DataTextField="Descricao"
                runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <asp:FileUpload ID="Fup" runat="server"></asp:FileUpload>
            <asp:Label ID="lblFup" runat="server" Text=""></asp:Label>
        </li>


        <li>
            <asp:Button ID="btnRecord" runat="server" Text="Record" OnClick="btnRecord_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="if(!confirm('Deseja realmente eliminar esse registro ?'))return false" OnClick="btnDelete_Click" />
        </li>
        <li>
            <asp:TextBox ID="txtSearch" placeholder="Search by Name:" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Label ID="lblSearch" runat="server" Text=""></asp:Label>
        </li>
    </ul>

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <li> 
 <asp:TextBox ID="TextBox1" placeholder="Search by Genero:" runat="server"></asp:TextBox>
 <asp:Button ID="Button1" runat="server" Text="Button" />
 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </li>
       
    

  <li> 
      <%--// Filtar por genero--%>
      <<asp:TextBox ID="txtFiltro" runat="server" placeholder="Filter by Genre:" AutoCompleteType="Disabled"></asp:TextBox>
      <asp:Button ID="btnFiltro" runat="server" Text="Filter" OnClick="btnFiltro_Click" />
      <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
      <asp:Label ID="lblFiltro" runat="server" Text="Label"></asp:Label>

     

  </li>

     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

     
 <%--gridView--%>
    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="gv2_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderText="Options" />
            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
            <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação_Id" />
            <asp:BoundField DataField="Genero_Id" HeaderText="Genero_Id" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="100" />

        </Columns>

    </asp:GridView>

</asp:Content>
