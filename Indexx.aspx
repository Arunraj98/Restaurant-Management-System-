<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Indexx.aspx.cs" Inherits="_Default" %>
<!doctype html>
<html class="no-js" lang="">
   <head>
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
               font-size: 22px;
               color: #000000;
           }
       </style>
   </head>
   <body>
       <form id="form1" runat="server">
      <!-- Header -->
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
                 
                    
                  <a href="#" class="company-name"><strong>FEAST</strong></a>
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                     <li><a href="Indexx.aspx">Home</a></li>
                     <li><a href="#about">About Us</a></li>
                
                     <li><a href="#product">Foods</a></li>
                                       
                     <li><a href="#contact">Contact Us</a></li>

                       <li><a href="login.aspx">Sign Up</a></li>
                  </ul>
               
                 
               </div>
               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>
      </section>
      <!-- /header -->
      <!-- banner -->
      <section class="banner">
         <div class="flexslider">
            <ul class="slides">
            <li>
             <img src="images/pexels-steyn-viljoen-62097 (1).jpg"/>
                 
                  <div class="banner-content">
                   <!-- <h1 class="animated fadeInDown">Style</h1>
                     <p>A way to say who You are with out having to speak.....</p>-->
                   </div>
               </li>
               
               <li>
                  <img src="images/pexels-trang-doan-769969.jpg"/>
                  <div class="banner-content">
                   <!--<h1 class="animated fadeInDown">Style</h1>
                     <p>A way to say who You are with out having to speak.....</p>-->
                  </div>

               </li>
               <li>
                  <img src="images/pexels-pixabay-33162.jpg" />
                  <div class="banner-content">
                     <!-- <h1 class="animated fadeInDown">Style</h1>
                     <p>A way to say who You are with out having to speak.....</p>-->
                   </div>
               </li>
                <!--<li>
                  <img src="images/ban.jpeg" />
                  <div class="banner-content">
                     <h1 class="animated fadeInDown">content here</h1>
                     <p>Subtext goes here...........</p>
                  </div>
               </li>-->
           
            </ul>
         </div>
      </section>
      <!-- about -->
      <section class="about" id="about">
         <div class="container">
            <h4 class="wow fadeInDown page-title">About Us</h4>
            <div class="abt-content">
               <p class="wow fadeInDown content-text txtal"><strong> ‘Feast’ </strong> We are exactly what you are looking for. Feast Restaurant is just one of the fantastic restaurant in Palakkad. Visitors can find different variety of food here. Come and join with us and make your special and enjoy our food items. </p>
            </div>
         </div>
      </section>
      <!-- product-summary -->
      <section class="product-summary" id="product">
         <div class="container">
            <h4 class="wow fadeInDown page-title">Our Products</h4>
            <div class="product-content">
               <div class="row">
                  <div class="col-md-4">
                     <div class="wow fadeInLeft p-cards">
                  
                        <div class="product-img" align="center">
                           <img src="images/veg.jpg" alt=""/>
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Vegetarian</h4>
                        
                           </p>
                           <a href="product_vegetarian_public.aspx" class="wow fadeIn">More <span><i class="fas fa-angle-right"></i></span></a>
                        </div>
                     </div>
                  </div>
                   <div class="col-md-4">
                     <div class="wow fadeInLeft p-cards">
                    
                        <div class="product-img" align="center">
                           <img src="images/nonveg.jpg" alt=""/>
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Non Vegetarian</h4>
                        
                           </p>
                           <a href="product_nonvegetarian_public.aspx" class="wow fadeIn">More <span><i class="fas fa-angle-right"></i></span></a>
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
                     <div class="wow fadeInRight p-cards">
                  
                        <div class="product-img" align="center">
                           <img src="images/tea.jpg" alt="" />
                        </div>
                        <div class="product-txt">
                           <h4 class="wow fadeInDown">Drinks</h4>
                           <a href="product_drinks_public.aspx" class="wow fadeIn">More<span><i class="fas fa-angle-right"></i></span></a>
                        </div>
                     </div>
                  </div>
               </div></br>
               </br>
            
      </section>
   
      <!-- contact-us -->
      <section class="contact-us" id="contact">
         <div class="contact-content">
            <div class="contact-form">
               <h4 class="wow fadeInDown page-title">Feedback</h4>
               <div class="wow fadeIn form-section">
                  <div class="messages"></div>
                  <div class="controls">
                     <!--<div class="form-group">
                        <label for="sel1">What do you want to enquire ?</label>
                        <select class="form-control" name="enquiry" id="form_select">
                           <option value="Smart MRO">Pumps</option>
                           <option value="Fields">Generators</option>
                        </select>-->
                        <div class="help-block with-errors"></div>
                     </div>
                     <div class="row">
                        <div class="col-md-6">
                           <div class="form-group">
                              <label for="usr">First Name:</label>
                              <asp:TextBox ID="TextBox1" runat="server" class="form-control"   required="required" data-error="First name is required."></asp:TextBox>
                              
                              <div class="help-block with-errors"></div>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="form-group">
                              <label for="usr">Last Name:</label>
                              <asp:TextBox ID="TextBox2" runat="server" class="form-control"   required="required" data-error="Last name is required."></asp:TextBox>
                                                           <div class="help-block with-errors"></div>
                           </div>
                        </div>
                     </div>
                     <div class="row">
                        <div class="col-md-6">
                           <div class="form-group">
                              <label for="usr">Email :</label>
                              <asp:TextBox ID="TextBox3" runat="server" class="form-control"  Height="35px"  required="required" data-error="Valid Email is required."></asp:TextBox>
                        
                              <div class="help-block with-errors"></div>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="form-group">
                              <label for="usr">Phone :</label>
                              <asp:TextBox ID="TextBox4" runat="server" class="form-control" Height="35px"  required="required" data-error="Valid phone number is required." pattern="[1-9]{1}[0-9]{9}"></asp:TextBox>
                            
                              <div class="help-block with-errors"></div>
                           </div>
                        </div>
                     </div>
                     <div class="form-group">
                        <label for="comment">Comments :</label>
                         <asp:TextBox ID="TextBox5" runat="server" class="form-control" Height="35px"  required="required" data-error="Comment is required."></asp:TextBox>
                     </div>
                     <div class="form-group">
                        <div class="g-recaptcha" data-sitekey="6Ld7Z0cUAAAAAHHuBOEqHvRXMP9wRaC8TJXctYER"></div>
                     </div>
                     <div class="send-btn">
                        <asp:Button ID="Button1" class="btn-custom"  runat="server" Text="Send" 
                             onclick="Button1_Click" />
