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
    public partial class AddProd : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "select Cat_Id,Cat_Name from categorytab";
            DataSet ds = obj.Fn_ExeAdapter(a);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Cat_Name";
            DropDownList1.DataValueField = "Cat_Id";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string b = "~/ephs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(b));
            string c = "insert into producttable values(" + 4 + ",'" + TextBox1.Text + "'," + TextBox2.Text + ",'" + b + "','" + TextBox3.Text + "','" + TextBox4.Text + "','Available')";
            int ins = obj.Fn_ExeNonQuery(c);
        }
    }
}