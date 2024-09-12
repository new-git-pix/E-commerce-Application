using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project03
{
    public partial class Login : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string d = "select Count(Reg_Id) from logintab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
            string cid = obj.Fn_ExeScalar(d);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string f = "select Reg_Id from logintab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string regid = obj.Fn_ExeScalar(f);
                Session["userid"] = regid;
                string g = "select Log_Type from logintab where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                string logtype = obj.Fn_ExeScalar(g);
                Label3.Visible = true;
                if (logtype == "Admin")
                {
                    Label3.Text = "Admin";
                    Response.Redirect("AdminHome.aspx");
                }
                else if (logtype == "User")
                {
                    Label3.Text = "User";
                    Response.Redirect("UserHome.aspx");
                }
                else
                {
                    Response.Redirect("ProductDisplay.aspx");
                }
            }
        }
    }
}