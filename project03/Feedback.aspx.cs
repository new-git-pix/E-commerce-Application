using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace project03
{
    public partial class Feedback : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "insert into feedbacktab values("+1+","+2+",'"+TextBox1.Text+"',' ','Received')";
            int i = obj.Fn_ExeNonQuery(a);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {           
            Response.Redirect("AdminHome.aspx");                      
        }
    }
}