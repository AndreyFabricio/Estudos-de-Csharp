<%@ Page Title="Modelos de Tabela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modelos.aspx.cs" Inherits="Unit_ProjetoIntegrador_1.Modelos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;"><%: Title %></h2>
    <hr />

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="Tabela?fichaID=Encontro">
                        <img src="/thumbnails/Encontro.png" alt="Tabela de Encontros" style="width: 100%" />
                        <div class="caption">
                            <p style="text-align: center;">Modelo de Tabela para Encontro Aleatório</p>
                        </div>
                    </a>
                </div>
            </div>

            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="Tabela?fichaID=Itens">
                        <img src="/thumbnails/Itens.png" alt="Tabela de Itens" style="width: 100%" />
                        <div class="caption">
                            <p style="text-align: center;">Modelo de Tabela para Itens</p>
                        </div>
                    </a>
                </div>
            </div>

            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="Tabela?fichaID=Tesouro">
                        <img src="/thumbnails/Tesouro.png" alt="Tabela de Tesouro" style="width: 100%" />
                        <div class="caption">
                            <p style="text-align: center;">Modelo de Tabela para Tesouros</p>
                        </div>
                    </a>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
