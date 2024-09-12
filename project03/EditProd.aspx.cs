using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace project03
{
    public partial class EditProd : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridBind_Fn();
            }

        }
        public void GridBind_Fn()
        {
            string a = "select * from producttable";
            DataSet ds = obj.Fn_ExeAdapter(a);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = rw.Cells[3].Text;
            Label2.Text = rw.Cells[4].Text;
            Label3.Text = rw.Cells[6].Text;
            Label4.Text = rw.Cells[7].Text;
            Label5.Text = rw.Cells[8].Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind_Fn();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind_Fn();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtprice = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtdscrptn = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            TextBox txtstock = (TextBox)GridView1.Rows[i].Cells[8].Controls[0];
            TextBox txtstat = (TextBox)GridView1.Rows[i].Cells[9].Controls[0];
            string upd = "update producttable set Product_Name='" + txtname.Text + "',Product_Price=" + txtprice.Text + ",Product_Description='" + txtdscrptn.Text + "',Stock='" + txtstock.Text + "',Status='" + txtstat.Text + "' where Product_Id=" + getid + "";
            obj.Fn_ExeNonQuery(upd);
            GridView1.EditIndex = -1;
            GridBind_Fn();
        }
    }
}