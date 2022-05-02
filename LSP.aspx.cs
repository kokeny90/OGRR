using AjaxControlToolkit;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transporters : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {

            if (!IsPostBack)
            {

               // SqlDataSourceOrszag.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                SqlDataSourceLSP.ConnectionString = Functions.ConnectionString(User.Identity.Name);
                Session["filter"] = "";
                Session["LabelID"] = "abc";
                Session["login"] = User.Identity.Name.ToString();
                Session["ContactID"] = "0";
                frissit();

            }
            else
            {
                if (Session["filter"] != null)
                {
                    SqlDataSourceLSP.FilterExpression = Session["filter"].ToString();
                }
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void frissit()
    {
        SqlDataSourceLSP.ConnectionString = Functions.ConnectionString(User.Identity.Name);
        SqlDataSourceLSP.SelectCommand = "SELECT * FROM [VLSP] ORDER BY Name";
        GridViewLSP.DataSource = SqlDataSourceLSP;
        GridViewLSP.DataBind();
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridViewSGHUORDER_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridViewSGHUORDER_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewLSP.EditIndex = e.NewEditIndex;
        Label LabelGrid = (GridViewLSP.Rows[GridViewLSP.EditIndex].FindControl("LabelHonnan") as Label);
        Session["LabelHonnan"] = LabelGrid.Text.ToString();
        LabelGrid = (GridViewLSP.Rows[GridViewLSP.EditIndex].FindControl("LabelHova") as Label);
        Session["LabelHova"] = LabelGrid.Text.ToString();

        frissit();
    }
    protected void GridViewSGHUORDER_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewLSP.EditIndex = -1;
        frissit();
    }

    protected void GridViewSGHUORDER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void GridViewSGHUORDER_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridViewSGHUORDER_DataBinding(object sender, EventArgs e)
    {

    }

    protected void GridViewSGHUORDER_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LabelID = (e.Row.FindControl("LabelID") as Label);
            if (Session["LabelID"].ToString() == LabelID.Text.ToString())
            {
                LinkButton LinkButton1 = (e.Row.FindControl("lnkEdit") as LinkButton);
                LinkButton1.Visible = false;
                LinkButton1 = (e.Row.FindControl("LinkButtonDelete") as LinkButton);
                LinkButton1.Visible = false;
                LabelID = (e.Row.FindControl("LabelID") as Label);
                LabelID.Text = string.Empty;
                LabelID = (e.Row.FindControl("LabelOrderName") as Label);
                LabelID.Text = "";
                LabelID = (e.Row.FindControl("LabelEmail") as Label);
                LabelID.Text = "";
                LabelID = (e.Row.FindControl("LabelPostCode") as Label);
                LabelID.Text = "";
                LabelID = (e.Row.FindControl("LabelCity") as Label);
                LabelID.Text = "";
                LabelID = (e.Row.FindControl("Labelorszagkod") as Label);
                LabelID.Text = "";
                LabelID = (e.Row.FindControl("LabelFax") as Label);
                LabelID.Text = "";
            }
            if (!string.IsNullOrEmpty(LabelID.Text))
            {
                Session["LabelID"] = LabelID.Text;
            }

        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string query;
        SqlDataReader dataReader;
        int LSPID = 0;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {

            query = " UPDATE [dbo].[LSP] SET Name=@Name, Email=@Email, CC=@CC, PostCode=@PostCode, City=@City, Adress=@Adress, Country=@Country, Fax=@Fax where ID=@ID ";
            using (SqlCommand command = new SqlCommand(query, con))
            {

                command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text.ToString().Trim();
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text.ToString().Trim();
                command.Parameters.Add("@CC", SqlDbType.VarChar).Value = TextBoxCC.Text.ToString().Trim();
                if (string.IsNullOrEmpty(txtPostCode.Text.ToString().Trim()))
                {
                    command.Parameters.Add("@PostCode", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@PostCode", SqlDbType.Int).Value = int.Parse(txtPostCode.Text.ToString().Trim());
                }
                if (int.Parse(Feltoltes("SELECT ID FROM dbo.City WHERE (City = @bemenoadat);", "insert into  dbo.City(City) values(@bemenoadat);", txtCity.Text.ToString().Trim())) == 0)
                {
                    command.Parameters.Add("@City", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@City", SqlDbType.Int).Value = int.Parse(Feltoltes("SELECT ID FROM dbo.City WHERE (City = @bemenoadat);", "insert into  dbo.City(City) values(@bemenoadat);", txtCity.Text.ToString().Trim()));
                }
                command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = txtAdress.ToString().Trim();
                if (int.Parse(DropDownListCountry.SelectedIndex.ToString()) == 0)
                {
                    command.Parameters.Add("@Country", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Country", SqlDbType.Int).Value = int.Parse(DropDownListCountry.SelectedIndex.ToString());
                }

                if (string.IsNullOrEmpty(txtFax.Text.ToString().Trim()))
                {
                    command.Parameters.Add("@Fax", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    command.Parameters.Add("@Fax", SqlDbType.Int).Value = int.Parse(txtFax.Text.ToString().Trim());
                }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            if (GridViewContact.Rows.Count != 1)
            {
                if (btnUpdate.Text == "Insert Data")
                {
                    query = "SELECT MAX(ID) AS ID FROM dbo.LSP";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        dataReader = command.ExecuteReader();
                    }
                    if (dataReader.Read())
                    {
                        if (dataReader[0] != DBNull.Value)
                        {
                            LSPID = int.Parse(dataReader[0].ToString());
                        }
                    }
                    con.Close();
                }
                else
                {
                    LSPID = int.Parse(lblstor_id.Text.ToString().Trim());
                }
                query = "INSERT INTO [dbo].[LSPKapcsolo] (LSPID,ContactID) VALUES (@LSPID,@ContactID)";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@LSPID", SqlDbType.VarChar).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                    command.Parameters.Add("@ContactID", SqlDbType.Int).Value = LSPID;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
        frissit();
        this.ModalPopupExtender1.Hide();
    }
    public string Feltoltes(string query, string insert, string be)
    {
        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = be;
                con.Open();
                dataReader = command.ExecuteReader();
            }
            if (dataReader.Read())
            {
                if (dataReader[0] != DBNull.Value)
                {
                    return dataReader[0].ToString();
                }
            }
            else if (insert == "")
            {
                return "0";
            }
        }

        if (string.IsNullOrEmpty(be))
        {
            return "0";
        }

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SGHU_LOG-TConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@bemenoadat", SqlDbType.VarChar).Value = be;
                con.Open();
                dataReader = command.ExecuteReader();
            }
            if (dataReader.Read())
            {
                return dataReader[0].ToString();
            }
        }
        return null;
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {

        SqlDataSourceOrszag.ConnectionString = Functions.ConnectionString(User.Identity.Name);
    
        string query;
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        Session["ContactID"] = GridViewLSP.DataKeys[gRow.RowIndex].Value.ToString();
        frissitGridViewContact();

        SqlDataReader dataReader;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "SELECT *  FROM [VLSP] where ID =@ID;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                Label GRLabel = (gRow.FindControl("LabelID") as Label);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(GRLabel.Text.ToString().Trim());
                con.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    lblstor_id.Text = GridViewLSP.DataKeys[gRow.RowIndex].Value.ToString();
                    txtName.Text = dataReader[1].ToString();
                    txtEmail.Text = dataReader[2].ToString();
                    txtPostCode.Text = dataReader[3].ToString();
                    txtCity.Text = dataReader[6].ToString();
                    DropDownListCountry.DataBind();
                    DropDownListCountry.ClearSelection();
                    string orszqag = dataReader[7].ToString();
                    DropDownListCountry.SelectedIndex = DropDownListCountry.Items.IndexOf(DropDownListCountry.Items.FindByText(dataReader[7].ToString()));
                    txtFax.Text = dataReader[5].ToString();
                }

                con.Close();
            }
        }
        if (GridViewContact.Rows.Count != 1)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("ContactName");
            dt.Columns.Add("ContactPhone");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            GridViewContact.DataSource = dt;
            GridViewContact.DataBind();
            GridViewContact.Rows[0].Visible = false;
        }
        btnUpdate.Text = "Update Data";
        this.ModalPopupExtender1.Show();
    }

    protected void ImageButtonAdd_Click1(object sender, ImageClickEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID");
        dt.Columns.Add("ContactName");
        dt.Columns.Add("ContactPhone");
        DataRow dr = dt.NewRow();
        dt.Rows.Add(dr);
        GridViewContact.DataSource = dt;
        GridViewContact.DataBind();
        GridViewContact.Rows[0].Visible = false;
        btnUpdate.Text = "Insert Data";
        idsor.Visible = false;
        txtName.Text = "";
        txtEmail.Text = "";
        TextBoxCC.Text = ""; ;
        txtPostCode.Text = "";
        txtFax.Text = "";
        txtCity.Text = "";
        DropDownListCountry.DataBind();
        GridViewContact.DataBind();
        this.ModalPopupExtender1.Show();
        GridViewContact.Visible = false;

    }

    protected void ImageButtonAdd_Click2(object sender, ImageClickEventArgs e)
    {

    }

    protected void ImageButtonAdd_Click3(object sender, ImageClickEventArgs e)
    {
        TextBox TextBox = (GridViewContact.FooterRow.FindControl("TextBoxContactName") as TextBox);
        TextBox.Visible = true;
        TextBox = (GridViewContact.FooterRow.FindControl("TextBoxContactPhone") as TextBox);
        TextBox.Visible = true;
        Label LabelPlus = (GridViewContact.FooterRow.FindControl("LabelPlus") as Label);
        LabelPlus.Visible = true;
        ImageButton ImageButtonCancel = (GridViewContact.FooterRow.FindControl("ImageButtonCancel") as ImageButton);
        ImageButtonCancel.Visible = true;
        ImageButton ImageButtonOK = (GridViewContact.FooterRow.FindControl("ImageButtonOK") as ImageButton);
        ImageButtonOK.Visible = true;
        ImageButton ImageButtonAdd = (GridViewContact.FooterRow.FindControl("ImageButtonAdd") as ImageButton);
        ImageButtonAdd.Visible = false;
        btnUpdate.Visible = false;

        //  frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void TextBoxID_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxID") as TextBox);
        SQLFilterExpr("[ID]", "=", TextBoxGrid.Text.ToString());
        frissit();
    }
    protected void SQLFilterExpr(string mezo, string op, string ertek)
    {
        if (!String.IsNullOrEmpty(ertek) && ertek != "%%")
        {
            if (String.IsNullOrEmpty(SqlDataSourceLSP.FilterExpression.ToString()))
            {
                SqlDataSourceLSP.FilterExpression = mezo + " " + op + " '" + ertek + "'";
            }
            else
            {
                if (Session["filter"].ToString().Contains(mezo) && !String.IsNullOrEmpty(ertek))
                {
                    if (ertek.Contains('%'))
                    {
                        string ciksz = String.Format(@"\b{0}\b", Functions.getBetween(Session["filter"].ToString(), mezo + " " + op + " '%", "%'"));
                        Session["filter"] = Regex.Replace(Session["filter"].ToString(), ciksz, ertek, RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        string ciksz = String.Format(@"\b{0}\b", Functions.getBetween(Session["filter"].ToString(), mezo + " " + op + " '", "'"));
                        Session["filter"] = Regex.Replace(Session["filter"].ToString(), ciksz, ertek, RegexOptions.IgnoreCase);
                    }
                    SqlDataSourceLSP.FilterExpression = Session["filter"].ToString();
                }
                else
                {
                    SqlDataSourceLSP.FilterExpression += " AND " + mezo + " " + op + " '" + ertek + "'";
                }
            }
            Session["filter"] = SqlDataSourceLSP.FilterExpression.ToString();
        }
        else
        {
            Session["filter"] = "";
            SqlDataSourceLSP.FilterExpression = "";
        }
        GridViewLSP.DataBind();
    }

    protected void ImageButtonUpd_Click(object sender, ImageClickEventArgs e)
    {
        frissit();
        //TextBoxFilterCikkszam.Text = "";
        //SqlDataSource1.FilterExpression = "";
        Session["filter"] = "";
        //GridViewMennyiseg.DataBind();
        //DropDownListFilterCikkszam.SelectedIndex = 0;
    }

    protected void TextBoxName_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxName") as TextBox);
        SQLFilterExpr("[Name]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%");
        frissit();
    }

    protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxEmail") as TextBox);
        SQLFilterExpr("[Email]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%");
        frissit();
    }

    protected void TextBoxPostCode_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxPostCode") as TextBox);
        SQLFilterExpr("[PostCode]", "=", TextBoxGrid.Text.ToString());
        frissit();
    }

    protected void TextBoxCity_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxCity") as TextBox);
        SQLFilterExpr("[City]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%");
        frissit();
    }

    protected void TextBoxFax_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxFax") as TextBox);
        SQLFilterExpr("[Fax]", "=", TextBoxGrid.Text.ToString());
        frissit();
    }

    protected void DropDownListorszagkod_TextChanged(object sender, EventArgs e)
    {
        DropDownList DropDownListGrid = (GridViewLSP.HeaderRow.FindControl("DropDownListorszagkod") as DropDownList);
        SQLFilterExpr("[orszagkod]", "=", DropDownListGrid.SelectedItem.ToString());
        frissit();
    }

    protected void TextBoxContactName_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxContactName") as TextBox);
        SQLFilterExpr("[ContactName]", "LIKE", "%" + TextBoxGrid.Text.ToString() + "%");
        frissit();
    }

    protected void TextBoxContactPhone_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBoxGrid = (GridViewLSP.HeaderRow.FindControl("TextBoxContactPhone") as TextBox);
        SQLFilterExpr("[ContactPhone]", "=", TextBoxGrid.Text.ToString());
        frissit();
    }

    protected void ImageButtonOK_Click(object sender, ImageClickEventArgs e)
    {
        string query;
        SqlDataReader rdr = null;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "INSERT INTO [dbo].[Contact] (Name,Phone) VALUES (@Name,@Phone)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                TextBox TextBoxContactName = (GridViewContact.FooterRow.FindControl("TextBoxContactName") as TextBox);
                TextBox TextBoxContactPhone = (GridViewContact.FooterRow.FindControl("TextBoxContactPhone") as TextBox);
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = TextBoxContactName.Text.ToString().Trim();
                command.Parameters.Add("@Phone", SqlDbType.Decimal).Value = decimal.Parse(TextBoxContactPhone.Text.ToString().Trim());
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

            int LSPID = 0;
            query = "SELECT TOP 1 * FROM [dbo].[Contact] ORDER BY ID DESC";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    LSPID = int.Parse(rdr[0].ToString());
                }
                con.Close();
            }

            query = "INSERT INTO [dbo].[LSPKapcsolo] (LSPID,ContactID) VALUES (@LSPID,@ContactID)";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@LSPID", SqlDbType.VarChar).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                command.Parameters.Add("@ContactID", SqlDbType.Int).Value = int.Parse(LSPID.ToString());
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

            Session["ContactID"] = lblstor_id.Text.ToString().Trim();

        }

        btnUpdate.Visible = true;
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void GridViewContact_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string query;
        HiddenField field = (HiddenField)GridViewContact.Rows[e.RowIndex].FindControl("HiddenFieldID");

        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            int ContactID = int.Parse(field.Value.ToString());
            query = " DELETE FROM[dbo].[LSPKapcsolo]    WHERE LSPID=@LSPID and ContactID=@ContactID";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@LSPID", SqlDbType.VarChar).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                command.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            query = " DELETE FROM[dbo].[LSPKapcsolo]    WHERE LSPID=@LSPID and ContactID=@ContactID";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@LSPID", SqlDbType.VarChar).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                command.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void GridViewContact_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewContact.EditIndex = e.NewEditIndex;
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }
    protected void frissitGridViewContact()
    {
        SqlDataSourceContact.ConnectionString = Functions.ConnectionString(User.Identity.Name);
        SqlDataSourceContact.SelectCommand = "SELECT dbo.Contact.ID, dbo.Contact.Name AS ContactName, dbo.Contact.Phone AS ContactPhone FROM dbo.LSP INNER JOIN dbo.LSPKapcsolo ON dbo.LSP.ID = dbo.LSPKapcsolo.LSPID INNER JOIN dbo.Contact ON dbo.LSPKapcsolo.ContactID = dbo.Contact.ID LEFT OUTER JOIN dbo.country ON dbo.LSP.Country = dbo.country.id LEFT OUTER JOIN dbo.City ON dbo.LSP.City = dbo.City.ID WHERE (dbo.LSP.ID =" + Session["ContactID"].ToString() + ")";
        GridViewContact.DataSource = SqlDataSourceContact;
        GridViewContact.DataBind();

    }

    protected void GridViewContact_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HiddenField field = (HiddenField)GridViewContact.Rows[e.RowIndex].FindControl("HiddenFieldID");
        TextBox LabelContactName = (GridViewContact.Rows[e.RowIndex].FindControl("TextBoxContactName") as TextBox);
        TextBox LabelContactPhone = (GridViewContact.Rows[e.RowIndex].FindControl("TextBoxContactPhone") as TextBox);

        string query = " UPDATE [dbo].[Contact] SET Name=@Name, Phone=@Phone where ID=@ID "; ;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(field.Value.ToString().Trim());
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = LabelContactName.Text.ToString().Trim();
                command.Parameters.Add("@Phone", SqlDbType.Decimal).Value = decimal.Parse(LabelContactPhone.Text.ToString().Trim());
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        GridViewContact.EditIndex = -1;
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void GridViewContact_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void GridViewContact_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewContact.EditIndex = -1;
        frissitGridViewContact();
        this.ModalPopupExtender1.Show();
    }

    protected void GridViewLSP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string query;
        using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
        {
            query = "DELETE FROM [dbo].[LSP]  WHERE ID=@ID;";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                Label GRLabel = (GridViewLSP.Rows[e.RowIndex].FindControl("LabelID") as Label);
                command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(GRLabel.Text.ToString().Trim());
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        GridViewLSP.EditIndex = -1;
        frissit();
    }

    protected void TextBoxContactPhone_TextChanged1(object sender, EventArgs e)
    {
        TextBox textBox = (TextBox)sender;

        String AllowedChars = @"(\d+)";
        if (!(Regex.IsMatch(textBox.Text, AllowedChars)))
        {
            LabelHiba.Text = "Only Numbers allowed";
            LabelHiba.Visible = true;
            textBox.BackColor = Color.FromName("Yellow");
        }

        else
        {
            LabelHiba.Text = "";
            LabelHiba.Visible = false;
            textBox.BackColor = Color.FromName("White");
        }
        this.ModalPopupExtender1.Show();
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        string query = "";
        TextBox textBox = (TextBox)sender;
        SqlDataReader dataReader;
        if (string.IsNullOrEmpty(textBox.Text.ToString()))
        {
            LabelHiba.Text = "Name cannot be empty!";
            LabelHiba.Visible = true;
            textBox.BackColor = Color.FromName("Yellow");
        }
        else
        {
            LabelHiba.Text = "";
            LabelHiba.Visible = false;
            textBox.BackColor = Color.FromName("White");
            GridViewContact.Visible = true;
            if (btnUpdate.Text == "Insert Data" && GridViewContact.Visible == true)
            {
                query = "INSERT INTO [dbo].[LSP] (Name,Email,CC,PostCode,City,Adress,Country,Fax) VALUES (@Name,@Email,@CC,@PostCode,@City,@Adress,@Country,@Fax)";
                using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
                {

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        if (btnUpdate.Text != "Insert Data")
                        {
                            command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(lblstor_id.Text.ToString().Trim());
                        }
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text.ToString().Trim();
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text.ToString().Trim();
                        command.Parameters.Add("@CC", SqlDbType.VarChar).Value = TextBoxCC.Text.ToString().Trim();
                        if (string.IsNullOrEmpty(txtPostCode.Text.ToString().Trim()))
                        {
                            command.Parameters.Add("@PostCode", SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@PostCode", SqlDbType.Int).Value = int.Parse(txtPostCode.Text.ToString().Trim());
                        }
                        if (int.Parse(Feltoltes("SELECT ID FROM dbo.City WHERE (City = @bemenoadat);", "insert into  dbo.City(City) values(@bemenoadat);", txtCity.Text.ToString().Trim())) == 0)
                        {
                            command.Parameters.Add("@City", SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@City", SqlDbType.Int).Value = int.Parse(Feltoltes("SELECT ID FROM dbo.City WHERE (City = @bemenoadat);", "insert into  dbo.City(City) values(@bemenoadat);", txtCity.Text.ToString().Trim()));
                        }
                        command.Parameters.Add("@Adress", SqlDbType.VarChar).Value = txtAdress.ToString().Trim();
                        if (int.Parse(DropDownListCountry.SelectedIndex.ToString()) == 0)
                        {
                            command.Parameters.Add("@Country", SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Country", SqlDbType.Int).Value = int.Parse(DropDownListCountry.SelectedIndex.ToString());
                        }

                        if (string.IsNullOrEmpty(txtFax.Text.ToString().Trim()))
                        {
                            command.Parameters.Add("@Fax", SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Fax", SqlDbType.Int).Value = int.Parse(txtFax.Text.ToString().Trim());
                        }
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    query = "SELECT MAX(ID) AS ID FROM dbo.LSP";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        con.Open();
                        dataReader = command.ExecuteReader();
                    }
                    if (dataReader.Read())
                    {
                        if (dataReader[0] != DBNull.Value)
                        {
                            idsor.Visible = true;
                            lblstor_id.Text = dataReader[0].ToString();
                            GridViewContact.Visible = true;
                        }
                    }
                    con.Close();
                }
            }

        }
        this.ModalPopupExtender1.Show();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (btnUpdate.Text == "Insert Data" && (!string.IsNullOrEmpty(lblstor_id.Text.ToString())))
        {
            string query;
            using (SqlConnection con = new SqlConnection(Functions.ConnectionString(User.Identity.Name)))
            {
                query = "DELETE FROM [dbo].[LSP]  WHERE ID=@ID;";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(lblstor_id.Text);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridViewLSP.EditIndex = -1;
            this.ModalPopupExtender1.Hide();
        }
        frissit();

    }

    protected void ModalPopupExtender1_ResolveControlID(object sender, ResolveControlEventArgs e)
    {

    }

    protected void ModalPopupExtender1_Unload(object sender, EventArgs e)
    {

    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {

        TextBox textBox = (TextBox)sender;
        String AllowedChars = @"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*$";
        if (!(Regex.IsMatch(textBox.Text.Trim(), AllowedChars)))
        {
            LabelHiba.Text = "E -mail address is not in the correct format!";
            LabelHiba.Visible = true;
            textBox.BackColor = Color.FromName("Yellow");
        }
        else
        {
            LabelHiba.Text = "";
            LabelHiba.Visible = false;
            textBox.BackColor = Color.FromName("White");
            GridViewContact.Visible = true;
        }
        this.ModalPopupExtender1.Show();
    }

    protected void ImageButtonExcel_Click(object sender, ImageClickEventArgs e)
    {
        GridView gr = GridViewLSP;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=HatarMennyiseg.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gr.AllowPaging = false;
        frissit();
        gr.Columns[0].Visible = false;
        TextBox GridTextbox = (TextBox)gr.HeaderRow.FindControl("TextBoxName");
        GridTextbox.Visible = false;

        // gr.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}