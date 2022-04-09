<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

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
                     <a href="#" class="company-name"><strong>FEAST</strong></a> </ul> </ul>
                  <ul class="nav navbar-nav navbar-right">
                        <li><a href="Adminhome.aspx">Home</a> </li>

                      <li><a href="customer_details.aspx">Customers</a> </li>


                   
                  

                     <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Staff<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="registration.aspx">Registration</a></li> 
                           <li><a href="staff_detailsdetails.aspx">Details</a></li>
                            </ul>
                     </li>
                        <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Place<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="add_place_details.aspx">Add</a></li> 
                           <li><a href="view_place_details.aspx">View</a></li>
                          
                            </ul>
                     </li>


                     

                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sales<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="admin_feast_sale.aspx">Our foods</a></li> 
                          
                            <li><a href="admin_reservation_sale.aspx">Reservation</a></li>
                           
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
                     </li>

                            </ul>
                     </li> <!-- <li class="dropdown">
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

   <strong><em>
    <br class="style1">
    <br /><br />
    </em></strong>
    <div align="center">
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Feedbacks!!!" Font-Size="XX-Large" 
           ForeColor="#005000" ></asp:Label>
        </strong>
        </br>
        </br>

 <asp:GridView ID="GridView2" runat="server"  
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" Width="1087px" 
             AutoGenerateColumns="False" 
               PageSize = "5" AllowPaging ="True" 
           EmptyDataText="No records has been added." CellSpacing="2" ForeColor="Black"
            >
            <Columns>
            
                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("fname")+" "+Eval("lname") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" ItemStyle-Width="350">
                    <ItemTemplate>
                        <asp:Label ID="lbl_address" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="350px" />
                    </asp:TemplateField>
                 <asp:TemplateField HeaderText="Phone" ItemStyle-Width="350">
                    <ItemTemplate>
                        <asp:Label ID="lbl_place" runat="server" Text='<%# Eval("phone") %>'></asp:Label>
                    </ItemTemplate>
                     <ItemStyle Width="350px" />
                    </asp:TemplateField>



                  <asp:TemplateField HeaderText="Comments" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lbl_phone" runat="server" Text='<%# Eval("comment") %>'></asp:Label>
                    </ItemTemplate>
                      <ItemStyle Width="150px" />
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Date" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                    </asp:TemplateField>

                  
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#005000" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Left" BackColor="#CCCCCC" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        
    </ContentTemplate>
</asp:UpdatePanel>
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
