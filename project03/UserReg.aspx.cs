﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project03
{
    public partial class UserReg : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = "select max(Reg_Id) from logintab";
            string regid = obj.Fn_ExeScalar(a);
            int Reg_Id = 0;
            if (regid == "")
            {
                Reg_Id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(regid);
                Reg_Id = newregid + 1;
            }
            string b = "insert into usertab values(" + Reg_Id + ",'" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "'," + TextBox4.Text + "," + TextBox5.Text + ",'" + TextBox6.Text + "')";
            int i = obj.Fn_ExeNonQuery(b);
            if (i == 1)
            {
                string c = "insert into logintab values(" + Reg_Id + ",'" + TextBox7.Text + "','" + TextBox8.Text + "','User')";
                int j = obj.Fn_ExeNonQuery(c);
            }
        }
    }
}