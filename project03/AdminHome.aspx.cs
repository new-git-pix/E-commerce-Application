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
    public partial class AdminHome : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridBind_Fn();
            }
        }
        public void GridBind_Fn()
        {
            string a = "select * from feedbacktab";
            DataSet ds = obj.Fn_ExeAdapter(a);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCat.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCat.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProd.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProd.aspx");
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            string b = "select Feedback from feedbacktab where User_Reg_Id="+getid+"";
            string sel = obj.Fn_ExeScalar(b);
            GridBind_Fn();
            Response.Redirect("MailForm.aspx");
        }
    }
}