&nbsp;</div>
                  </div>
               </div>
            </div>
           <div class="wow slideInRight contact-map">
           
                   <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.562165224345!2d76.64698521425817!3d10.768187592327108!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ba86dfa7839d371%3A0xbe1a79fb1c7816bc!2sHotel%20feast!5e0!3m2!1sen!2sin!4v1610524954353!5m2!1sen!2sin" width="100%" height="580" frameborder="0" style="border:0" allowfullscreen></iframe>
            </div>
            <div class="clear"></div>
         </div>
      </section>
      <footer class="footer">
         <div class="container">
            <div class="row">
               <div class="col-md-4">
                  <h4 class="wow fadeInDown footer-head">About</h4>
                  <p class="wow fadeInDown footer-txt txtal"><strong>‘Feast’</strong>We are exactly what you are looking for.Feast Restaurant is just one of the fantastic restaurant in Palakkad. Visitors can find different variety of food here.Come and join with us and make your special and enjoy our food items. </p>
               </div>
               <div class="col-md-2">
                  <div class="click-link">
                     <h4 class="wow fadeInDown footer-head">Quick Links</h4>
                     <ul class="wow fadeInDown">
                        <li><a href="Indexx.aspx">Home</a></li>
                     <li><a href="#about">About Us</a></li>
                
                     <li><a href="#product">Foods</a></li>
                                       
                     <li><a href="#contact">Contact Us</a></li>

                       <li><a href="login.aspx">Sign Up</a></li>

                       <!-- <li><a href="product_gown.aspx">Gown</a></li-->
                        <!-- <li><a href="product_jewel.aspx">Jewellery</a></li>-->
                    
                     </ul>
                  </div>
               </div>
               <div class="col-md-6">
                  <h4 class="wow fadeInDown footer-head">Contact Info</h4>
                  <div class="wow fadeInDown address">
                     <ul>
                        <li>
                           <img src="images/placeholder.svg" alt=""><span>Opp.KSRTC Bus Stand,Valakkad,Palakkad,Kerala 678001
</span>
                        </li>
                        <li>
                           <img src="images/phone-call.svg" alt=""><span>+91-8547471666</span>
                        </li>
                        <li>
                           <img src="images/mail.svg" alt=""><span>rmsminiproject@gmail.com</span>
                        </li>
                     </ul>
                  </div>
               </div>
            </div>
         </div>
      </footer>
      <section class="copyright">
         <div class="container">
            <div class="row">
               <div class="col-md-6">
                  <h5>Copyright © 2018</h5>
               </div>
               <div class="col-md-6 text-align-rt">
                  <h5>Powered By : <a href="#">Passtech</a></h5>
               </div>
            </div>
         </div>
      </section>
      <!-- scripts -->
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
