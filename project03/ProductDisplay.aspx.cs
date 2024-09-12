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
    public partial class ProductDisplay : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string a = "select Product_Image,Product_Name,Product_Price,Product_Description from producttable where Product_Id="+ Session["Product_Id"] + "";
                SqlDataReader dr = obj.Fn_ExeReader(a);
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                while(dr.Read())
                {
                    Image1.ImageUrl = dr["Product_Image"].ToString();
                    Label1.Text = dr["Product_Name"].ToString();
                    Label2.Text = dr["Product_Price"].ToString();
                    Label3.Text = dr["Product_Description"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string c = "insert into carttab values("+2+"," + 2 + ","+ Session["Product_Id"] + ","+TextBox1.Text+", "+Label2.Text+" * "+TextBox1.Text+")";
            int i = obj.Fn_ExeNonQuery(c);
            Response.Redirect("ViewCart.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }
    }
}