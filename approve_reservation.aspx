<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approve_reservation.aspx.cs" Inherits="approve_design" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
      <meta http-equiv="x-ua-compatible" content="ie=edge">
      <title>Bake N Touch</title>
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
<body  background="images/back.jpeg">
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
                      <a href="#" class="company-name"><strong>Bake N Touch</strong></a> </ul> </ul>
                  <ul class="nav navbar-nav navbar-right">
                     
                     <li><a href="order_home.aspx">Home</a> </li>
                      <li><a href="Rejectedorder.aspx">Rejected</a> </li>
                       <li><a href="Cancelledorder.aspx">Cancelled</a> </li>
                     <li><a href="Logout.aspx">Logout</a> </li>
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
        <asp:Label ID="Label1" runat="server" Text="Customized Theme" Forecolor="#ffffff" 
            CssClass="style2" style="font-size: xx-large"  ></asp:Label>
        </strong>
        </br></br>
        
             <asp:GridView ID="GridView2" runat="server"  
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
            CellPadding="4" Width="1300px" 
             AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"
            DataKeyNames="menuid"   PageSize = "3" AllowPaging ="True" 
           EmptyDataText="No records has been added."
             onrowcancelingedit="GridView1_RowCancelingEdit" 
             onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" CellSpacing="2" 
            onpageindexchanging="GridView2_PageIndexChanging" ForeColor="Black">
            <Columns>
                <asp:TemplateField HeaderText="Slno" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="menuid" runat="server" Text='<%#Eval("menuid") %>' ></asp:Label>                                
                </ItemTemplate>
                
                
                
<ItemStyle Width="150px"></ItemStyle>
                
                
                
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="nm" runat="server" Text='<%#Eval("name") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              

</asp:TemplateField>

<asp:TemplateField HeaderText="Address" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="add" runat="server" Text='<%#Eval("address") %>' ></asp:Label>                                
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
                        <asp:Label ID="email" runat="server" Text='<%#Eval("customerid") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>







                              
                                </asp:TemplateField>
               
               



                  <asp:TemplateField HeaderText="Words on cake" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="Labe1" runat="server" Text='<%#Eval("words_on_cake") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity(kg)" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="q" runat="server" Text='<%#Eval("quantity") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date for deivery" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="d" runat="server" Text='<%#Eval("functiondate") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Time for delivery" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="t" runat="server" Text='<%#Eval("time") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                              


                              
                                   <asp:TemplateField HeaderText="Datetime of booking" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="dd" runat="server" Text='<%#Eval("date") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Payment staus" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="ps" runat="server" Text='<%#Eval("paymentstatus") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
<asp:TemplateField HeaderText="Payment mode" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="pm" runat="server" Text='<%#Eval("paymentmode") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>


<asp:TemplateField HeaderText="Amount" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="p" runat="server" Text='<%#Eval("amount") %>' ></asp:Label>                                
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>


                              

                                 <asp:TemplateField HeaderText="Theme" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                           <a href ='<%#Eval("photo") %>' style="color: #0099ff;">View</a>
                </ItemTemplate>
                              
<ItemStyle Width="150px"></ItemStyle>
                              
                                </asp:TemplateField>
                               
                 

                  <asp:TemplateField HeaderText="Status" ItemStyle-Width="150">
                    
                        <ItemTemplate>
                        <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>' ></asp:Label>                                
                </ItemTemplate>
                <EditItemTemplate>
                      
                       <asp:DropDownList ID="DropStatus" runat="server">
                       <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                       </asp:DropDownList>
                    </EditItemTemplate>
                    

                              
<ItemStyle Width="150px"></ItemStyle>
                    

                              
                                </asp:TemplateField>
                               
                
                           <asp:CommandField ButtonType="Button" ShowEditButton="true"  EditText="Choose" UpdateText="Confirm" CancelText="Cancel" ControlStyle-BackColor="#000000" ControlStyle-CssClass="btn " ControlStyle-Width="80" ControlStyle-ForeColor="#ffffff"
                    ItemStyle-Width="150" >


<ControlStyle BackColor="Black" CssClass="btn " ForeColor="White" Width="80px"></ControlStyle>


                <ItemStyle Width="150px" />
                </asp:CommandField>
 

            </Columns>
 <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="16px" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
            <RowStyle BackColor="White" Font-Size="12px"/>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
      





    </div>
      



    </div>
    
    </form>
</body>
</html>
