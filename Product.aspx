<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <meta charset="utf-8">
      <meta http-equiv="x-ua-compatible" content="ie=edge">
      <title>FEAST</title>
      <meta name="description" content="">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="css/css-wrap.css">
      <script defer src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
        </head>
    <style type="text/css">
        .style3
        {
            text-decoration: underline;
        }
        .style4
        {
            font-size: large;
        }
    </style>

</head>
  <body>
    <form id="form1" runat="server">
    <div class="cus-style">
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
                     
                    <li><a href="production_home.aspx">Home</a> </li>

                   
                  <li><a href="production_bookings.aspx">Food orders</a> </li>

                   <li><a href="production_manager_reservation_details.aspx">Reservation</a></li> 

                   
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Food items<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                               
                     
                     <li><a href="Product.aspx">Add</a> </li>
                       <li><a href="production_home.aspx">View</a></li>


                            </ul>
                     </li>

                   
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Food types<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                               
                     
                     <li><a href="add_subtype.aspx">Add</a> </li>
                       <li><a href="view_subtype.aspx">View</a></li>

                          <li><a href="update_subtype.aspx">Update</a></li>

                            </ul>
                     </li>



                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                                 <li><a href="production_change_password.aspx">Change password</a> </li>

                     
                     <li><a href="Logout.aspx">Logout</a> </li>
                            </ul>
                     </li>

                 </ul>
               </div>

               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>
      </section>
        <div class="container">
    
    </br></br></br>
  
                
   
      <div class="row">
    
      <div class="col-md-5 col-md-offset-7">
       <strong>
       <asp:Label ID="Label6" runat="server" Text="Add Food Items" Font-Size="XX-Large" 
           ForeColor="#005000"></asp:Label>
        </br>
         </br>
       </strong></div>
       </div>
      
  </br>
                   <div class="row">
              <div class="col-md-3 col-md-offset-5">
               <asp:Label ID="Label5" runat="server" Text="Food type"   Font-Bold="True" ForeColor="#005000"></asp:Label></div>
                 <div class="col-md-3 col-md-offset-1"><asp:DropDownList ID="DropDownList1" runat="server" class="form-control" 
                    Width="200px" Height="35px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True" AppendDataBoundItems="True">
                  <asp:ListItem>Select</asp:ListItem>
                       <asp:ListItem Value="Vegetarian">Vegetarian</asp:ListItem>
                        <asp:ListItem Value="Non Vegetarian">Non Vegetarian</asp:ListItem>
                        <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
                      
                      
                       
                      
                       
                   </asp:DropDownList></div></div>
                    
                </br>

                
                   <div class="row">
              <div class="col-md-3 col-md-offset-5">
               <asp:Label ID="Label8" runat="server" Text="Food subtype"   Font-Bold="True" ForeColor="#005000"></asp:Label></div>
                 <div class="col-md-3 col-md-offset-1"><asp:DropDownList ID="DropDownList2" runat="server" class="form-control" 
                    Width="200px" Height="35px">
                    <asp:ListItem>Select</asp:ListItem>
                      
                       
                      
                       
                    </asp:DropDownList></div></div>
                    </br>


                  <div class="row">
              <div class="col-md-3 col-md-offset-5">
              <asp:Label ID="Label1" runat="server" Text="Food name"  Font-Bold="True"  ForeColor="#005000"></asp:Label></div>
                   <div class="col-md-3 col-md-offset-1"> <asp:TextBox ID="txtname" runat="server" class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter product name"  required="required"></asp:TextBox>
                    </div></div>
                    </br>
                    <div class="row">
              <div class="col-md-3 col-md-offset-5">
            <asp:Label ID="Label2" runat="server" Text="Photo" Font-Bold="True"  ForeColor="#005000"></asp:Label></div>
                <div class="col-md-3 col-md-offset-1">    <asp:FileUpload ID="fuphoto" runat="server"  class="form-control"  ForeColor="#993300" 
            Width="200px" Height="35px"  required="required"/>
                  </div>
                  </div></br>
                   <div class="row">
              <div class="col-md-3 col-md-offset-5">
             <asp:Label ID="Label3" runat="server" Text="Price" Font-Bold="True" ForeColor="#005000"></asp:Label></div>
                <div class="col-md-3 col-md-offset-1">    
                    <asp:TextBox ID="txtprice" runat="server" 
                        class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter price"  required="required" TextMode="Number" min="1"></asp:TextBox>
                  </div></div>
                               </br>
                                <div class="row">
              <div class="col-md-3 col-md-offset-5">
             <asp:Label ID="Label7" runat="server" Text="Quantity" Font-Bold="True" ForeColor="#005000"></asp:Label></div>
                <div class="col-md-3 col-md-offset-1">    
                    <asp:TextBox ID="TextBox1" runat="server" 
                        class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter quantity"  required="required"></asp:TextBox>
                  </div></div>
                               </br>
                  
                  <div class="row">
              <div class="col-md-3 col-md-offset-5">
  <asp:Label ID="Label4" runat="server" Text="Stock" Font-Bold="True" ForeColor="#005000"></asp:Label></div>
                  <div class="col-md-3 col-md-offset-1">  
                      <asp:TextBox ID="txtstock" runat="server" 
                          class="form-control"  ForeColor="#800000" 
            Width="200px" Height="35px" placeholder="Enter stock"  
                          required="required" MaxLength="6" TextMode="Number" min="0"></asp:TextBox>
            </div></div>
                   </br> <div class="col-md-5 col-md-offset-7"><asp:Button ID="btnsubmit" runat="server" Text="Submit" class="form-control" Font-Bold="True" 
            BackColor="#005000"   
            ForeColor="White" Height="37px" Width="200px" onclick="Button1_Click1" /></div>
            </div>
                  
    
    </div>
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
