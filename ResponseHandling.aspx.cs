using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;




public partial class ResponseHandling : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string[] merc_hash_vars_seq;
            string merc_hash_string = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";





            if (Request.Form["status"] == "success")
            {

                {

                    MySqlConnection con31 = new MySqlConnection(ConString);
                    con31.Open();



                    MySqlCommand cmd31 = new MySqlCommand("select max(addressid) from addresscart where email='" + Request.Form["email"].ToString() + "'", con31);


                    int ad = Convert.ToInt16(cmd31.ExecuteScalar().ToString());

                    con31.Close();



                    MySqlDataReader dr1;



                    string query3 = "select * from addresscart where addressid='" + ad + "'";




                    MySqlConnection con3 = new MySqlConnection(ConString);
                    con3.Open();
                    MySqlCommand da = new MySqlCommand(query3, con3);

                    dr1 = da.ExecuteReader();
                    if (dr1.Read())
                    {

                        Random r = new Random();
                        string otp = r.Next().ToString().Substring(0, 4);

                        string query11 = "insert into pay(amount,pcode,date,ddate,name,address,place,phone,zone,status,mode,email,bstatus) values('" + Request.Form["amount"] + "','" + otp + "','" + DateTime.Now + "','Not delivered','" + Request.Form["firstname"].ToString() + "','" + dr1[1].ToString() + "','" + dr1[5].ToString() + "','" + dr1[4].ToString() + "','" + dr1[5].ToString() + "','Paid','Online','" + Request.Form["email"].ToString() + "','Booked')";

                        using (MySqlConnection con11 = new MySqlConnection(ConString))
                        {
                            using (MySqlCommand cmd11 = new MySqlCommand(query11))
                            {


                                cmd11.Connection = con11;
                                con11.Open();
                                int l = cmd11.ExecuteNonQuery();


                                if (l > 0)
                                {
                                    string query = "update sales set pcode='" + otp + "',mode='Online',status='Paid',buystatus='Buy' where buystatus='Cart' and email='" + Request.Form["email"].ToString() + "'";







                                    using (MySqlConnection con = new MySqlConnection(ConString))
                                    {
                                        using (MySqlCommand cmd = new MySqlCommand(query))
                                        {


                                            cmd.Connection = con;
                                            con.Open();
                                            int k = cmd.ExecuteNonQuery();


                                            if (k > 0)
                                            {


                                                string query1 = "UPDATE sales SET Buystatus=@stock WHERE email=@did and buystatus='Buy'";

                                                using (MySqlConnection con1 = new MySqlConnection(ConString))
                                                {
                                                    using (MySqlCommand cmd1 = new MySqlCommand(query1))
                                                    {


                                                        cmd1.Parameters.AddWithValue("@did", Request.Form["email"].ToString());
                                                        cmd1.Parameters.AddWithValue("@stock","Buy");
                                                        // cmd.Parameters.AddWithValue("@amount", amount);
                                                        cmd1.Connection = con1;
                                                        con1.Open();
                                                        int i = cmd1.ExecuteNonQuery();
                                                        if (i > 0)
                                                        {
                                                            MySqlConnection con22 = new MySqlConnection(ConString);
                                                            con22.Open();
                                                            MySqlCommand cmd22 = new MySqlCommand("select username from login where role='Production manager'", con22);


                                                            string mailid = cmd22.ExecuteScalar().ToString();

                                                            con22.Close();
                                                            
                                                            
                                                            
                                                            
                                                            
                                                            MailMessage MyMailMessage = new MailMessage();

                                                            MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


                                                            MyMailMessage.To.Add(Request.Form["email"].ToString());

                                                            MyMailMessage.Subject = "Hai, "+Request.Form["firstname"].ToString()  + " Your order details";

                                                            MyMailMessage.Body = "Purchase code: "+ otp +" No of items " + Request.Form[" productinfo "].ToString() + "\namount :" + Request.Form["amount"].ToString() + "\n Payment mode : online. We will deliver your product soon and for detailed information login and check.";

                                                            MyMailMessage.IsBodyHtml = true;

                                                            SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                                                            SMTPServer.Port = 587;

                                                            SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                                                            SMTPServer.EnableSsl = true;

                                                            MailMessage MyMailMessage1 = new MailMessage();
                                                            MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");
                                                            MyMailMessage1.To.Add(mailid);
                                                            MyMailMessage1.Subject = "New food order details";
                                                            MyMailMessage1.Body = "New food order for production from " + dr1[3].ToString() + " .Login and check for details";
                                                            MyMailMessage1.IsBodyHtml = true;
                                                            SmtpClient SMTPServer1 = new SmtpClient("smtp.gmail.com");
                                                            SMTPServer1.Port = 587;
                                                            SMTPServer1.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                                                            SMTPServer1.EnableSsl = true;


                                                            MailMessage MyMailMessage2 = new MailMessage();
                                                            MyMailMessage2.From = new MailAddress("rmsminiproject@gmail.com");
                                                            MyMailMessage2.To.Add("rmsminiproject@gmail.com");
                                                            MyMailMessage2.Subject = "New food order details";
                                                            MyMailMessage2.Body = "New food order  from " + dr1[3].ToString() + " and payment done. Login and check for details";
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




                                                                Response.Redirect("~/paymentsuccessful.aspx");


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
                merc_hash_vars_seq = hash_seq.Split('|');
                Array.Reverse(merc_hash_vars_seq);
                merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];


                foreach (string merc_hash_var in merc_hash_vars_seq)
                {
                    merc_hash_string += "|";
                    merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");

                }
                Response.Write(merc_hash_string);
                merc_hash = Generatehash512(merc_hash_string).ToLower();



                if (merc_hash != Request.Form["hash"])
                {
                    Response.Write("Hash value did not matched");

                }
                else
                {
                    order_id = Request.Form["txnid"];

                    Response.Write("value matched");

                    //Hash value did not matched
                }

            }

            else
            {

                Response.Write("Hash value did not matched");
                // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

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




}
