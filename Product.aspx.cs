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

public partial class Product : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            DropDownList1.AppendDataBoundItems = true;


            DropDownList2.AppendDataBoundItems = true;
        }




    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Insert(0,new ListItem("select",""));
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlCommand cmd = new MySqlCommand("select subcat from subcat where cat='" + DropDownList1.SelectedValue + "'", con);
        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "subcat";
        DropDownList2.DataValueField = "subcat";
        DropDownList2.DataBind();  
         



    }



    protected void Button1_Click1(object sender, EventArgs e)
    {



        MySqlConnection con = new MySqlConnection(ConString);
        con.Open();
        string pn = txtname.Text;

        string fn = fuphoto.FileName.ToString();
        string pa = "product/"+ fn;
        fuphoto.PostedFile.SaveAs(Server.MapPath("product/"+ fn));


        MySqlCommand cmd = new MySqlCommand("insert into product(pname,photoname,price,stock,ptype,quantity,pstype) values('" +txtname.Text + "','" + pa + "','" + txtprice.Text + "','" + txtstock.Text + "','" + DropDownList1.SelectedValue+ "','"+TextBox1.Text+"','"+DropDownList2.SelectedItem.Text+"')", con);


        int j = cmd.ExecuteNonQuery();

        if (j > 0)
        {
            txtname.Text = "";
            txtprice.Text = "";
            TextBox1.Text = "";
            txtstock.Text = "";
            Response.Write("<script>alert('product added successfully  ')</script>");

        }
        con.Close();
            
        

    }
}