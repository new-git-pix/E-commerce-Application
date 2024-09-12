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
    public partial class AddCat : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "~/ephs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(a));
            string b = "insert into categorytab values('" + TextBox1.Text + "','" + a + "','" + TextBox2.Text + "','Available')";
            int i = obj.Fn_ExeNonQuery(b);
        }
    }
}