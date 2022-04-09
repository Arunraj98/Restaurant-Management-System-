<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stock_product.aspx.cs" Inherits="staffproduct" %>

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
            color: #ffffff;
            text-decoration: underline;
        }
        .style2
        {
            color: #ffffff;
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
                    <li><a href="inventory_home.aspx">Home</a> </li>

                     <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Our products <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                            <li><a href="Product.aspx">Add</a></li> 
                           <li><a href="inventory_home.aspx">View</a></li>

                            <li><a href="stock_product.aspx">Update</a></li>
                            </ul>
                     </li>


                    


                     
                   




                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sub category<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                             <li><a href="add_subtype.aspx">Add</a></li> 
                           <li><a href="view_subtype.aspx">View</a></li>

                            <li><a href="update_subtype.aspx">Update</a></li>
                            </ul>
                     </li>
                       <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                          
                         <li><a href="inventory_chagepassword.aspx">Change password</a> </li>
                     
                     <li><a href="Logout.aspx">Logout</a> </li>
                            </ul>
                     </li>
    <!-- <li class="dropdown">
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
    

    


    <strong><em>
    <br class="style1">
    </br>
    </em></strong>
    <div align="center">
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Update stock" Font-Size="XX-Large" 
           ForeColor="#ffffff" ></asp:Label>
        </strong>
        </br>
        </br>




     
                   <div class="row">
              <div class="col-md-3 col-md-offset-2">
               <asp:Label ID="Label5" runat="server" Text="Product Category"   Font-Bold="True" ForeColor="#ffffff"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" 
                    Width="200px" Height="35px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AutoPostBack="True" AppendDataBoundItems="True">
                  <asp:ListItem>Select</asp:ListItem>
                       <asp:ListItem Value="Vegetarian">Vegetarian</asp:ListItem>
                        <asp:ListItem Value="Non Vegetarian">Non Vegetarian</asp:ListItem>
                        <asp:ListItem Value="Drinks">Drinks</asp:ListItem>
                      
                      
                       
                       
                   </asp:DropDownList></div>
                    
            

                
    <div class="col-md-3 col-md-offset-1">
               <asp:Label ID="Label8" runat="server" Text="Sub category"   Font-Bold="True" ForeColor="#ffffff"></asp:Label>
               <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" 
                    Width="200px" Height="35px"    onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
            AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem>Select</asp:ListItem>
                      
                       
                      
                       
                    </asp:DropDownList></div></div>


                    </br>

    <asp:GridView ID="GridView2" runat="server"  
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" Width="948px" 
             AutoGenerateColumns="False" PageSize = "3" AllowPaging ="True" 
           EmptyDataText="No records has been added." CellSpacing="2" 
            onpageindexchanging="GridView2_PageIndexChanging" ForeColor="Black" onrowcancelingedit="GridView1_RowCancelingEdit" 
             onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" DataKeyNames="pid">

            <Columns>
            <asp:TemplateField HeaderText="Product code" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="pid" runat="server" Text='<%#Eval("pid") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                

                <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="name" runat="server" Text='<%#Eval("pname") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                               
                              
                               


                                <asp:TemplateField HeaderText="Products" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("photoname") %>' Height="150px" Width="100px"/>
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Price" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="clothtype" runat="server" Text='<%#Eval("Price") %>' ></asp:Label>                                
                </ItemTemplate>
                             
<ItemStyle Width="150px"></ItemStyle>
                             
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Quantity" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="quantity" runat="server" Text='<%#Eval("quantity") %>' ></asp:Label>                                
                </ItemTemplate>
                             
<ItemStyle Width="150px"></ItemStyle>
                             
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Stock" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="size" runat="server" Text='<%#Eval("Stock") %>' ></asp:Label>                                
                </ItemTemplate>
                 <EditItemTemplate>

                  <asp:TextBox ID="TextBox1" runat="server" required="required"></asp:TextBox>
                              
                                
                  
                 </EditItemTemplate>
               
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                               
  <asp:CommandField ButtonType="Button" ShowEditButton="true" ControlStyle-BackColor="#000000" CausesValidation="true" ControlStyle-ForeColor="#ffffff" ControlStyle-CssClass="btn" ControlStyle-Width="100" ControlStyle-Height="35" EditText="Update stock" UpdateText="Confirm" CancelText="Cancel"
                    ItemStyle-Width="150" >


                <ItemStyle Width="150px" />
                </asp:CommandField>



            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#000000" Font-Bold="True" ForeColor="White" 
                Font-Size="16px" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
            <RowStyle Font-Size="12px" BackColor="White" />
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
     










    </form>
</body>
</html>

