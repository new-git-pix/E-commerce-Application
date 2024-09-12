using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project03
{
    public partial class MailForm : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "select Admin_Email from admintab where Admin_Reg_Id=" + 1 + "";
            string sel = obj.Fn_ExeScalar(a);
            string b = "select User_Email from usertab where User_Reg_Id="+2+"";
            string sel1 = obj.Fn_ExeScalar(b);
            TextBox1.Text = sel;
            TextBox2.Text = sel1;
           

        }
    }
}