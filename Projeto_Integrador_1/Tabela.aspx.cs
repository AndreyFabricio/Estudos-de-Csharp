using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Document = iTextSharp.text.Document;

namespace Unit_ProjetoIntegrador_1
{
    public partial class Tabela : Page
    {
        string sqlConexao = @"Data Source=CALIBURN\SQLEXPRESS;Initial Catalog=SolidTablesDB; Integrated Security=SSPI;";
        string usuarioID, fichaID, dado;
        bool novaTabela = false;
        string tipo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioID = User.Identity.GetUserId();

            if (Request.QueryString["fichaID"] != "Nova" && Request.QueryString["fichaID"] != "Encontro"
                && Request.QueryString["fichaID"] != "Itens" && Request.QueryString["fichaID"] != "Tesouro")
                fichaID = Request.QueryString["fichaID"];
            else
            {
                if (Request.QueryString["fichaID"] == "Encontro")
                {
                    tipo = "STID02";
                    //CarregarModelo(tipo);
                }
                else
                {
                    if (Request.QueryString["fichaID"] == "Itens")
                    {
                        tipo = "STID04";
                        //CarregarModelo(tipo);
                    }
                    else
                    {
                        if (Request.QueryString["fichaID"] == "Tesouro")
                        {
                            tipo = "STID03";
                            //CarregarModelo(tipo);
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["fichaID"] == "Nova")
                {
                    novaTabela = true;
                    TabelaEsconder.Style["visibility"] = "hidden";
                    NovaFichaID();
                }
                else
                {
                    PreencherGridView();
                }
            }
        }

        public void CarregarModelo(string tipo)
        {

            //NovaFichaID();

            DataTable dt = new DataTable();
            DataRow row;

            using (SqlConnection con = new SqlConnection(sqlConexao))
            {

                NovaFichaID();

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [LinhaID], [Titulo], [Encontro], [ND], [Experiencia], [Descricao], " +
                    "[Probabilidade], [Tipo], [Dado] " +
                    "FROM [SolidTables] WHERE [SolidTablesID] = '" + tipo + "'", con);

                da.Fill(dt);
                con.Close();
            }

            if (dt.Rows.Count > 0)
            {
                TabelaPrincipal.DataSource = dt;
                TabelaPrincipal.DataBind();
                row = dt.Rows[0];
                dado = row[8].ToString();
                novaTabela = false;
                TabelaEsconder.Style["visibility"] = "visible";
                PreencherHeader(row[7].ToString(), row[8].ToString());

                if (String.IsNullOrEmpty(row[2].ToString()) && String.IsNullOrEmpty(EditarTitulo.Text))
                {
                    TabelaTitulo.Text = "Sem Título";
                    EditarTitulo.Text = "Sem Título";
                }
                else
                {
                    if (String.IsNullOrEmpty(row[2].ToString()) && !String.IsNullOrEmpty(EditarTitulo.Text))
                    {
                        TabelaTitulo.Text = EditarTitulo.Text;
                        TabelaOpcoesDD.Text = row[7].ToString();
                        DadoDD.Text = row[8].ToString();
                    }
                    else
                    {
                        TabelaTitulo.Text = row[2].ToString();
                        EditarTitulo.Text = row[2].ToString();
                        TabelaOpcoesDD.Text = row[7].ToString();
                        DadoDD.Text = row[8].ToString();
                    }
                }

            }

            foreach (DataRow row1 in dt.Rows)
            {
                using (SqlConnection con = new SqlConnection(sqlConexao))
                {
                    con.Open();
                    string query = "INSERT INTO SolidTables ([SolidTablesID], [SolidTablesUser], [Titulo], [Encontro], [ND]" +
                        ", [Experiencia], [Descricao], [Probabilidade], [Tipo], [Dado])" +
                        "VALUES (@Titulo, @Encontro, @ND, @Experiencia, @Descricao, @Probabilidade, @Tipo, @Dado)";
                    //" WHERE [SolidTablesUser]=@SolidTablesUser AND [SolidTablesID]=@SolidTablesID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Titulo", row1[1]);
                    cmd.Parameters.AddWithValue("@Encontro", row1[2]);
                    cmd.Parameters.AddWithValue("@ND", row1[3]);
                    cmd.Parameters.AddWithValue("@Experiencia", row1[4]);
                    cmd.Parameters.AddWithValue("@Descricao", row1[5]);
                    cmd.Parameters.AddWithValue("@Probabilidade", row1[6]);
                    cmd.Parameters.AddWithValue("@Tipo", row1[7]);
                    cmd.Parameters.AddWithValue("@Dado", row1[8]);
                    //cmd.Parameters.AddWithValue("@SolidTablesUser", usuarioID);
                    //cmd.Parameters.AddWithValue("@SolidTablesID", fichaID);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    // PreencherGridView();

                }
            }

            tipo = string.Empty;
            Response.Redirect("~/Tabela?fichaID=" + fichaID);

        }

