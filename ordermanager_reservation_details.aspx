﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ordermanager_reservation_details.aspx.cs" Inherits="ordermanager_reservation_details" %>

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
                    <a href="#" class="company-name"><strong>FEAST</strong></a> </ul> 
                  <ul class="nav navbar-nav navbar-right">
                     
                            <li><a href="om_manager_home.aspx">Home</a> </li>

                   
                         <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Reservation<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="ordermanager_reservation_details.aspx">Confirm</a></li> 
                           <li><a href="add_reservation.aspx">Add Charge</a></li>
                             <li><a href="update_resrvation.aspx">Update Charge</a></li>
                            </ul>
                     </li>


                   

                     
                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                                 <li><a href="om_manager_changepassword.aspx">Change password</a> </li>

                     
                     <li><a href="Logout.aspx">Logout</a> </li>
                            </ul>
                     </li>


                     </ul>
               
                 
               </div>
               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>
    

    


   

    
    <strong><em>
    <br class="style1">
    <br /><br />
    </em></strong>
    <div align="center">
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Reservation Details" Forecolor="#005000"  Font-Size="XX-Large" 
            CssClass="style2"  ></asp:Label>
        </strong>
        </br></br>
     <asp:GridView ID="GridView2" runat="server"  
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" Width="1300px" 
             AutoGenerateColumns="False" PageSize = "3" AllowPaging ="True" 
           EmptyDataText="No records has been added." CellSpacing="2" 
            onpageindexchanging="GridView2_PageIndexChanging" ForeColor="Black"

             onrowcancelingedit="GridView1_RowCancelingEdit" 
             onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" DataKeyNames="payid"
            
             >
            <Columns>
                            
                            
                            
                            
                              <asp:TemplateField HeaderText="Reservation code" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="tid" runat="server" Text='<%#Eval("payid") %>' ></asp:Label>                                
                </ItemTemplate>
                
                
                
<ItemStyle Width="150px"></ItemStyle>
                
                
                
                </asp:TemplateField>




                   <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="nm" runat="server" Text='<%#Eval("name") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              

</asp:TemplateField>



<asp:TemplateField HeaderText="Phone no" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="pn" runat="server" Text='<%#Eval("phone") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              

</asp:TemplateField>

                
                <asp:TemplateField HeaderText="Email" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="email" runat="server" Text='<%#Eval("email") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              

</asp:TemplateField>

              
                            
                            
                               <asp:TemplateField HeaderText="No of seats" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="Labe1" runat="server" Text='<%#Eval("no_of_seats") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hours" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="q" runat="server" Text='<%#Eval("hours") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Required date" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="d" runat="server" Text='<%#Eval("rdate") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Required time" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="t" runat="server" Text='<%#Eval("time") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                   
                                <asp:TemplateField HeaderText="Date & Time of booking" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="dates" runat="server" Text='<%#Eval("date") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>

                                                   
                      <asp:TemplateField HeaderText="Status" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="st" runat="server" Text='<%#Eval("bstatus") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>




 <EditItemTemplate>
                      
                       <asp:DropDownList ID="DropStatus" runat="server">
                       <asp:ListItem>Available</asp:ListItem>
                        <asp:ListItem>Unavailable</asp:ListItem>
                       </asp:DropDownList>
                    </EditItemTemplate>
                    






                              
                                </asp:TemplateField>



                                  <asp:TemplateField HeaderText="Payment staus" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="ps" runat="server" Text='<%#Eval("status") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
<asp:TemplateField HeaderText="Payment mode" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="pm" runat="server" Text='<%#Eval("mode") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>






                                
                                

                              
                            
                                 <asp:TemplateField HeaderText="Amount " ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="amount" runat="server" Text='<%#Eval("amount") %>' ></asp:Label>                                
                </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
                </asp:TemplateField>
           
                               
               
                             <asp:CommandField ButtonType="Button" ShowEditButton="true"  EditText="Update" UpdateText="Go" CancelText="Back" ControlStyle-BackColor="#005000" ControlStyle-CssClass="btn " ControlStyle-Width="100" ControlStyle-ForeColor="#ffffff" ControlStyle-Height="35"
                    ItemStyle-Width="150" >


                <ItemStyle Width="150px" />
                </asp:CommandField>

     
                
                
                          

            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#005000" Font-Bold="True" ForeColor="White" Font-Size="16px"/>
            <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
            <RowStyle BackColor="White"  Font-Size="12px"/>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
     </asp:GridView>



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
     *






    </form>
</body>
</html>
