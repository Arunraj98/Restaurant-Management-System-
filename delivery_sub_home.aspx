<%@ Page Language="C#" AutoEventWireup="true" CodeFile="delivery_sub_home.aspx.cs" Inherits="packing_sub_home" %>

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
            color: #000000;
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
                          <li><a href="delivery_home.aspx">Home</a> </li>

                   
                  
                     <li><a href="delivery_bookings.aspx">Food orders</a> </li>

                   



             
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                                 <li><a href="delivery_change_password.aspx">Change password</a> </li>

                     
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



  </br>

    </br>

    
     </br>
     </br>
    <div align="center">
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Our menu" Font-Size="XX-Large" 
           ForeColor="#005000" ></asp:Label>
        </strong>
        </br>
      </div> 
   

   
   <div class="row">
              <div class="col-md-2 col-md-offset-3">
                <div class="dd">
              <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" 
                    Width="300px" Height="35px"  onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
           AppendDataBoundItems="True" AutoPostBack="true">
                    <asp:ListItem>Select</asp:ListItem>
                       
                      
                       
                    </asp:DropDownList>



                <asp:ImageButton ID="ImageButton2"
           runat="server" ImageUrl="~/images/search.jpg" Height="35px" Width="35px" onclick="ImageButton2_Click" 
                      />
                      </div>
              </div>

                 <div class="col-md-2 col-md-offset-2">

              <div class="dd">
   
       <asp:TextBox ID="TextBox1" runat="server" Width="200px"  class="form-control"  Height="35px" placeholder="Search"></asp:TextBox>
       <asp:ImageButton ID="ImageButton1"
           runat="server" ImageUrl="~/images/search.jpg" Height="35px" Width="35px" 
                      onclick="ImageButton1_Click" />
   
   </div>
          </div>    

              
    
      <section id="product2">
         <div class="container">
         

            <div class="product-content">

            
           
               <div class="row">
             <asp:Repeater ID="repeater2" runat="server" onitemcommand="repeater2_ItemCommand"  >
                
               
                        <ItemTemplate>
                  <div class="col-md-3">
                     <div class="p-card p-card2">
                        <div class="product-img">
                      
                            <img src="<%# Eval("photoname") %>" alt=" sss" class="img-thumbnail"/>
							
                        </div>
                        <div class="product-txt">
                        
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("pid") %>'></asp:HiddenField>
                           <h4 class="content-text txtal"><%# Eval("pname") %></h4> 
                           <p class="content-text txtal">Price: <%# Eval("price")%></p>
                           <p class="content-text txtal">Stock: <%# Eval("stock")%></p>
                           <p class="content-text txtal">Quantity: <%# Eval("quantity")%></p>
                         
                          
                       
                           </div>
                  </div> 
           
                  


                 


                  </div>
                   </ItemTemplate></asp:Repeater>


               </div>
         </div>
      </section>
       

    



      
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


