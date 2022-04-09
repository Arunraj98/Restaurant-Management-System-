﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

using System.Net.Mail;
using System.Net;


public partial class packing_inner_bookings : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!this.IsPostBack)
        {
            this.BindGrid();
        }

      
    
    
    
    
    
    }
    private void BindGrid()
    {
        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(ConString);
        MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT paymentid,name,email,address,phone,productname,photoname,status,amount,mode,quantity,nos from sales where pcode='" + Session["pid"].ToString() + "' and buystatus='Buy' and status!='Cancelled'", con);
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

        MySqlConnection conn = new MySqlConnection(ConString);
        conn.Open();



        MySqlCommand cmdn = new MySqlCommand("select type from sales where paymentid='" + did + "'", conn);


        string stype = cmdn.ExecuteScalar().ToString();

        conn.Close();


        if (stype == "Normal")
        {




            MySqlConnection con31 = new MySqlConnection(ConString);
            con31.Open();



            MySqlCommand cmd31 = new MySqlCommand("select status from sales where paymentid='" + did + "'", con31);


            string st = cmd31.ExecuteScalar().ToString();

            con31.Close();










            //string status = (row.FindControl("DropStatus") as DropDownList).Text;
            // string amount = (row.FindControl("TextBox1") as TextBox).Text;


            if (st != "Not paid")
            {

                if (st == "Cancelled")
                {

                    Response.Write("<script>alert('Already cancelled')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Sorry!! You can't cancel order')</script>");
                }


            }
            else
            {



                MySqlConnection con311 = new MySqlConnection(ConString);
                con311.Open();



                MySqlCommand cmd311 = new MySqlCommand("select quantity from sales where paymentid='" + did + "'", con311);


                int q = Convert.ToInt16(cmd311.ExecuteScalar().ToString());

                con311.Close();


                MySqlConnection conf = new MySqlConnection(ConString);
                conf.Open();



                MySqlCommand cmdf = new MySqlCommand("select amount from sales where paymentid='" + did + "'", conf);


                int amts = Convert.ToInt16(cmdf.ExecuteScalar().ToString());

                conf.Close();





                MySqlConnection con3s = new MySqlConnection(ConString);
                con3s.Open();



                MySqlCommand cmd3s = new MySqlCommand("select pid from sales where paymentid='" + did + "'", con3s);


                int pd = Convert.ToInt16(cmd3s.ExecuteScalar().ToString());

                con3s.Close();





                MySqlConnection con3st = new MySqlConnection(ConString);
                con3st.Open();



                MySqlCommand cmd3st = new MySqlCommand("select stock from product where pid='" + pd + "'", con3st);


                int pdt = Convert.ToInt16(cmd3st.ExecuteScalar().ToString());

                con3st.Close();

                MySqlConnection conust = new MySqlConnection(ConString);
                conust.Open();

                int rst = pdt + q;

                MySqlCommand cmdust = new MySqlCommand("update product set stock='" + rst + "' where pid='" + pd + "'", conust);


                int j = cmdust.ExecuteNonQuery();

                conust.Close();
































                MySqlConnection cona = new MySqlConnection(ConString);
                cona.Open();



                MySqlCommand cmda = new MySqlCommand("select pcode from sales where paymentid='" + did + "'", cona);


                int pcode = Convert.ToInt16(cmda.ExecuteScalar().ToString());

                cona.Close();






                MySqlConnection conb = new MySqlConnection(ConString);
                conb.Open();



                MySqlCommand cmdb = new MySqlCommand("select payid from pay where pcode='" + pcode + "'", conb);


                int payid = Convert.ToInt16(cmdb.ExecuteScalar().ToString());

                conb.Close();





                MySqlConnection conc = new MySqlConnection(ConString);
                conc.Open();



                MySqlCommand cmdc = new MySqlCommand("select amount from pay where payid='" + payid + "'", conc);


                int amt = Convert.ToInt16(cmdc.ExecuteScalar().ToString());

                conc.Close();



                MySqlConnection cond = new MySqlConnection(ConString);
                cond.Open();
                int rstam = amt - amts;


                MySqlCommand cmdd = new MySqlCommand("update pay set amount='" + rstam + "' where payid='" + payid + "'", cond);


                int l = cmdd.ExecuteNonQuery();

                cond.Close();







                MySqlConnection conv = new MySqlConnection(ConString);
                conv.Open();



                MySqlCommand cmdv = new MySqlCommand("select count(*) from sales where pcode='" + pcode + "'", conv);


                int cnt = Convert.ToInt16(cmdv.ExecuteScalar().ToString());













                string query = "UPDATE sales SET status=@status WHERE paymentid=@did";

                using (MySqlConnection con = new MySqlConnection(ConString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {


                        cmd.Parameters.AddWithValue("@did", did);
                        cmd.Parameters.AddWithValue("@status", "Preparation completed");
                        // cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        if (cnt == 1)
                        {
                            MySqlConnection conl = new MySqlConnection(ConString);
                            conl.Open();



                            MySqlCommand cmdl = new MySqlCommand("update pay set status='Cancelled' where pcode='" + pcode + "'", conl);

                            cmdl.ExecuteNonQuery();


                            conl.Close();

                        }


                        conv.Close();











                        Response.Write("<script>alert('Success!!Cancelled ur order')</script>");










                        BindGrid();










                    }
                }
            }

            GridView2.EditIndex = -1;
            this.BindGrid();



        }
        else
        {


            Response.Write("<script>alert('Sorry!! You cant cancel order as it is bought under offer')</script>");






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



    protected void Button1_Click1(object sender, EventArgs e)
    {
       
        
        
        
        
        
     
        {

            MySqlConnection conbb = new MySqlConnection(ConString);
            conbb.Open();

            MySqlCommand cmdbb = new MySqlCommand("select bstatus from pay where pcode='" + Session["pid"].ToString() + "'", conbb);


            string bs = (cmdbb.ExecuteScalar().ToString());

            conbb.Close();

            if (bs == "Delivered and paid")
            {


                Response.Write("<script>alert('Preparation status already updated')</script>");


            }
            else if(bs == "Preparation completed")
            {
                Response.Write("<script>alert('Preparation status already updated')</script>");
            
            
            
            }

            else
            {


                MySqlConnection conb = new MySqlConnection(ConString);
                conb.Open();

                MySqlCommand cmdb = new MySqlCommand("select email from pay where pcode='" + Session["pid"].ToString() + "'", conb);


                string username = (cmdb.ExecuteScalar().ToString());

                conb.Close();


                MySqlConnection cona = new MySqlConnection(ConString);
                cona.Open();



                MySqlCommand cmda = new MySqlCommand("select place from pay where pcode='" + Session["pid"].ToString() + "'", cona);


                string zone = (cmda.ExecuteScalar().ToString());

                cona.Close();


                MySqlConnection conf = new MySqlConnection(ConString);
                conf.Open();



                MySqlCommand cmdf = new MySqlCommand("select payid from pay where pcode='" + Session["pid"].ToString() + "'", conf);


                int pc = Convert.ToInt16(cmdf.ExecuteScalar().ToString());

                conf.Close();



                MySqlConnection con22 = new MySqlConnection(ConString);
                con22.Open();
                MySqlCommand cmd22 = new MySqlCommand("select username from login where role='Packing manager'", con22);


                string mailid = cmd22.ExecuteScalar().ToString();

                con22.Close();







            


                    MySqlConnection cond = new MySqlConnection(ConString);
                    cond.Open();


                    MySqlCommand cmdd = new MySqlCommand("update pay set bstatus='Preparation completed' where pcode='" + Session["pid"].ToString() + "'", cond);


                    int l = cmdd.ExecuteNonQuery();

                    cond.Close();







                    MailMessage MyMailMessage = new MailMessage();
                    MailMessage MyMailMessage1 = new MailMessage();
                    MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");
                    MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");


                    MyMailMessage.To.Add(username);
                    MyMailMessage1.To.Add("rmsminiproject@gmail.com");


                    MyMailMessage.Subject = "Hai,this is from Feast. Your food order status details";
                    MyMailMessage1.Subject = "Production staus details";



                    MyMailMessage.Body = "Current status of your food order with order code " + pc + " is preparation completed. There will be no refund for paid amount.";
                    MyMailMessage1.Body = "Production status updated for order  from " + zone + " with order code "+pc+"  .Login and check for details";
                    MyMailMessage.IsBodyHtml = true;

                    MyMailMessage1.IsBodyHtml = true;



                    SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");
                    SmtpClient SMTPServer1 = new SmtpClient("smtp.gmail.com");


                    SMTPServer.Port = 587;
                    SMTPServer1.Port = 587;

                    SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                    SMTPServer1.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");



                    SMTPServer.EnableSsl = true;
                    SMTPServer1.EnableSsl = true;



                    MailMessage MyMailMessage2 = new MailMessage();

                    MyMailMessage2.From = new MailAddress("rmsminiproject@gmail.com");


                    MyMailMessage2.To.Add(mailid);



                    MyMailMessage2.Subject = "Preparation of new food order completed and ready for packing";


                    MyMailMessage2.Body = "Production completed for food order  from " + zone + " with order code " + pc + "  .Login and check for details";

                    MyMailMessage2.IsBodyHtml = true;




                    SmtpClient SMTPServer2 = new SmtpClient("smtp.gmail.com");

                    SMTPServer2.Port = 587;

                    SMTPServer2.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");


                    SMTPServer2.EnableSsl = true;





                    try
                    {

                        SMTPServer.Send(MyMailMessage);
                        SMTPServer1.Send(MyMailMessage1);
                        SMTPServer2.Send(MyMailMessage2);


                    }
                    catch { }



                }
              





                Response.Write("<script>alert('Production status updated')</script>");





            }

        }
    }
