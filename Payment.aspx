<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Payment.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
      <meta http-equiv="x-ua-compatible" content="ie=edge">
      <title>FEAST</title>
      <meta name="description" content="">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="css/css-wrap.css">
      <script defer src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
      
    <style type="text/css">
        .style5
        {
            font-weight: bold;
          
            color:#005000;
        }
        .style8
        {
            font-style: normal;
            color: #005000;
            font-size: xx-large;
        }
        
        
        .style9
        {
            font-style: normal;
            color: #B3001E;
            font-size: x-large;
        }
    </style>
      
</head>

<body>
    <form id="form2" runat="server">
     <div  class="cus-style">
    <div>
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
                          <li><a href="customer__main_home.aspx">Home</a> </li>
                          
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Reservation<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                        <li><a href="reservation.aspx">Submit</a> </li>
                     <li><a href="Customer_resrvationstatus.aspx">Status</a> </li>
                            </ul>
                     </li>

                          
                           <li><a href="customer__main_home.aspx">Book Now</a></li>
                             <li><a href="customer_cart.aspx">Your cart</a></li> 
                           <li><a href="view_order_customer.aspx">Your order</a></li>



                   
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                           <li><a href="Changeaddress.aspx">Change address</a> </li>
                     <li><a href="customer_change_password.aspx">Change password</a> </li>
                     <li><a href="Logout.aspx">Logout</a> </li>
                            </ul>
                     </li>




                    
                     </ul>
                     <!--<li><a href="#about">About Us</a></li>
                     <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Products <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="Pumps.aspx">Pumps</a></li> 
                           <li><a href="Generator.aspx">Generators</a></li>
                            </ul>
                     </li>
                     <li><a href="login.aspx">Login</a></li>
                     <li><a href="#contact">Contact Us</a></li>-->
                  </ul>
               
                 
                 
               </div>
               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>
    

         
    <div id ="frmError" runat="server">
      <span style="color:red">Please fill all mandatory fields.</span>
      
      </div>
      
    
   <input type="hidden" runat="server" id="key" name="key" />
      <input type="hidden" runat="server" id="hash" name="hash"  />
            <input type="hidden" runat="server" id="txnid" name="txnid" />

            <div align="left">

     
      <div align="center" class="col-md-offset-6">
        <table style="width:100%;" align="left">
        <tr><td class="style5" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span 
                class="style8">Payment details</span> </td>


</tr>
                  <tr>
                <td class="style5" colspan="2">&nbsp;&nbsp;&nbsp;<span 
                class="style9">Amount includes delivery charge of Rs 40 /-</span> </td>
</tr>

 
          
            





         <tr></br></br>
          <td class="style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name </td>
          <td></br>
           <asp:TextBox ID="firstname" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter first name" required="required" pattern="[a-zA-Z\s]+$"/></td></br>
            
        </tr>
        
            <tr>
                <td class="style5"></br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Quantity</td>
                <td>
          <asp:TextBox ID="TextBox2" runat="server" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" /></td>
            </tr>
            
       


            <tr>
                <td class="style5"></br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Amount</td>
                <td>
          <asp:TextBox ID="amount" runat="server" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" /></td>
            </tr>
           
            <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email Id</td>
                <td>
              <asp:TextBox ID="email" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter emailid" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="Enter valid email" ControlToValidate="email" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
</td>
            <td>
            </td>
            </tr>

           
           <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone</td>
                <td>
           <asp:TextBox ID="phone" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter phone no" required="required" MaxLength="10" ValidationExpression="[0-9]{10}"/>
                                <asp:RegularExpressionValidator
                ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="Enter valid phone no" ControlToValidate="phone" 
                        ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator></td>
            </tr>
          </br>
       
       <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product</td>
                <td>
               <asp:TextBox ID="productinfo" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px"   /></td>
            </tr>
          </br>


         
          



         <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address</td>
                <td>
            <asp:TextBox ID="address1" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter address"/></td>
            </tr>


             <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Place</td>
                <td>

              <asp:TextBox ID="TextBox1" runat="server"  class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="place"/>
            </tr>
        




            <tr>
            <td class="style5">Payment mode:</td><td><asp:RadioButtonList ID="RadioButtonList1" runat="server" ForeColor="#005000">
                <asp:ListItem Selected="True">Online</asp:ListItem>
                <asp:ListItem>Cash on delivery</asp:ListItem>
                </asp:RadioButtonList>
             
              
             
            </td>
            </tr>
          
                 
        
         <!-- <tr>
          <td class="style2">Success URI:<br />
