using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;

using System.IO;
using System.Collections.Generic;


using MySql.Data.MySqlClient;




public partial class _Default : System.Web.UI.Page
{


    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;
    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;
    public string zone;



 
        
    protected void Page_Load(object sender, EventArgs e)
    {
       
            MySqlDataReader dr2;


            MySqlConnection con2 = new MySqlConnection(ConString);
            con2.Open();
            MySqlCommand cmd2 = new MySqlCommand("select name,phoneno,address,place from customerregisration where emailid='" + Session["user"].ToString() + "'", con2);

            dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                firstname.Text = dr2[0].ToString();
                address1.Text = dr2[2].ToString();
                phone.Text = dr2[1].ToString();
                TextBox1.Text = dr2[3].ToString();
                TextBox2.Text = Session["qt"].ToString();

           
            }


        int productid = Convert.ToInt16(Session["pd"].ToString());
        MySqlDataReader dr;



        string query = "select pname,price,ptype,stock,photoname from product where pid='" + productid + "'";




        MySqlConnection con1 = new MySqlConnection(ConString);
        con1.Open();
        MySqlCommand da = new MySqlCommand(query, con1);

        dr = da.ExecuteReader();

        if (dr.Read())
        {
            productinfo.Text = dr[0].ToString() + " ( " + dr[2].ToString() + ")";

            int am = Convert.ToInt16(dr[1].ToString());

            int qt=(Convert.ToInt16(Session["qt"].ToString()));
            int rs = (am * qt)+40;
            amount.Text = rs.ToString();



           
            email.Text = Session["user"].ToString();

            int stock = Convert.ToInt16(dr[3].ToString()) - 1;

            Session["pname"] = dr[0].ToString() + " (" + dr[2].ToString() + ")";
            Session["stock"] = stock.ToString();
            Session["photoname"] = dr[4].ToString();
        }

        try
        {



            key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];

