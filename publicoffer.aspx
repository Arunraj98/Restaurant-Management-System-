<%@ Page Language="C#" AutoEventWireup="true" CodeFile="publicoffer.aspx.cs" Inherits="publicoffer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
      <meta http-equiv="x-ua-compatible" content="ie=edge">
      <title>UBERBASKET</title>
      <meta name="description" content="">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="css/css-wrap.css">
      <script defer src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
      </head>

<body>
      <!-- Header -->
        <form id="form2" runat="server">
      <section class="custom-header">   <div class="cus-style">
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
                      <a href="#" class="company-name"><strong>UBERBASKET</strong></a>  </ul>
                   <ul class="nav navbar-nav navbar-right">
                  <li><a href="Indexx.aspx">Home</a></li>
                     <li><a href="#about">About Us</a></li>
                  <li><a href="#product2">Products</a></li>     
                 
                      
                     <li><a href="#contact">Contact Us</a></li>
                      <li><a href="login.aspx">Sign Up</a></li>
                       <li><a href="Indexx.aspx">Back</a></li>


                  </ul>
               
                 
               </div>
              
                  
               </div>
               <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
         </nav>

           <div class="banner-content">
           </br>
            <h1 class="animated fadeInDown  " >STYLE</h1>
                     <h2 class="animated fadeInDown  " >THE WAY TO SAY WHO YOU ARE WITHOUT HAVING TO SPEAK..!!</h2>
                    
                  </div>


      </section>
      <!-- /header -->
   
      <section class="about" id="about">
         <div class="container">
            <h4 class="wow fadeInDown page-title">About Us</h4>
            <div class="abt-content">
             
              <p class="wow fadeInDown content-text txtal"><strong>‘FASHIONZONE’</strong>Boutique Symbolizing women empowerment is mother and daughter owned, bringing fashion that's helps bridge the gap between generations, has come a long way since it was established 7 years back by a passionate entrepreneur. When the store was launched it was named as "Impulse" which was later rechristened as Fashionzone boutique, inspiration behind this change was her mother who was her guiding force. Our goal is to use fashion to define who you are! We are dedicated to choosing and hand-picking pieces designed to reflect individuality. Fashionzone Boutique offers a wide range of apparel to fit any woman's unique sense of style. Our clothing and accessories are carefully curated to provide our customers the latest fashions. To keep our customers in style we post new arrivals daily, as well as offer stylist picks to help any indecisive shoppers. Fashionzone Boutique is a fashionista's best place to create the perfect wardrobe. Marian Boutique helps you find your own unique look without the expensive price tags, offering you a well edited, budget friendly selection of trendy styles.</p>
             
             
               </div>
         </div>
      </section>
   
     
      <section class="product-summary " id="product2">
         
         <div class="container">
         
            <div class="product-content">

            
           
               <div class="row">
             <asp:Repeater ID="repeater2" runat="server" onitemcommand="repeater2_ItemCommand"  >
                
               
                        <ItemTemplate>
                  <div class="col-md-3">
                     <div class="p-card p-card2">
                        <div class="product-img">
                        <!--<img src="images/KSB-pumps.png" alt="">-->
                            <img src="<%# Eval("photoname") %>" alt=" sss" class="img-thumbnail"  Height="350px" Width="150px"/>
							
                        </div>
                        <div class="product-txt">
                        
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("pid") %>'></asp:HiddenField>
                           <h4 class="content-text txtal"><%# Eval("pname") %></h4> 
                           <p class="content-text txtal">Price: <%# Eval("price")%></p>
                           <p class="content-text txtal">Stock: <%# Eval("stock")%></p>
                           <p class="content-text txtal">Cloth & size: <%# Eval("quantity")%></p>


                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Buy">Buy Now</asp:LinkButton>
                           
                          
                       
                           </div>
                  </div> 
           
                  


                 


                  </div>
                   </ItemTemplate></asp:Repeater>


               </div>
         </div>
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
                              <asp:TextBox ID="TextBox3" runat="server" class="form-control"   required="required" data-error="Valid Email is required."></asp:TextBox>
                        
                              <div class="help-block with-errors"></div>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="form-group">
                              <label for="usr">Phone :</label>
                              <asp:TextBox ID="TextBox4" runat="server" class="form-control"   
                                   required="required" data-error="Valid phone number is required." 
                                   pattern="[1-9]{1}[0-9]{9}"></asp:TextBox>
                            
                              <div class="help-block with-errors"></div>
                           </div>
                        </div>
                     </div>
                     <div class="form-group">
                        <label for="comment">Comments :</label>
                         <asp:TextBox ID="TextBox5" runat="server" class="form-control"   required="required" data-error="Comment is required."></asp:TextBox>
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
                  <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1959.5207271062336!2d76.6371742597502!3d10.808137026935968!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x0!2zMTDCsDQ4JzMwLjciTiA3NsKwMzgnMjAuNyJF!5e0!3m2!1sen!2sin!4v1608543016329!5m2!1sen!2sin" width="100%" height="580" frameborder="0" style="border:0" allowfullscreen></iframe>
            </div>
            <div class="clear"></div>
         </div>
      </section>
      <footer class="footer">
         <div class="container">
            <div class="row">
               <div class="col-md-4">
                  <h4 class="wow fadeInDown footer-head">About</h4>
                  <p class="wow fadeInDown footer-txt txtal"><strong>‘FASHIONZONE’</strong> Boutique Symbolizing women empowerment is mother and daughter owned, bringing fashion that's helps bridge the gap between generations, has come a long way since it was established 7 years back by a passionate entrepreneur. </p>
               </div>
               <div class="col-md-2">
                  <div class="click-link">
                     <h4 class="wow fadeInDown footer-head">Quick Links</h4>
                     <ul class="wow fadeInDown">
                        <li><a href="product_saree_public.aspx">Sarees</a></li>
                        <li><a href="product_kurthis_public.aspx"ss>Kurthis</a></li>
                        <li><a href="product_churidhar_public.aspx">Churidhar</a></li>
                        <li><a href="product_frock_public.aspx">Frock</a></li>
                        
                        
                      
                     </ul>
                  </div>
               </div>
               <div class="col-md-6">
                  <h4 class="wow fadeInDown footer-head">Contact Info</h4>
                  <div class="wow fadeInDown address">
                     <ul>
                        <li>
                           <img src="images/placeholder.svg" alt=""><span>14/208-2,near Kallekulangara temple,Palakkkad-678009</span>
                        </li>
                        <li>
                           <img src="images/phone-call.svg" alt=""><span>+91-8547471666</span>
                        </li>
                        <li>
                           <img src="images/mail.svg" alt=""><span>rmsminiproject@gmail.com</span>s
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
                  <h5>Powered By : <a href="#"> Cybenko</a></h5>
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
