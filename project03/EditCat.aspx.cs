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
    public partial class EditCat : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridBind_fn();
            }

        }
        public void GridBind_fn()
        {
            string a = "select * from categorytab";
            DataSet ds = obj.Fn_ExeAdapter(a);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;   
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = rw.Cells[3].Text;
            Label2.Text = rw.Cells[5].Text;           
            Label3.Text = rw.Cells[6].Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind_fn();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind_fn();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtname = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];            
            TextBox txtdscrptn = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            TextBox txtstat = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            string upd = "update categorytab set Cat_Name='" + txtname.Text + "',Cat_Description='" + txtdscrptn.Text + "',Cat_Status='" + txtstat.Text + "' where Cat_Id=" + getid + "";
            obj.Fn_ExeNonQuery(upd);
            GridView1.EditIndex = -1;
            GridBind_fn();
        }
    }
}