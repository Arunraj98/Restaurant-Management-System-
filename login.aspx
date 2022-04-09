<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"  class="no-js" lang="">
<head id="Head1" runat="server">
        <meta charset="utf-8">
      <meta http-equiv="x-ua-compatible" content="ie=edge">
      <title>FEAST</title>
      <meta name="description" content="">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="css/css-wrap.css">
      <script defer src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
        </head>

<body>

    <form id="form1" runat="server">
  
   <div  class="cus-style">
    <section class="custom-header">
         <nav class="navbar navbar-default" id="header">
            <div class="container">
               <!-- Brand and toggle get grouped for better mobile display -->
               <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                  <span class="sr-only">Toggle navigation</span>
                  <span class="icon-bar"></span>
                  <span class="icon-bar"></span>
                  <span class="icon-bar"></span>
                  </button>
               </div>
               <!-- Collect the nav links, forms, and other content for toggling -->
               <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <ul class="nav navbar-left">
                      <a href="#" class="company-name"><strong>FEAST</strong></a> </ul>
                  <ul class="nav navbar-nav navbar-right">
                     <li><a href="Indexx.aspx">Home</a></li>
                   </ul>
               
                 
               </div>
               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>
          
      </section>

   
      </br>
      </br>
      </br>
            </br>
      </br>
      </br>
      </br></br>
<section>
<div class="row">
 <div class="banner-contents">
                     <h1 class="animated fadeInDown lcolor">GOOD FOOD GOOD LIFE..</h1>
                    
                  </div>


</div>
       <div class="row">
                  <div class="col-md-3 col-md-offset-7">
                     <div class="wow fadeInLeft cardnew" align="center">
              
  
     <!--  <em><strong>
       <asp:Label ID="Label1" runat="server" Text="LOGIN" Font-Size="Xlarge"></asp:Label>
   </br>

       </strong></em>-->
       </br>
       </br>
       
  <asp:TextBox ID="txtname" runat="server" class="form-control"  ForeColor="#000000" 
            Width="200px" Height="35px" placeholder="Username"  required="required"
           BorderColor="#300000" BorderStyle="Double" type="email" ValidationGroup="a"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ErrorMessage="Enter username" ControlToValidate="txtname" 
                             ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </br>
                <asp:TextBox ID="txtpswd" runat="server" class="form-control"  ForeColor="#000000" 
            TextMode="Password" Width="200px" Height="35px" placeholder="Password" 
          BorderColor="#300000" BorderStyle="Ridge"></asp:TextBox>
             </br>
        <asp:Button ID="Button2" runat="server" Text="Sign in" class="form-control" Font-Bold="True" 
            BackColor="#005000"   
            ForeColor="White" Height="37px" Width="200px" onclick="Button1_Click1" />
                </br>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
              <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#ffffff" 
           onclick="LinkButton1_Click">Register</asp:LinkButton>
                &nbsp; </strong>&nbsp;&nbsp;       
                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#ffffff" 
           style="font-weight: 700" onclick="LinkButton2_Click" ValidationGroup="a">Forgot password?</asp:LinkButton>
           </br></br>
                </div>
                </div>
                </div>
                </div>


                </section>
            
    </form>
  
    </body>

</html>
