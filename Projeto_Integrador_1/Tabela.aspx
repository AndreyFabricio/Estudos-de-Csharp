<%@ Page Title="Tabela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tabela.aspx.cs" Inherits="Unit_ProjetoIntegrador_1.Tabela" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="panel" style="text-align:center;">

        <h3>Opções da Tabela</h3>
        <br />

        <table style="display:inline-block;">
            <tr>
                <td>
                    <asp:Label Text="Título da Tabela: " runat="server" Font-Bold="True" />
                </td>
                <td style="padding-left:5px;">
                    <asp:TextBox ID="EditarTitulo" runat="server" CssClass="form-control" Text="Sem Título" Width="180px" />
                </td>
                <td style="padding-left:20px;">
                    <asp:Label Text="Tipo de Tabela: " runat="server" Font-Bold="True" />
                </td>
                <td style="padding-left:5px;">
                    <asp:DropDownList ID="TabelaOpcoesDD" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Encontro Aleatório" />
                        <asp:ListItem Text="Tesouro" />
                        <asp:ListItem Text="Item Mágico" />
                    </asp:DropDownList>
                </td>
                <td style="padding-left:20px;">
                    <asp:Label Text="Dado: " runat="server" Font-Bold="True" />
                </td>
                <td style="padding-left:5px;">
                    <asp:DropDownList ID="DadoDD" CssClass="form-control" runat="server" Width="85px">
                        <asp:ListItem Text="1D4" />
                        <asp:ListItem Text="1D6" />
                        <asp:ListItem Text="1D8" />
                        <asp:ListItem Text="1D10" />
                        <asp:ListItem Text="1D12" />
                        <asp:ListItem Text="1D20" />
                        <asp:ListItem Text="2D10 (100%, 1D100)" />
                    </asp:DropDownList>
                </td>
                <td style="padding-left:20px;">
                    <asp:Button ID="btnConfirmaOpcoes" class="btn btn-info" Text="Confirmar" 
                        runat="server" OnClick="ConfirmaOpcoes"/>
                </td>
            </tr>
        </table>        

    </div>

    <br />

    <div id="TabelaEsconder" style="visibility:hidden;" runat="server">
        <center>
        <asp:Label Text="Sem Título" ID="TabelaTitulo" runat="server" style="font-size:25px; text-align:center;" />
    </center>

        <br />

        <asp:GridView ID="TabelaPrincipal" runat="server" AutoGenerateColumns="False" ShowFooter="True"
            CssClass="table table-responsive-lg table-striped table-hover table-bordered text-center"
            DataKeyNames="LinhaID" ShowHeaderWhenEmpty="True"
            OnRowCommand="TabelaPrincipal_RowCommand" OnRowEditing="TabelaPrincipal_RowEditing"
            OnRowCancelingEdit="TabelaPrincipal_RowCancelingEdit" OnRowUpdating="TabelaPrincipal_RowUpdating"
            OnRowDeleting="TabelaPrincipal_RowDeleting" HorizontalAlign="Center">
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <SortedAscendingCellStyle HorizontalAlign="Center" VerticalAlign="Middle" />

            <Columns>

                <asp:TemplateField HeaderText="Encontro">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Encontro") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEncontro" Text='<%# Eval("Encontro") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtEncontroFooter" runat="server" />
                    </FooterTemplate>
                    <HeaderStyle />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ND">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ND") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtND" Text='<%# Eval("ND") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtNDFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Experiencia">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Experiencia") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtExperiencia" Text='<%# Eval("Experiencia") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtExperienciaFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descricao">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Descricao") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescricao" Text='<%# Eval("Descricao") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtDescricaoFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Probabilidade">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Probabilidade") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProbabilidade" Text='<%# Eval("Probabilidade") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtProbabilidadeFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Icones/edit.png" runat="server" CommandName="Edit"
                            ToolTip="Editar Linha" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Icones/delete.png" runat="server" CommandName="Delete"
                            ToolTip="Deletar Linha" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Icones/save.png" runat="server" CommandName="Update"
                            ToolTip="Salvar Linha" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Icones/clear.png" runat="server" CommandName="Cancel"
                            ToolTip="Cancelar" Width="20px" Height="20px" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Icones/add.png" runat="server" CommandName="AddNew"
                            ToolTip="Adicionar Linha" Width="20px" Height="20px" />
                    </FooterTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <%--<br />--%>

        <center>

        <asp:Label ID="lblSucesso" Text="" runat="server" ForeColor="Green" Font-Size="X-Large" />
        <br />
        <asp:Label ID="lblFalha" Text="" runat="server" ForeColor="Red" Font-Size="X-Large" />
        <%--<br />--%>
        <div class="btn-group" role="group">
            <asp:Button ID="ImprimirBtn" class="btn btn-info" Text="Imprimir " 
                        runat="server" OnClientClick="ImprimirTabela()"/>
            <div class="btn-group" role="group">
                <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown"
                    aria-haspopup="true" aria-expanded="false">
                    Exportar <span class="caret"></span>
                </button>
                <ul class="dropdown-menu">
                    <li><a href="#" onserverclick="ExportarPDF" runat="server">Adobe - PDF</a></li>
                    <li><a href="#" onserverclick="ExportarDOC" runat="server">Word - DOC</a></li>
                    <li><a href="#" onserverclick="ExportarCSV" runat="server">Excel - XLS</a></li>
                </ul>
            </div>
        </div>            
    </center>
    </div>    

    <script>
        function ImprimirTabela()
        {

            var prtContent = '<center>' + document.getElementById('<%= TabelaTitulo.ClientID %>').outerHTML + '<br /><br />' +
            document.getElementById('<%= TabelaPrincipal.ClientID %>').outerHTML + '</center>';
            var WinPrint = window.open('print.htm', 'PrintWindow', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1');

            WinPrint.document.write(prtContent);

            var rows = WinPrint.document.getElementById('<%= TabelaPrincipal.ClientID %>').rows;
            for (var i = 0; i < rows.length; i++) {
                rows[i].deleteCell(-1);
            }
            WinPrint.document.getElementById('<%= TabelaPrincipal.ClientID %>').deleteRow(-1);

            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();            
            
        }
    </script>

</asp:Content>
