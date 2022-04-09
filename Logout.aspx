<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FEAST</title>
    <script type="text/javascript">
        window.history.forward('');
        function noback() {

            window.history.forward();

        }
         </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="1000">
        </asp:Timer>
        <br />
    
    </div>
    </form>
</body>
</html>
