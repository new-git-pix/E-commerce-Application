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
    public partial class Payment : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            BALService.ServiceClient ob = new BALService.ServiceClient();
            string bal = ob.Balance_Amount(TextBox1.Text);           
            Label3.Text = bal;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string a = "select Total_Amount from billtable";
            string amt = obj.Fn_ExeScalar(a);
            int amt1 = Convert.ToInt32(amt);
            string b = "select Balance_Amount from actab";
            string blnc = obj.Fn_ExeScalar(b);
            int blnc1 = Convert.ToInt32(blnc);
            if(blnc1 > amt1)
            {
                string g = "update actab set Balance_Amount=" + 62915 + " where User_Reg_Id=" + 2 + "";
                int updt = obj.Fn_ExeNonQuery(g);
                string h = "update ordrtbl set Order_Status='Paid' where User_Reg_Id=" + 2 + "";
                int updte = obj.Fn_ExeNonQuery(h);
                string m = "update producttable set Stock="+21+" where Product_Id=" + 16 + "";
                int stup = obj.Fn_ExeNonQuery(m);
                string n = "update producttable set Stock="+123+" where Product_Id=" + 9 + "";
                int stupdt = obj.Fn_ExeNonQuery(n);
            }
            else
            {
                Label3.Text = "Insufficient Balance";
            }
        }

        
    }
}