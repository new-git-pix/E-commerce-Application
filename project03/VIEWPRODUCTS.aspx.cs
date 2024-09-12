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
    public partial class VIEWPRODUCTS : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = "select * from producttable where Cat_Id=" + Session["Cat_Id"] + "";
                DataSet ds = obj.Fn_ExeAdapter(a);
                DataList1.DataSource = ds;
                DataList1.DataBind();
                
            }
            
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            Session["Product_Id"] = getid;
            Response.Redirect("ProductDisplay.aspx");

        }

        
    }
}