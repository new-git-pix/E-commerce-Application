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
    public partial class Invoice : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "insert into actab values("+2+", '"+TextBox1.Text+"','Savings',"+TextBox2.Text+")";
            int i = obj.Fn_ExeNonQuery(a);
            Response.Redirect("Payment.aspx");
        }
    }
}