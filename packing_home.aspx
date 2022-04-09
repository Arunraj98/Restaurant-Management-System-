<%@ Page Language="C#" AutoEventWireup="true" CodeFile="packing_home.aspx.cs" Inherits="tailor_home" %>

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
                     
                    <li><a href="packing_home.aspx">Home</a> </li>

                   
                  
                     <li><a href="packing_bookings.aspx">Food Orders</a> </li>

                   




                      <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                           <li class="dropdown">
                                 <li><a href="packing_change_password.aspx">Change password</a> </li>

                     
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
    

    </section>


  
   </br>
    
                  
     </br>    
         
   <section id="product">
         <div class="container">
              <div align="center">
              </br>
        <strong>
        <asp:Label ID="Label1" runat="server" Text="Our Menu" Font-Size="XX-Large" 
           ForeColor="#005000" ></asp:Label>
        </strong>

       </br>

        </br>
      </div> 
   
            <div class="product-content">

              <div class="row">
                  <div class="col-md-4">
                     <div class="wow fadeInLeft p-cardsw">
                  
                        <div class="product-img" align="center">
                           <img src="images/veg.jpg" alt=""/>
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Vegetarian</h4>
                        
                           </p>
                           <asp:LinkButton ID="LinkButton3" runat="server" class="wow fadeIn" 
                                onclick="LinkButton3_Click">More</asp:LinkButton>
                         
                        </div>
                     </div>
                  </div>
                   <div class="col-md-4">
                     <div class="wow fadeInLeft p-cardsw">
                    
                        <div class="product-img" align="center">
                           <img src="images/nonveg.jpg" alt=""/>
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Non Vegetarian</h4>
                        
                           </p>
                           <asp:LinkButton ID="LinkButton2" runat="server" class="wow fadeIn" 
                                onclick="LinkButton2_Click">More</asp:LinkButton>
                          
                        </div>
                     </div>
                  </div>
                <!--  <div class="col-md-4">
                     <div class="wow fadeInLeft p-cards">
                     </br>
                     </br>
                        <div class="product-img" align="center">
                           <img src="images/SareeShop-Designer-SareeS-Grey-Georgette-SDL440602093-1-45a84 (2).jpeg" alt="" Height="300px" Width="300px">
                        </div>
                        </br>
                        </br>
                       
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Dress</h4>
                           <p class="wow fadeIn">
                           </p>
                           <a href="product_churidhar.aspx#product2" class="wow fadeIn">More <span><i class="fas fa-angle-right"></i></span></a>
                        </div>
                     </div>
                  </div>-->
                  
                  <div class="col-md-4">
                     <div class="wow fadeInRight p-cardsw">
                  
                        <div class="product-img" align="center">
                           <img src="images/tea.jpg" alt="" />
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Drinks</h4>


                           <asp:LinkButton ID="LinkButton1" runat="server" class="wow fadeIn"
                                onclick="LinkButton1_Click">More</asp:LinkButton>
                         
                        </div>
                     </div>
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

