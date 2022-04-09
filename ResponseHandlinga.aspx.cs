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
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;


public partial class ResponseHandlinga : System.Web.UI.Page
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
                    string query = "UPDATE reservation SET bstatus=@status,status=@pstatus,mode=@mode WHERE payid=@did";

                    using (MySqlConnection con = new MySqlConnection(ConString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {


                            cmd.Parameters.AddWithValue("@did", Convert.ToInt32(Request.Form["productinfo"].ToString()));
                            cmd.Parameters.AddWithValue("@status", "Confirmed");
                            cmd.Parameters.AddWithValue("@pstatus", "Advance payed");
                            cmd.Parameters.AddWithValue("@mode", "Online");
                           

                            // cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Connection = con;
                            con.Open();


                            MySqlConnection con3 = new MySqlConnection(ConString);
                            con3.Open();



                            MySqlCommand cmd3 = new MySqlCommand("select email from reservation where payid='" + Convert.ToInt32(Request.Form["productinfo"].ToString()) + "'", con3);


                            string ad = cmd3.ExecuteScalar().ToString();

                            con3.Close();


                            MySqlConnection con31 = new MySqlConnection(ConString);
                            con31.Open();



                            MySqlCommand cmd31 = new MySqlCommand("select name from customerregisration where emailid='" + ad + "'", con31);


                            string nm = cmd31.ExecuteScalar().ToString();

                            con31.Close();





                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MySqlConnection con2 = new MySqlConnection(ConString);
                                con2.Open();
                                MySqlCommand cmd2 = new MySqlCommand("select username from login where role='Order management manager'", con2);

                                string pa1 = cmd2.ExecuteScalar().ToString();

                                




                                MailMessage MyMailMessage = new MailMessage();
                                MailMessage MyMailMessage1 = new MailMessage();
                                MailMessage MyMailMessage2 = new MailMessage();


                                MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");
                                MyMailMessage1.From = new MailAddress("rmsminiproject@gmail.com");
                                MyMailMessage2.From = new MailAddress("rmsminiproject@gmail.com");

                                MyMailMessage.To.Add(ad);
                                MyMailMessage1.To.Add(pa1);
                                MyMailMessage2.To.Add("rmsminiproject@gmail.com");

                                MyMailMessage.Subject = "Hai, " + nm + " Your reservation details";
                                MyMailMessage1.Subject = "New reservation!!!";
                                MyMailMessage2.Subject = "Advance payment details!!!";


                                MyMailMessage.Body = "Your reservation charge of Rs " + Request.Form["amount"] + " with booking code : " + Request.Form["productinfo"] + " has been done successfully. Thank you!!! There will be no refund of reservation charge";
                                MyMailMessage1.Body = "New reservation has been confirmed  and paid reservation charge with booking code:" + Request.Form["productinfo"].ToString() + ".Login and check for more details";
                                MyMailMessage2.Body = "New reservation has been confirmed and paid reservation charge of Rs "+ Request.Form["amount"] +" with booking code:" + Request.Form["productinfo"].ToString() + ".Login and check for more details";




                                MyMailMessage.IsBodyHtml = true;

                                MyMailMessage1.IsBodyHtml = true;
                                MyMailMessage2.IsBodyHtml = true;

                                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                                SmtpClient SMTPServer1 = new SmtpClient("smtp.gmail.com");
                                SmtpClient SMTPServer2 = new SmtpClient("smtp.gmail.com");

                                SMTPServer.Port = 587;
                                SMTPServer1.Port = 587;
                                SMTPServer2.Port = 587;
                                SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                                SMTPServer1.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");
                                SMTPServer2.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                                SMTPServer.EnableSsl = true;
                                SMTPServer1.EnableSsl = true;
                                SMTPServer2.EnableSsl = true;

                                try
                                {

                                    SMTPServer.Send(MyMailMessage);
                                    SMTPServer1.Send(MyMailMessage1);
                                    SMTPServer2.Send(MyMailMessage2);





                                  





                                }

                                catch (Exception ex)
                                {

                                    // string msg = "Hi , your salary has ben credited Application  has been for";
                                    // SendSMS("8078296466", msg);




                                }

                            }

                            con.Close();

                            Response.Redirect("~/paymentsuccessa.aspx");
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
