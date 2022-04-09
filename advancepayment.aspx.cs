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

public partial class advancepayment : System.Web.UI.Page
{
    public string ConString = ConfigurationManager.ConnectionStrings["cybenko"].ConnectionString;


    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;



    protected void Page_Load(object sender, EventArgs e)
    {
        amount.Text = Session["amount"].ToString();
        productinfo.Text = Session["designname"].ToString();
        address1.Text = Session["a"].ToString();
        firstname.Text = Session["n"].ToString();
        phone.Text = Session["p"].ToString();
        email.Text = Session["e"].ToString();







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

        Session["pc"] = productinfo.Text;

        Session["pay"] = "0";


        if (RadioButtonList1.SelectedItem.Text == "Cancel")
        {

            string query = "UPDATE reservation SET bstatus=@status,status=@pstatus WHERE payid=@did";

            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {


                    cmd.Parameters.AddWithValue("@did", Convert.ToInt32(Session["designname"].ToString()));
                    cmd.Parameters.AddWithValue("@status", "Cancelled");
                    cmd.Parameters.AddWithValue("@pstatus", "Cancelled");


                    // cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Connection = con;
                    con.Open();


                    MySqlConnection con3 = new MySqlConnection(ConString);
                    con3.Open();



                    MySqlCommand cmd3 = new MySqlCommand("select email from reservation  where payid='" + Convert.ToInt32(Request.Form["productinfo"].ToString()) + "'", con3);


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

                        MyMailMessage.From = new MailAddress("rmsminiproject@gmail.com");


                        MyMailMessage.To.Add(pa1);

                        MyMailMessage.Subject = "Reservation cancelled";

                        MyMailMessage.Body = "Reservation with booking no: " + Session["designname"].ToString() + "has been cancelled by customer";

                        MyMailMessage.IsBodyHtml = true;

                        SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");

                        SMTPServer.Port = 587;

                        SMTPServer.Credentials = new System.Net.NetworkCredential("rmsminiproject@gmail.com", "@rmsminiproject1");

                        SMTPServer.EnableSsl = true;






                        try
                        {

                            SMTPServer.Send(MyMailMessage);
                           










                        }

                        catch (Exception ex)
                        {

                            // string msg = "Hi , your salary has ben credited Application  has been for";
                            // SendSMS("8078296466", msg);




                        }

                    }

                    con.Close();



                    Response.Write("<script>alert('Success. Your reservation has been cancelled. Please note that there is no refunding on cancelletion!!')</script>");
                }


            }
        }

        else
        {



























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
                {// surl.Text="http://localhost:57512/feast/indexx.aspx";
                    //furl.Text = "http://localhost:57512/feast/indexx.aspx";



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
                        //error string.IsNullOrEmpty(Request.Form["Surl"]) ||
                        //  string.IsNullOrEmpty(Request.Form["furl"]) ||


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


                    HiddenField1.Value = "http://localhost:57512/feast/indexx.aspx";
                    HiddenField2.Value = "http://localhost:57512/feast/indexx.aspx";
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
                    data.Add("surl", "http://localhost:57512/feast/ResponseHandlinga.aspx");
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



}