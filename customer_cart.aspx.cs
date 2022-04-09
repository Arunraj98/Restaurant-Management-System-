using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class customer_cart : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!this.IsPostBack)
        {
            this.BindGrid();









        }
        MySqlConnection con311 = new MySqlConnection(ConString);
        con311.Open();
        MySqlCommand cmd311 = new MySqlCommand("select count(*) from sales  where email='" + Session["user"].ToString() + "' and buystatus='Cart'", con311);


     int c = Convert.ToInt16(cmd311.ExecuteScalar().ToString());

     Session["nitems"] = c;
     if (c > 0)
     {

         TextBox1.Visible = true;
         Button1.Visible = true;



         MySqlConnection con31 = new MySqlConnection(ConString);
         con31.Open();


         MySqlCommand cmd31 = new MySqlCommand("select sum(amount) from sales  where email='" + Session["user"].ToString() + "' and buystatus='Cart'", con31);


         TextBox1.Text = Convert.ToInt16(cmd31.ExecuteScalar()).ToString();

         con31.Close();


     }


    }
    private void BindGrid()
    {
        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT paymentid,name,email,address,phone,productname,photoname,status,amount,mode,quantity,nos from sales where  email='" + Session["user"] + "' and buystatus='Cart'", con);
        con.Open();
        adapt.Fill(dt);
        con.Close();

        GridView2.DataSource = dt;
        GridView2.DataBind();





    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        this.BindGrid();

    }



    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView2.Rows[e.RowIndex];
        int did = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);

        // string name = (row.FindControl("txt_name") as TextBox).Text;
        // string address = (row.FindControl("txt_address")as TextBox).Text;
        //string place = (row.FindControl("txt_place") as TextBox).Text;
        // string phoneno = (row.FindControl("txt_phone") as TextBox).Text;

        MySqlConnection con2c = new MySqlConnection(ConString);
        con2c.Open();
        MySqlCommand cmd2c = new MySqlCommand("select type from sales where paymentid='" + did + "'", con2c);


        string ty = cmd2c.ExecuteScalar().ToString();

        con2c.Close();


        if (ty == "Normal")
        {






            MySqlConnection con2 = new MySqlConnection(ConString);
            con2.Open();
            MySqlCommand cmd2 = new MySqlCommand("select pid from sales where paymentid='" + did + "'", con2);


            int p = Convert.ToInt16(cmd2.ExecuteScalar().ToString());

            con2.Close();




            MySqlConnection con22 = new MySqlConnection(ConString);
            con22.Open();
            MySqlCommand cmd22 = new MySqlCommand("select quantity from sales where paymentid='" + did + "'", con22);


            int s = Convert.ToInt16(cmd22.ExecuteScalar().ToString());




            con22.Close();

            MySqlConnection con222 = new MySqlConnection(ConString);
            con222.Open();
            MySqlCommand cmd222 = new MySqlCommand("select stock from product where pid='" + p + "'", con222);



            int cs = Convert.ToInt16(cmd222.ExecuteScalar().ToString());

            con222.Close();

            int ns = cs + s;

            MySqlConnection con2222 = new MySqlConnection(ConString);
            con2222.Open();
            MySqlCommand cmd2222 = new MySqlCommand("update product set stock='" + ns + "' where pid='" + p + "'", con2222);

            cmd2222.ExecuteNonQuery();


            con2222.Close();








            string query = "DELETE FROM sales WHERE paymentid=@Bno";

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Bno", did);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


            GridView2.EditIndex = -1;
            this.BindGrid();
        }
        else {




            MySqlConnection con2 = new MySqlConnection(ConString);
            con2.Open();
            MySqlCommand cmd2 = new MySqlCommand("select pid from sales where paymentid='" + did + "'", con2);


            int p = Convert.ToInt16(cmd2.ExecuteScalar().ToString());

            con2.Close();




            MySqlConnection con22 = new MySqlConnection(ConString);
            con22.Open();
            MySqlCommand cmd22 = new MySqlCommand("select quantity from sales where paymentid='" + did + "'", con22);


            int s = Convert.ToInt16(cmd22.ExecuteScalar().ToString());




            con22.Close();

            MySqlConnection con222 = new MySqlConnection(ConString);
            con222.Open();
            MySqlCommand cmd222 = new MySqlCommand("select stock from productoffer where pid='" + p + "'", con222);



            int cs = Convert.ToInt16(cmd222.ExecuteScalar().ToString());

            con222.Close();

            int ns = cs + s;

            MySqlConnection con2222 = new MySqlConnection(ConString);
            con2222.Open();
            MySqlCommand cmd2222 = new MySqlCommand("update productoffer set stock='" + ns + "' where pid='" + p + "'", con2222);

            cmd2222.ExecuteNonQuery();


            con2222.Close();








            string query = "DELETE FROM sales WHERE paymentid=@Bno";

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Bno", did);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


            GridView2.EditIndex = -1;
            this.BindGrid();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        }




    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        this.BindGrid();
    }
    /* protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         int bno = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
         string query = "DELETE FROM patient_test WHERE booking_no=@Bno";

         using (MySqlConnection con = new MySqlConnection(ConString))
         {
             using (MySqlCommand cmd = new MySqlCommand(query))
             {
                 cmd.Parameters.AddWithValue("@Bno", bno);
                 cmd.Connection = con;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
             }
         }

         this.BindGrid();
     }
     * */
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["amt"] = TextBox1.Text;



        MySqlConnection con31 = new MySqlConnection(ConString);
        con31.Open();


        MySqlCommand cmd31 = new MySqlCommand("select count(*) from sales  where email='" + Session["user"].ToString() + "' and buystatus='Cart'", con31);


        Session["qt"] = Convert.ToInt16(cmd31.ExecuteScalar()).ToString();

        con31.Close();

        
        
      
        
        
        
        Response.Redirect("~/paymentc.aspx");




    }
}
