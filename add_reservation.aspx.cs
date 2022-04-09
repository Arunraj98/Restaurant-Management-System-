using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class add_reservation : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            DropDownList1.AppendDataBoundItems = true;



        }


        for (int i = 1; i <= 20; i++)
        {

            DropDownList1.Items.Add(i.ToString());
        }





    }
    protected void Button1_Click1(object sender, EventArgs e)
    {



        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();


        MySqlCommand cmd = new MySqlCommand("insert into reserve(amount,no_of_seats) values('" + TextBox2.Text + "','" + DropDownList1.SelectedValue + "')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {
            TextBox2.Text = "";
            Response.Write("<script>alert('Reservation details added successfully  ')</script>");

        }
        con.Close();



    }
}