﻿<%@ Page Title="" Language="C#" MasterPageFile="~/USER/ManagerUser.Master" AutoEventWireup="true" CodeBehind="Consultafilme.aspx.cs" Inherits="CeuEscuro.UI.USER.Consultafilme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

    <%--gridView--%>
    <asp:GridView ID="gv2" AutoGenerateColumns="false" runat="server" 
          </Columns>  
            <asp:BoundField DataField="Id" HeaderText="Código" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="Produtora" HeaderText="Produtora" />
            <asp:BoundField DataField="Classificacao_Id" HeaderText="Classificação_Id" />
            <asp:BoundField DataField="Genero_Id" HeaderText="Genero_Id" />
            <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Imagem" ControlStyle-Width="100" />

        </Columns>

    </asp:GridView>
</asp:Content>