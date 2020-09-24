using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Unit_ProjetoIntegrador_1
{
    public partial class Selecionar : Page
    {
        string sqlConexao = @"Data Source=CALIBURN\SQLEXPRESS;Initial Catalog=SolidTablesDB; Integrated Security=SSPI;";
        string usuarioID, deletar;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                usuarioID = User.Identity.GetUserId();
                deletar = Request.QueryString["deletar"];

                if (!String.IsNullOrEmpty(deletar))
                {
                    DeletaTabela();
                }

                CriaLinhas();
            }

        }

        private void DeletaTabela()
        {
            string cmd = "DELETE FROM [SolidTables] WHERE [SolidTablesUser]='" + usuarioID +
                "' AND[SolidTablesID]='" + deletar + "'";

            using (SqlConnection con = new SqlConnection(sqlConexao))
            {

                SqlCommand comando = new SqlCommand(cmd, con);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

            }

            Response.Redirect("~/Selecionar.aspx");

        }

        private void CriaLinhas()
        {

            string cmd = "SELECT SolidTablesID, Titulo FROM SolidTables WHERE SolidTablesUser = '" + usuarioID + "'";

            using (SqlConnection con = new SqlConnection(sqlConexao))
            {

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd, sqlConexao);
                adapter.Fill(dt);

                string teste = "";
                foreach (DataRow row in dt.Rows)
                {

                    if (dt.Rows.IndexOf(row) == 0)
                    {

                        CarregarTabelas.InnerHtml += "<li runat=\"server\">" +
                            "<a class=\"btn btn-link\" style=\"font-size:25px; padding:1; width:400px;\"href=\"Tabela?fichaID=" +
                            row[0].ToString() + "\" " + "runat=\"server\">" + row[1].ToString() + "</a>" +
                            "<div runat=\"server\" class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">" +
                            "<button onclick=\"window.location.href='Tabela?fichaID=" + row[0].ToString() +
                            "';\" runat=\"server\" type=\"button\" class=\"btn btn-info\">" +
                            "<span class=\"glyphicon glyphicon-edit\" aria-hidden=\"true\"></span></button>" +
                            "<button onclick=\"window.location.href='Selecionar?deletar=" + row[0].ToString() +
                            "';\" runat=\"server\" type=\"button\" class=\"btn btn-danger\">" +
                            "<span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\"></span></button>" +
                            "</div></li>";

                    }
                    else
                    {
                        if (row[0].ToString() != teste && !String.IsNullOrWhiteSpace(teste))
                        {
                            CarregarTabelas.InnerHtml += "<li>" +
                            "<a class=\"btn btn-link lista\" href=\"Tabela?fichaID=" +
                            row[0].ToString() + "\" " + "runat=\"server\">" + row[1].ToString() + "</a>" +
                            "<div runat=\"server\" class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">" +
                            //"<button class=\"btn btn-link\" style=\"font-size:25px; padding:0;\" " +
                            //"onclick=\"window.location.href=\"Tabela?fichaID=" +
                            // row[0].ToString() + "\" " + "runat=\"server\">" + row[1].ToString().Trim() + "</button>" + 
                             "<button onclick=\"window.location.href='Tabela?fichaID=" + row[0].ToString() +
                            "';\" runat=\"server\" type=\"button\" class=\"btn btn-info\">" +
                            "<span class=\"glyphicon glyphicon-edit\" aria-hidden=\"true\"></span></button>" +
                            "<button onclick=\"window.location.href='Selecionar?deletar=" + row[0].ToString() +
                            "';\" runat=\"server\" type=\"button\" class=\"btn btn-danger\">" +
                            "<span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\"></span></button>" +
                            "</div></li>";

                        }
                    }
                    teste = row[0].ToString();
                }

                divSelecionar.InnerHtml = "<button runat=\"server\" class=\"btn btn-info\" type=\"button\" " +
                    " onclick=\"window.location.href='Tabela?fichaID=Nova';\" style=\"font-size:20px;\">" +
                    "Criar Nova Tabela</ button>";

            }
        }
    }
}