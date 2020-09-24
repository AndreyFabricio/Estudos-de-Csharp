<%@ Page Title="Tabelas Salvas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Selecionar.aspx.cs" Inherits="Unit_ProjetoIntegrador_1.Selecionar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h2 style="text-align:center;">Tabelas Salvas</h2>
        <div class="jumbotron" style="width:56%;">
            <div class="container">
                <ul class="list-unstyled" id="CarregarTabelas" runat="server"></ul>
            </div>
        </div>
        <div class="container" id="divSelecionar" runat="server"></div>
    </center>
    <br />    
</asp:Content>