        public void NovaFichaID()
        {
            DataTable dt = new DataTable();
            DataRow row;
            using (SqlConnection con = new SqlConnection(sqlConexao))
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT SolidTablesID FROM SolidTables " +
                    "WHERE [SolidTablesUser]='" + usuarioID + "' ORDER BY SolidTablesID DESC", con);

                da.Fill(dt);
                try
                {
                    row = dt.Rows[dt.Rows.Count];
                    fichaID = "STID0" +
                        Convert.ToString(Convert.ToInt32(row[0].ToString().Remove(0, 5)) + 1);
                }
                catch (Exception)
                {

                    da = new SqlDataAdapter("SELECT SolidTablesID FROM SolidTables", con);

                    da.Fill(dt);
                    row = dt.Rows[dt.Rows.Count - 1];
                    fichaID = "STID0" +
                        Convert.ToString(Convert.ToInt32(row[0].ToString().Remove(0, 5)) + 1);
                }
                con.Close();

                if (string.IsNullOrEmpty(tipo))
                    Response.Redirect("~/Tabela?fichaID=" + fichaID);
            }
        }

        protected void TabelaPrincipal_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TabelaPrincipal.EditIndex = e.NewEditIndex;
            PreencherGridView();
        }

        protected void TabelaPrincipal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TabelaPrincipal.EditIndex = -1;
            PreencherGridView();
        }

        protected void TabelaPrincipal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(sqlConexao))
                {
                    con.Open();
                    string query = "UPDATE SolidTables SET Titulo=@Titulo, Encontro=@Encontro, ND=@ND, " +
                    "Experiencia=@Experiencia, Descricao=@Descricao, Probabilidade=@Probabilidade" +
                    " WHERE LinhaID=@LinhaID"; // AND SolidTablesUser='" + usuarioID + "'" + " AND SolidTablesID='" + fichaID + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Encontro",
                        (TabelaPrincipal.Rows[e.RowIndex].FindControl("txtEncontro") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@ND",
                        (TabelaPrincipal.Rows[e.RowIndex].FindControl("txtND") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Experiencia",
                        (TabelaPrincipal.Rows[e.RowIndex].FindControl("txtExperiencia") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Descricao",
                        (TabelaPrincipal.Rows[e.RowIndex].FindControl("txtDescricao") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Probabilidade",
                        (TabelaPrincipal.Rows[e.RowIndex].FindControl("txtProbabilidade") as TextBox).Text.Trim());

                    cmd.Parameters.AddWithValue("@Titulo", TabelaTitulo.Text);

                    cmd.Parameters.AddWithValue("@LinhaID",
                        Convert.ToInt32(TabelaPrincipal.DataKeys[e.RowIndex].Value.ToString()));

                    cmd.ExecuteNonQuery();
                    TabelaPrincipal.EditIndex = -1;
                    con.Close();
                    PreencherGridView();

                    lblSucesso.Text = "Linha Selecionada Atualizada";

                }
            }
            catch (Exception ex)
            {

                lblSucesso.Text = "";
                lblFalha.Text = ex.Message;
            }
        }

        protected void TabelaPrincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(sqlConexao))
                {
                    con.Open();
                    string query = "DELETE FROM SolidTables WHERE LinhaID=@LinhaID"; // AND SolidTablesUser='" + usuarioID + "'" + " AND SolidTablesID='" + fichaID + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@LinhaID",
                        Convert.ToInt32(TabelaPrincipal.DataKeys[e.RowIndex].Value.ToString()));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    PreencherGridView();

                    lblSucesso.Text = "Linha Deletada";

                }
            }
            catch (Exception ex)
            {

                lblSucesso.Text = "";
                lblFalha.Text = ex.Message;
            }
        }

        protected void TabelaPrincipal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew")) // Adiciona Linhas à tabela
                {
                    using (SqlConnection con = new SqlConnection(sqlConexao))
                    {
                        con.Open();
                        string query = "INSERT INTO [SolidTables] ([SolidTablesID], [SolidTablesUser], [Titulo], " +
                            "[Encontro], [ND], [Experiencia], [Descricao], [Probabilidade], [Dado]) " +
                            "VALUES (@SolidTablesID, @SolidTablesUser, @Titulo, @Encontro, @ND, @Experiencia, " +
                            "@Descricao, @Probabilidade, @Dado)";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@SolidTablesID", fichaID);
                        cmd.Parameters.AddWithValue("@SolidTablesUser", usuarioID);
                        cmd.Parameters.AddWithValue("@Titulo", TabelaTitulo.Text);

                        cmd.Parameters.AddWithValue("@Encontro",
                            (TabelaPrincipal.FooterRow.FindControl("txtEncontroFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@ND",
                            (TabelaPrincipal.FooterRow.FindControl("txtNDFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Experiencia",
                            (TabelaPrincipal.FooterRow.FindControl("txtExperienciaFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Descricao",
                            (TabelaPrincipal.FooterRow.FindControl("txtDescricaoFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Probabilidade",
                            (TabelaPrincipal.FooterRow.FindControl("txtProbabilidadeFooter") as TextBox).Text.Trim());

                        cmd.Parameters.AddWithValue("@Dado", TabelaPrincipal.HeaderRow.Cells[4].Text);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        PreencherGridView();

                        if (novaTabela == true || TabelaPrincipal.Rows.Count == 1)
                        {
                            PreencherHeader(TabelaOpcoesDD.Text, DadoDD.Text);
                            lblSucesso.Text = "Tabela Salva";
                        }
                        else
                        {
                            lblSucesso.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                lblSucesso.Text = "";
                lblFalha.Text = ex.Message;
            }
        }

        public void PreencherGridView()
        {

            try
            {
                DataTable dt = new DataTable();
                DataRow row;
                using (SqlConnection con = new SqlConnection(sqlConexao))
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SolidTables WHERE [SolidTablesUser]='"
                        + usuarioID + "' AND [SolidTablesID]='" + fichaID + "'", con);
                    da.Fill(dt);
                    con.Close();
                }

                if (dt.Rows.Count > 0)
                {
                    TabelaPrincipal.DataSource = dt;
                    TabelaPrincipal.DataBind();
                    row = dt.Rows[0];
                    dado = row[10].ToString();
                    novaTabela = false;
                    TabelaEsconder.Style["visibility"] = "visible";
                    PreencherHeader(row[9].ToString(), row[10].ToString());

                    if (String.IsNullOrEmpty(row[3].ToString()) && String.IsNullOrEmpty(EditarTitulo.Text))
                    {
                        TabelaTitulo.Text = "Sem Título";
                        EditarTitulo.Text = "Sem Título";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(row[3].ToString()) && !String.IsNullOrEmpty(EditarTitulo.Text))
                        {
                            TabelaTitulo.Text = EditarTitulo.Text;
                            TabelaOpcoesDD.Text = row[9].ToString();
                            DadoDD.Text = row[10].ToString();
                        }
                        else
                        {
                            TabelaTitulo.Text = row[3].ToString();
                            EditarTitulo.Text = row[3].ToString();
                            TabelaOpcoesDD.Text = row[9].ToString();
                            DadoDD.Text = row[10].ToString();
                        }
                    }

                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    TabelaPrincipal.DataSource = dt;
                    TabelaPrincipal.DataBind();
                    TabelaPrincipal.Rows[0].Cells.Clear();
                    TabelaPrincipal.Rows[0].Cells.Add(new TableCell());
                    TabelaPrincipal.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count; // Célula do tamanho da linha
                    TabelaPrincipal.Rows[0].Cells[0].Text = "Adicione uma Linha Para Salvar a Tabela";
                    TabelaPrincipal.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    dado = DadoDD.Text;
                    novaTabela = true;
                    // TabelaTitulo.Text = "Sem Título";
                    // EditarTitulo.Text = "Sem Título";
                    TabelaEsconder.Style["visibility"] = "hidden";
                    PreencherHeader(TabelaOpcoesDD.Text, DadoDD.Text);

                }

                ChecarTabela();

            }
            catch (Exception e)
            {

                lblSucesso.Text = "";
                lblFalha.Text = e.ToString();
            }

        }

        public void ConfirmaOpcoes(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(fichaID)) NovaFichaID();

            try
            {

                using (SqlConnection con = new SqlConnection(sqlConexao))
                {
                    con.Open();
                    string query = "UPDATE SolidTables SET Titulo=@Titulo, Tipo=@Tipo, Dado=@Dado" +
                    " WHERE [SolidTablesUser]=@SolidTablesUser AND [SolidTablesID]=@SolidTablesID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Titulo", EditarTitulo.Text);
                    cmd.Parameters.AddWithValue("@Tipo", TabelaOpcoesDD.Text);
                    cmd.Parameters.AddWithValue("@Dado", DadoDD.Text);
                    cmd.Parameters.AddWithValue("@SolidTablesUser", usuarioID);
                    cmd.Parameters.AddWithValue("@SolidTablesID", fichaID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                TabelaTitulo.Text = EditarTitulo.Text;
                PreencherGridView();

                TabelaEsconder.Style["visibility"] = "visible";

                TabelaPrincipal.HeaderRow.Cells[4].Text = DadoDD.Text;

                PreencherHeader(TabelaOpcoesDD.Text, DadoDD.Text);

                if (novaTabela != true)
                    lblSucesso.Text = "Opções Alteradas";
                lblFalha.Text = "";

                ChecarTabela();

            }
            catch (Exception)
            {

                lblSucesso.Text = "";
                lblFalha.Text = "";
            }
        }

        public void PreencherHeader(string tipo, string dado)
        {
            switch (tipo)
            {
                case "Encontro Aleatório":
                    TabelaPrincipal.HeaderRow.Cells[0].Text = "Encontro Aleatório";
                    TabelaPrincipal.HeaderRow.Cells[1].Text = "ND";
                    TabelaPrincipal.HeaderRow.Cells[2].Text = "Experiência";
                    TabelaPrincipal.HeaderRow.Cells[4].Text = dado;
                    // ChecarTabela();
                    break;
                case "Tesouro":
                    TabelaPrincipal.HeaderRow.Cells[0].Text = "Tesouro";
                    TabelaPrincipal.HeaderRow.Cells[1].Text = "Tipo de Tesouro";
                    TabelaPrincipal.HeaderRow.Cells[2].Text = "Valor em Peças de Ouro";
                    TabelaPrincipal.HeaderRow.Cells[4].Text = dado;
                    break;
                case "Item Mágico":
                    TabelaPrincipal.HeaderRow.Cells[0].Text = "Item Mágico";
                    TabelaPrincipal.HeaderRow.Cells[1].Text = "Tipo (Incomum, Raro, Lendário)";
                    TabelaPrincipal.HeaderRow.Cells[2].Text = "Valor";
                    TabelaPrincipal.HeaderRow.Cells[4].Text = dado;
                    break;
            }
        }

        public void ChecarTabela()
        {
            int limite = 0, i = 0, cont = 0;

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(sqlConexao))
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Probabilidade, Dado FROM SolidTables WHERE [SolidTablesUser]='"
                    + usuarioID + "' AND [SolidTablesID]='" + fichaID + "'", con);
                da.Fill(dt);
                con.Close();
            }

            DataRow testeRow = dt.Rows[0];

            switch (testeRow[1].ToString())
            {
                case "1D4":
                    limite = 10;
                    break;
                case "1D6":
                    limite = 21;
                    break;
                case "1D8":
                    limite = 36;
                    break;
                case "1D10":
                    limite = 55;
                    break;
                case "1D12":
                    limite = 78;
                    break;
                case "1D20":
                    limite = 210;
                    break;
                case "2D10 (100%, 1D100)":
                    limite = 100;
                    break;
            }

            foreach (DataRow row in dt.Rows)
            {

                string charTemp = string.Empty;

                if (!String.IsNullOrEmpty(row[0].ToString()))
                {

                    string soma = row[0].ToString();

                    if (testeRow[1].ToString() == "2D10 (100%, 1D100)")
                    {
                        foreach (char num in soma)
                        {
                            if (char.IsDigit(num))
                            {
                                charTemp += Int32.Parse(num.ToString());
                            }
                            else
                            {
                                if (!char.IsDigit(num) && !string.IsNullOrEmpty(charTemp))
                                {
                                    cont += Int32.Parse(charTemp);
                                    charTemp = string.Empty;
                                }
                            }
                        }
                    }
                    else
                    {

                        cont += soma.ToCharArray().Where(n => char.IsDigit(n))
                            .ToArray().Select(n => Int32.Parse(n.ToString())).Sum();

                    }

                }

                if (cont > limite)
                {
                    TabelaPrincipal.Rows[i].Cells[0].ForeColor = System.Drawing.Color.Red;
                    TabelaPrincipal.Rows[i].Cells[1].ForeColor = System.Drawing.Color.Red;
                    TabelaPrincipal.Rows[i].Cells[2].ForeColor = System.Drawing.Color.Red;
                    TabelaPrincipal.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                    TabelaPrincipal.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;

                    TabelaPrincipal.Rows[i].Cells[0].CssClass = "danger";
                    TabelaPrincipal.Rows[i].Cells[1].CssClass = "danger";
                    TabelaPrincipal.Rows[i].Cells[2].CssClass = "danger";
                    TabelaPrincipal.Rows[i].Cells[3].CssClass = "danger";
                    TabelaPrincipal.Rows[i].Cells[4].CssClass = "danger";

                    lblFalha.Text = "Limite Excedido: Altere o Dado ou Diminua o Número de Linhas<br /><br />";
                }
                else
                {
                    lblFalha.Text = "";
                }
                i++;
            }

            // lblFalha.Text = cont.ToString() + " ???";

        }

        public void ExportarDOC(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename = " + TabelaTitulo.Text.Replace(" ", string.Empty) + ".doc");
            Response.ContentType = "application/word";
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            TabelaPrincipal.HeaderRow.Style.Add("background-color", "#FFFFFF");
            TabelaPrincipal.FooterRow.Visible = false;

            foreach (TableCell tableCell in TabelaPrincipal.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#333333";
                tableCell.Style["color"] = "#FFFFFF";
            }

            foreach (GridViewRow gridViewRow in TabelaPrincipal.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                gridViewRow.Cells[5].Visible = false;

                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#f2f2f2";
                }
            }

            TabelaPrincipal.HeaderRow.Cells[5].Visible = false;

            TabelaTitulo.RenderControl(htmlTextWriter);
            TabelaPrincipal.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();
        }

        [Obsolete]
        public void ExportarPDF(object sender, EventArgs e)
        {

            Response.ClearContent();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename = " + TabelaTitulo.Text.Replace(" ", string.Empty) + ".doc");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter strWrite = new StringWriter();
            HtmlTextWriter htmWrite = new HtmlTextWriter(strWrite);
            HtmlForm frm = new HtmlForm();

            TabelaPrincipal.HeaderRow.Cells[5].Visible = false;
            TabelaPrincipal.HeaderRow.Style.Add("text-align", "center");

            foreach (GridViewRow gridViewRow in TabelaPrincipal.Rows)
            {

                gridViewRow.Cells[5].Visible = false;

            }

            frm.Style.Add("text-align", "center");
            TabelaPrincipal.Parent.Controls.Add(frm);
            TabelaTitulo.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(TabelaTitulo);
            frm.Controls.Add(TabelaPrincipal);
            frm.RenderControl(htmWrite);

            StringReader sr = new StringReader(strWrite.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.Flush();
            Response.End();

            //StyleSheet styles = new StyleSheet();
            //styles.LoadTagStyle("TabelaPDF", "height", "30px");
            //styles.LoadStyle("TabelaPDF", "font-weight", "bold");

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition",
            // "attachment;filename=GridViewExport.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //TabelaPrincipal.AllowPaging = false;

            //TabelaPrincipal.RenderBeginTag(hw);
            //TabelaPrincipal.HeaderRow.RenderControl(hw);
            //foreach (GridViewRow row in TabelaPrincipal.Rows)
            //{
            //    row.RenderControl(hw);
            //}
            //TabelaPrincipal.FooterRow.RenderControl(hw);
            //TabelaPrincipal.RenderEndTag(hw);

            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //htmlparser.SetStyleSheet(styles);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();

        }
        public void ExportarCSV(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition",
                "attachment; filename = " + TabelaTitulo.Text.Replace(" ", string.Empty) + ".xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());

            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            TabelaPrincipal.HeaderRow.Style.Add("background-color", "#FFFFFF");
            TabelaPrincipal.FooterRow.Visible = false;

            foreach (TableCell tableCell in TabelaPrincipal.HeaderRow.Cells)
            {
                tableCell.Style["background-color"] = "#333333";
                tableCell.Style["color"] = "#FFFFFF";
            }

            foreach (GridViewRow gridViewRow in TabelaPrincipal.Rows)
            {
                gridViewRow.BackColor = System.Drawing.Color.White;
                gridViewRow.Cells[5].Visible = false;

                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                {
                    gridViewRowTableCell.Style["background-color"] = "#f2f2f2";
                }
            }

            TabelaPrincipal.HeaderRow.Cells[5].Visible = false;

            TabelaTitulo.RenderControl(htmlTextWriter);
            TabelaPrincipal.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

    }
}