            if (!IsPostBack)
            {
                frmError.Visible = false; // error form
            }
            else
            {
                //frmError.Visible = true;
            }
            if (string.IsNullOrEmpty(Request.Form["hash"]))
            {
                submit.Visible = true;
            }
            else
            {
                submit.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

        }

    }



    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);

        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "Others")
        {

            Response.Write("<script>alert('Sorry!! We don't have delivery to your place')</script>");

        }


        else
        {
            if (RadioButtonList1.SelectedItem.Text == "Cash on delivery")
            {









                int productid = Convert.ToInt16(Session["pd"].ToString());
                MySqlDataReader dr;



                string query1 = "select pname,price,ptype,stock,photoname,quantity from product where pid='" + productid + "'";




                MySqlConnection con2 = new MySqlConnection(ConString);
                con2.Open();
                MySqlCommand da = new MySqlCommand(query1, con2);

                dr = da.ExecuteReader();

                if (dr.Read())
                {




                    Random r = new Random();
                    string otp = r.Next().ToString().Substring(0, 4);

                    string query11 = "insert into pay(amount,pcode,date,ddate,name,address,place,phone,status,mode,email,bstatus,Zone) values('" + amount.Text + "','" + otp + "','" + DateTime.Now + "','Not delivered','"+firstname.Text+"','"+address1.Text+"','"+TextBox1.Text+"','"+phone.Text+"','Not paid','Cash on delivery','"+Session["user"].ToString()+"','Booked','"+TextBox1.Text+"')";

                    using (MySqlConnection con11 = new MySqlConnection(ConString))
                    {
                        using (MySqlCommand cmd11 = new MySqlCommand(query11))
                        {


                            cmd11.Connection = con11;
                            con11.Open();
                            int l = cmd11.ExecuteNonQuery();


                            if (l > 0)
                            {
                                string query = "insert into sales(name,email,address,phone,productname,photoname,status,amount,mode,date,pcode,buystatus,quantity,nos,pid,type) values('" + firstname.Text + "','" + email.Text + "','" + address1.Text + "','" + phone.Text + "','" + productinfo.Text + "','" + dr[4].ToString() + "','Not paid','" + amount.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DateTime.Now + "','" + otp + "','Buy','"+Session["qt"].ToString()+"','"+dr[5].ToString()+"','"+productid+"','Normal')";

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


                                                    cmd1.Parameters.AddWithValue("@did", productid);
                                                    cmd1.Parameters.AddWithValue("@stock", Convert.ToInt16(dr[3].ToString())-Convert.ToInt16(TextBox2.Text));
                                                    // cmd.Parameters.AddWithValue("@amount", amount);
                                                    cmd1.Connection = con1;
                                                    con1.Open();
                                                    int i = cmd1.ExecuteNonQuery();
                                                    if (i > 0)
                                                    {






                                                        MySqlConnection con22 = new MySqlConnection(ConString);
                                                        con22.Open();
                                                        MySqlCommand cmd22 = new MySqlCommand("select username from login where role='Production manager'", con22);


                                                      string mailid=  cmd22.ExecuteScalar().ToString();

                                                        con2.Close();



                                                      



                                                        MailMessage MyMailMessage = new MailMessage();
                                                        MailMessage MyMailMessage1 = new MailMessage();
                                                        MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");
                                                        MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");


                                                        MyMailMessage.To.Add(email.Text);
                                                        MyMailMessage1.To.Add(mailid);


                                                        MyMailMessage.Subject = "Hai " + firstname.Text + " Your order details";
                                                          MyMailMessage1.Subject ="New order details";



                                                        MyMailMessage.Body = "Product name :" + productinfo.Text + "\namount :" + amount.Text + "\n Payment mode :" + RadioButtonList1.SelectedItem.Text + "....We will deliver your food soon and for details login and check. Total amount includes delivery charge for your order and there is no refunding for paid amount.";
                                                         MyMailMessage1.Body = "New order for production from "+TextBox1.Text+ " .Login and check for details";
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

                                                        try
                                                        {

                                                            SMTPServer.Send(MyMailMessage);

                                                              SMTPServer1.Send(MyMailMessage1);
                                                            firstname.Text = "";

                                                            email.Text = "";
                                                            phone.Text = "";
                                                            address1.Text = "";
                                                            amount.Text = "";
                                                            TextBox1.Text="";
                                                                TextBox2.Text="";

                                                            Response.Write("<script>alert('Booking successful !!!! please check your mail  ')</script>");








                                                        }

                                                        catch (Exception ex)
                                                        {

                                                            // string msg = "Hi , your salary has ben credited Application  has been for";
                                                            // SendSMS("8078296466", msg);




                                                        }





                                                    }

                                                    con1.Close();


                                                }

                                            }



                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            else
            {







                int productid = Convert.ToInt16(Session["pd"].ToString());
                MySqlDataReader dr1;



                string query3 = "select pname,price,ptype,stock,photoname,quantity from product where pid='" + productid + "'";




                MySqlConnection con3 = new MySqlConnection(ConString);
                con3.Open();
                MySqlCommand da = new MySqlCommand(query3, con3);

                dr1 = da.ExecuteReader();
                if (dr1.Read())
                {
                    Session["productname"] = dr1[0].ToString() + " (" + dr1[2].ToString() + ")";
                    Session["photo"] = dr1[4].ToString();
                    int st = Convert.ToInt16(dr1[3].ToString());
                    Session["st"] = st.ToString();





                    MySqlConnection con31 = new MySqlConnection(ConString);
                    con31.Open();



                    MySqlCommand cmd31 = new MySqlCommand("insert into address(address,email,phone,photo,pid,stock,quantity,nos,place,zone) values('" + address1.Text + "','" + Session["user"].ToString() + "','" + phone.Text + "','" + dr1[4].ToString() + "','" + productid + "','" + st + "','"+dr1[5].ToString()+"','"+TextBox2.Text+"','"+TextBox1.Text+"','"+TextBox1.Text+"')", con31);


                    int i = cmd31.ExecuteNonQuery();

                    con31.Close();



                }

                Session["mode"] = RadioButtonList1.SelectedItem.Text;

                Session["fname"] = firstname.Text;
                Session["amount"] = amount.Text;
                Session["email"] = email.Text;
                Session["phone"] = phone.Text;
                Session["add"] = address1.Text;
                Session["pinfo"] = productinfo.Text;
                Session["sp"] = service_provider.Text;

                Session["pay"] = "1";
                try
                {

                    string[] hashVarsSeq;
                    string hash_string = string.Empty;



                    if (string.IsNullOrEmpty(Request.Form["txnid"])) // generating txnid
                    {
                        Random rnd = new Random();
                        string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                        txnid1 = strHash.ToString().Substring(0, 20);

                    }
                    else
                    {
                        txnid1 = Request.Form["txnid"];
                    }
                    if (string.IsNullOrEmpty(Request.Form["hash"])) // generating hash value
                    {
                        if (
                            string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]) ||

                            string.IsNullOrEmpty(Request.Form["amount"]) ||
                            string.IsNullOrEmpty(Request.Form["firstname"]) ||
                            string.IsNullOrEmpty(Request.Form["email"]) ||
                            string.IsNullOrEmpty(Request.Form["phone"]) ||
                            string.IsNullOrEmpty(Request.Form["productinfo"]) ||
                            string.IsNullOrEmpty(Request.Form["service_provider"])
                            )
                        {
                            //error

                            frmError.Visible = true;
                            return;
                        }

                        else
                        {
                            frmError.Visible = false;
                            hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                            hash_string = "";
                            foreach (string hash_var in hashVarsSeq)
                            {
                                if (hash_var == "key")
                                {
                                    hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "txnid")
                                {
                                    hash_string = hash_string + txnid1;
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "amount")
                                {
                                    hash_string = hash_string + Convert.ToDecimal(Request.Form[hash_var]).ToString("g29");
                                    hash_string = hash_string + '|';
                                }
                                else
                                {

                                    hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                                    hash_string = hash_string + '|';
                                }
                            }

                            hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT

                            hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                            action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL

                        }


                    }

                    else if (!string.IsNullOrEmpty(Request.Form["hash"]))
                    {
                        hash1 = Request.Form["hash"];
                        action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";

                    }




                    if (!string.IsNullOrEmpty(hash1))
                    {


                        hash.Value = hash1;
                        txnid.Value = txnid1;

                        System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                        data.Add("hash", hash.Value);
                        data.Add("txnid", txnid.Value);
                        data.Add("key", key.Value);
                        string AmountForm = Convert.ToDecimal(amount.Text.Trim()).ToString("g29");// eliminating trailing zeros
                        amount.Text = AmountForm;
                        data.Add("amount", AmountForm);
                        data.Add("firstname", firstname.Text.Trim());
                        data.Add("email", email.Text.Trim());
                        data.Add("phone", phone.Text.Trim());
                        data.Add("productinfo", productinfo.Text.Trim());
                        data.Add("surl", "http://localhost:57512/feast/Responsehandlings.aspx");
                        data.Add("furl", "http://localhost:57512/feast/Indexx.aspx");
                        data.Add("lastname", productinfo.Text);
                        data.Add("curl", " http://localhost:57512/feast/Indexx.aspx");
                        data.Add("address1", address1.Text.Trim());

                        data.Add("udf1", udf1.Text.Trim());
                        data.Add("udf2", udf2.Text.Trim());
                        data.Add("udf3", udf3.Text.Trim());
                        data.Add("udf4", udf4.Text.Trim());
                        data.Add("udf5", udf5.Text.Trim());
                        data.Add("pg", pg.Text.Trim());
                        data.Add("service_provider", service_provider.Text.Trim());


                        string strForm = PreparePOSTForm(action1, data);
                        Page.Controls.Add(new LiteralControl(strForm));

                    }

                    else
                    {
                        //no hash

                    }

                }

                catch (Exception ex)
                {
                    Response.Write("<span style='color:red'>" + ex.Message + "</span>");

                }



            }



        }


    }
    private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (System.Collections.DictionaryEntry key in data)
        {

            strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                           "\" value=\"" + key.Value + "\">");
        }


        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
    }


    public class SplitAggregator
    {
        public string name;
        public string description;
        public string value;
        public string merchantId;
    }




    
    /* protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
     {

         if (DropDownList2.SelectedItem.Text == "Change")
         {
             firstname.Text = "";
             address1.Text = "";
             phone.Text = "";




         }




         else
         {


             MySqlDataReader dr;


             MySqlConnection con = new MySqlConnection(ConString);
             con.Open();
             MySqlCommand cmd = new MySqlCommand("select name,phoneno,address, from customerregisration where emailid='" + Session["user"].ToString() + "'", con);

             dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 firstname.Text = dr[0].ToString();
                 address1.Text = dr[2].ToString();
                 phone.Text = dr[1].ToString();




             }



         }
     }
   */







}