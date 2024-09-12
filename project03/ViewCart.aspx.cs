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
    public partial class ViewCart : System.Web.UI.Page
    {
        concls obj = new concls();
        protected void Page_Load(object sender, EventArgs e)
        {                                             
            if (!IsPostBack)
            {
                GridBind_Fn();
            }

        }
        public void GridBind_Fn()
        {
            string a = "select * from carttab";
            DataSet ds = obj.Fn_ExeAdapter(a);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label1.Text = rw.Cells[3].Text;
            Label2.Text = rw.Cells[6].Text;
            Label3.Text = rw.Cells[7].Text;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridBind_Fn();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridBind_Fn();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtqnty = (TextBox)GridView1.Rows[i].Cells[6].Controls[0];
            TextBox txttot = (TextBox)GridView1.Rows[i].Cells[7].Controls[0];
            string upd = "update carttab set Quantity=" + txtqnty.Text + ",Subtotal=" + txtqnty.Text + " * "+txttot.Text+" where Cart_Id="+getid+" "; 
            obj.Fn_ExeNonQuery(upd);
            GridView1.EditIndex = -1;
            GridBind_Fn();

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            String del = "delete from carttab where Cart_Id=" + getid + "";
            int i = obj.Fn_ExeNonQuery(del);
            GridBind_Fn();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string b = "select max(Cart_Id) from carttab";
            string maxcartid = obj.Fn_ExeScalar(b);
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            for (int i = 1; i <= 2; i++)
            {
                if (i == 1)
                {
                    string c = "select * from carttab where Cart_Id=" + i + "";
                    SqlDataReader dr = obj.Fn_ExeReader(c);
                    string Cart_Id = TextBox1.Text;
                    Label4.Text = Cart_Id;
                    string User_Reg_Id = TextBox2.Text;
                    Label5.Text = User_Reg_Id;
                    string Product_Id = TextBox3.Text;
                    Label6.Text = Product_Id;
                    string Quantity = TextBox4.Text;
                    Label7.Text = Quantity;
                    string Subtotal = TextBox5.Text;
                    Label8.Text = Subtotal;
                    string Order_Date = TextBox6.Text;
                    Label9.Text = Order_Date;

                    while (dr.Read())
                    {
                        Label4.Text = dr["cart_Id"].ToString();
                        Label5.Text = dr["User_Reg_Id"].ToString();
                        Label6.Text = dr["Product_Id"].ToString();
                        Label7.Text = dr["Quantity"].ToString();
                        Label8.Text = dr["Subtotal"].ToString();
                        Label9.Text = dr["Order_Date"].ToString();

                    }
                }

                string d = "insert into ordrtbl values(" + 2 + "," + TextBox3.Text + "," + TextBox4.Text + "," + TextBox5.Text + ",'Ordered','" + TextBox6.Text + "')";
                int ins = obj.Fn_ExeNonQuery(d);

                string g = "delete from carttab where Cart_Id=" + i + "";
                int insrt = obj.Fn_ExeNonQuery(g);

            }

            string h = "select SUM(Subtotal) from ordrtbl where Product_Id=" + 16 + "";
            string sel = obj.Fn_ExeScalar(h);
            string k = "insert into billtable values("+2+"," + h + ",'" + TextBox6.Text + "')";
            int insrtt = obj.Fn_ExeNonQuery(k);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoice.aspx");
        }
    }
}