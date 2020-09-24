<%@ Page Title="Solid Tables" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Unit_ProjetoIntegrador_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Solid Tables</h1>
        <p class="lead">Uma solução para facilitar suas campanhas de RPG.</p>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Crie Sua Conta</h2>
            <p>
                Acessar o sistema é fácil, basta apenas criar uma conta no link abaixo.
            </p>
            <p>
                <a class="btn btn-info" href="/Account/Register">Crie sua Conta &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Já possuí uma conta?</h2>
            <p>
                Faça login no sistema.
            </p>
            <p>
                <a class="btn btn-info" href="/Account/Login">Login &raquo;</a>
            </p>
        </div>        
    </div>

</asp:Content>