&nbsp;</td>
          <td colspan="3">
          <asp:TextBox ID="surl" runat="server" CssClass="style3" /></td>
        </tr>
        <tr>
          <td class="style2">Failure URI: 
              <br />
            </td>
          <td colspan="3">
          <asp:TextBox ID="furl" runat="server" CssClass="style3" /></td>
        </tr>-->
      <!--  <tr>
          <td class="style5"><span class="style6">Optional Parameters</span><br 
                  class="style7" />
            </td>
        </tr>-->
        <tr>
           <!--<tr>
          <td class="style2">UDF1: 
              <br />
            </td>
          <td>
           <asp:TextBox ID="udf1" runat="server" CssClass="style3" /></td>
          <td class="style2">UDF2: </td>
          <td>
           <asp:TextBox ID="udf2" runat="server" CssClass="style3" /></td>
        </tr>
        <tr>
          <td class="style2">UDF3: 
              <br />
            </td>
          <td>
           <asp:TextBox ID="udf3" runat="server" CssClass="style3" /></td>
          <td class="style2">UDF4: </td>
          <td>
           <asp:TextBox ID="udf4" runat="server" CssClass="style3" /></td>
        </tr>
        <tr>
          <td class="style2">UDF5: 
              <br />
            </td>
          <td>
           <asp:TextBox ID="udf5" runat="server" CssClass="style3" /></td>
          <td class="style2">PG: </td>
          <td>
           <asp:TextBox ID="pg" runat="server" /></td>
        </tr>-->
	
    <tr>
                <td class="style5">
&nbsp;&nbsp;&nbsp;&nbsp; Service provider</td>
                <td>
              <asp:TextBox ID="service_provider" runat="server" Text="payu_paisa" 
                 class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" /></td>
		</tr>
        </br>
        <tr>
        
            <td colspan="2">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
            
        </tr>
      </table>
     </br>
     <div> <div class="col-md-4 col-md-offset-3"> 
      <asp:Button ID="submit" Text="submit" runat="server" 
             OnClick="Button1_Click" class="form-control" Font-Bold="True" 
            BackColor="#005000"   
            ForeColor="White" Height="37px" Width="200px"  />
            </div></div>

      </div>

      
     <script src="js/jquery-3.1.1.min.js"></script>
      <script src="js/bootstrap.min.js"></script>
      <script src="js/smooth-scroll.js"></script>
      <script src="js/wow.js"></script>
      <script src="js/jquery.flexslider-min.js"></script>
      <script>          $('.flexslider').flexslider({
              animation: "slide",
              directionNav: false
          });
      </script>
      <script>
          $(window).scroll(function () {
              if ($(document).scrollTop() > 0) {
                  $('#header').addClass('sticky');
              } else {
                  $('#header').removeClass('sticky');
              }
          });
      </script>
      <script>
          $(function () {
              $('.scroll-set').click(function () {
                  if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
                      var target = $(this.hash);
                      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                      if (target.length) {
                          $('html, body').animate({
                              scrollTop: target.offset().top - 50
                          }, 1000);
                          return false;
                      }
                  }
              });
          });
      </script>
      <script>
          $(document).ready(function () {

              $('ul.tabs li').click(function () {
                  var tab_id = $(this).attr('data-tab');

                  $('ul.tabs li').removeClass('current');
                  $('.tab-content').removeClass('current');

                  $(this).addClass('current');
                  $("#" + tab_id).addClass('current');
              })

          })
      </script>
      <script>
          $('.dropdown-submenu .dropdown-menu').parent().hover(function () {
              var menu = $(this).find("ul");
              var menupos = $(menu).offset();

              if (menupos.left + menu.width() > $(window).width()) {
                  var newpos = -$(menu).width();
                  menu.css({ left: newpos });
              }
          });
         
      </script>
      <script>
          var wow = new WOW(
  {
      boxClass: 'wow',      // animated element css class (default is wow)
      animateClass: 'animated', // animation css class (default is animated)
      offset: 110,          // distance to the element when triggering the animation (default is 0)
      mobile: true,       // trigger animations on mobile devices (default is true)
      live: true,       // act on asynchronously loaded content (default is true)
      callback: function (box) {
          // the callback is fired every time an animation is started
          // the argument that is passed in is the DOM node being animated
      },
      scrollContainer: null // optional scroll container selector, otherwise use window
  }
);
          wow.init();
      </script>
     






    </form>
</body>
</html>
