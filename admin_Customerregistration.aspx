<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_Customerregistration.aspx.cs" Inherits="staff_Customerregistration" %>

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
        .style1
        {
            font-size: x-large;
            color: #000000;
            text-decoration: underline;
        }
        .style2
        {
            color: #005000;
          font-size:18px;
        }
        
    </style>

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
                       <a href="#" class="company-name"><strong>FEAST</strong></a>- </ul>
                  <ul class="nav navbar-nav navbar-right">
                     
                          <li><a href="Adminhome.aspx">Home</a> </li>

                   
                         <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Customer<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="admin_Customerregistration.aspx">Registration</a></li> 
                           <li><a href="customer_details.aspx">Details</a></li>
                            </ul>
                     </li>


                     <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Staff<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="registration.aspx">Registration</a></li> 
                           <li><a href="staff_detailsdetails.aspx">Details</a></li>
                            </ul>
                     </li>

                        <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">View<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="Adminhome.aspx">Product</a></li> 
                             <li><a href="admin_offer.aspx">Offers</a></li> 

                           <li><a href="admin_category.aspx">Category</a></li>
                            <li><a href="admin_zone.aspx">Zone</a></li>
                            </ul>
                     </li>


                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Income<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="admin_all_sale.aspx">All</a></li> 
                          
                            <li><a href="admin_zone_sale.aspx">Zone</a></li>
                           
                            </ul>
                     </li>





                     <li><a href="feedback.aspx">Feedback</a> </li>


                     
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                                 <li><a href="admin_changepassword.aspx">Change password</a> </li>

                     
                     <li><a href="Logout.aspx">Logout</a> </li>
                            </ul>
                     </li>    <!-- <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Products <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="Pumps.aspx">Pumps</a></li> 
                           <li><a href="Generator.aspx">Generators</a></li>
                            </ul>
                     </li>-->
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
      
   <div class="col-md-5 col-md-offset-5">
       <strong>
       <asp:Label ID="Label1" runat="server" Text="Customer Registration" Font-Size="XX-Large" 
           ForeColor="#005000"></asp:Label>
         </br>
         </br>
       </strong></div>
  
   
    <div align="center" class="col-md-offset-4">
        <table style="width:100%;" align="center">
             <tr>
                <td class="style2" style="height:45px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter name" required="required" pattern="[a-zA-Z\s]+$"></asp:TextBox>
                </td>
            </tr>

             
            <tr>
                <td class="style2" style="height:45px;" >
               
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address</td>
                <td>
                    <asp:TextBox ID="txtadres" runat="server" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter Address"  
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" style="height:45px;" >
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Place&nbsp;</td>
                <td>
                      <asp:DropDownList ID="DropDownList2" runat="server" class="form-control"
                    Width="200px" Height="35px" 
                        
                     >
                    <asp:ListItem>Select</asp:ListItem>
                      
                         <asp:ListItem >Others</asp:ListItem>
                      
                       
                    </asp:DropDownList>
              </td>
            </tr>
            <tr>
                <td class="style2" style="height:45px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone No&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtphoneno" runat="server" 
                        ontextchanged="TextBox4_TextChanged" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter Phone no" 
                        required="required" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator
                ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="Enter valid phone no" ControlToValidate="txtphoneno" 
                        ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2" style="height:45px;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email Id</td>
                <td>
                    <asp:TextBox ID="txtemailid" runat="server" 
                        ontextchanged="TextBox5_TextChanged" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter email id" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="Enter valid email" ControlToValidate="txtemailid" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
                    
                   
        </table>
        </div>
       <div> <div class="col-md-5 col-md-offset-6"> <asp:Button ID="submit" runat="server" onclick="Button1_Click" Text="Submit" class="form-control" Font-Bold="True" 
            BackColor="#005000"   
            ForeColor="White" Height="37px" Width="150px"  />
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
