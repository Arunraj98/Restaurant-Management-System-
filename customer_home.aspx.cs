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

public partial class customer_product_bouquet : System.Web.UI.Page
{

    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;



    public int amt, fam;

    public string fname, add, zone, phone, place;
    protected void Page_Load(object sender, EventArgs e)
    {




        MySqlDataReader dr2;


        MySqlConnection con2 = new MySqlConnection(ConString);
        con2.Open();
        MySqlCommand cmd2 = new MySqlCommand("select name,phoneno,address,place from customerregisration where emailid='" + Session["user"].ToString() + "'", con2);

        dr2 = cmd2.ExecuteReader();
        if (dr2.Read())
        {
            fname = dr2[0].ToString();
            add = dr2[2].ToString();
            phone = dr2[1].ToString();
            place = dr2[3].ToString();
          


        }











        Productbooking();

        if (!IsPostBack)
        {




            for (int i = 1; i <= 5; i++)
            {

                DropDownList2.Items.Add(i.ToString());
            }


            MySqlConnection con = new MySqlConnection(ConString);
            MySqlCommand cmd = new MySqlCommand("select subcat from subcat where cat='" + Request.QueryString["wid"].ToString() + "'", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "subcat";
            DropDownList1.DataValueField = "subcat";
            DropDownList1.DataBind();


        }






    }





    public void Productbooking()
    {


        string query = "select pid,photoname,pname,price,stock,quantity from product where ptype='" + Request.QueryString["wid"].ToString() + "'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();








    }




    protected void repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (DropDownList2.SelectedItem.Text == "Select quantity")
        {

            Response.Write("<script>alert('Please choose quantity ')</script>");
        }
        else
        {

            string en = e.CommandName;

            if (en == "Cart")
            {
                int rowid = (e.Item.ItemIndex);


                HiddenField h = (HiddenField)repeater2.Items[rowid].FindControl("HiddenField1");



                MySqlDataReader dr2;


                MySqlConnection con2 = new MySqlConnection(ConString);
                con2.Open();
                MySqlCommand cmd2 = new MySqlCommand("select pid,photoname,pname,price,stock,quantity from product where pid='" + h.Value + "'", con2);

                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {


                    string ptname = dr2[1].ToString();
                    string pn = dr2[2].ToString() + "( " + DropDownList1.SelectedItem.Text + ")";




                    amt = Convert.ToInt16(dr2[3].ToString());
                    int am = Convert.ToInt16(dr2[3].ToString());
                    fam = am * Convert.ToInt16(DropDownList2.SelectedItem.Text);



                    Random r = new Random();
                    string otp = r.Next().ToString().Substring(0, 4);



                    string query = "insert into sales(name,email,address,phone,productname,photoname,status,amount,mode,date,pcode,buystatus,quantity,nos,pid,type) values('" + fname + "','" + Session["user"].ToString() + "','" + add + "','" + phone + "','" + pn + "','" + ptname + "','Not paid','" + fam + "','Not choosed','Not assigned','" + otp + "','Cart','" + DropDownList2.SelectedItem.Text + "','" + dr2[5].ToString() + "','" + h.Value + "','Normal')";

                    using (MySqlConnection con = new MySqlConnection(ConString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {


                            cmd.Connection = con;
                            con.Open();
                            int k = cmd.ExecuteNonQuery();


                            if (k > 0)
                            {


                                string query2 = "UPDATE product SET stock=@stock WHERE pid=@did";

                                using (MySqlConnection con1 = new MySqlConnection(ConString))
                                {
                                    using (MySqlCommand cmd1 = new MySqlCommand(query2))
                                    {


                                        cmd1.Parameters.AddWithValue("@did", Convert.ToInt16(h.Value));
                                        cmd1.Parameters.AddWithValue("@stock", Convert.ToInt16(dr2[4].ToString()) - Convert.ToInt16(DropDownList2.SelectedItem.Text));
                                        // cmd.Parameters.AddWithValue("@amount", amount);
                                        cmd1.Connection = con1;
                                        con1.Open();
                                        int i = cmd1.ExecuteNonQuery();
                                        if (i > 0)
                                        {


                                            Response.Write("<script>alert('success! added to cart ')</script>");

                                            con.Close();
                                            con1.Close(); con2.Close();


                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }




            if (en == "Buy")
            {
                int rowiid = (e.Item.ItemIndex);


                HiddenField h = (HiddenField)repeater2.Items[rowiid].FindControl("HiddenField1");
                //Response.Write("<script>alert('"+h.Value+"')</script>");

                //Label1.Text = h.Value;
                Session["pd"] = h.Value;
                Session["qt"] = DropDownList2.SelectedItem.Text;



                MySqlConnection con = new MySqlConnection(ConString);
                con.Open();


                MySqlCommand cmd = new MySqlCommand("select stock from product where pid=@p", con);

                cmd.Parameters.AddWithValue("@p", h.Value);

                int s = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                if (s == 0 || (s < Convert.ToInt16(DropDownList2.SelectedItem.Text)))
                {
                    Response.Write("<script>alert('Product out of stock')</script>");
                }
                else
                {
                    Response.Redirect("~/payment.aspx");
                }



            }



        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        string query = "select pid,photoname,pname,price,stock,quantity from product where pstype like '" + TextBox1.Text + "%' or pstype like '%" + TextBox1.Text + "' or ptype like '%" + TextBox1.Text + "' or quantity like '%" + TextBox1.Text + "' or pname like '%" + TextBox1.Text + "' or ptype like '" + TextBox1.Text + "%' or quantity like '" + TextBox1.Text + "%' or pname like '" + TextBox1.Text + "%'";

        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();






    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {


        string query = "select pid,photoname,pname,price,stock,quantity from product where  pstype ='" + DropDownList1.SelectedValue + "'";
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        repeater2.DataSource = ds;
        repeater2.DataBind();


    }
}