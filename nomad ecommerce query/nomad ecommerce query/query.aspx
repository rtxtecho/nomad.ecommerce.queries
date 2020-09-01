<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="query.aspx.cs" Inherits="nomad_ecommerce_query.query" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type ="text/javascript"
    src="Scripts/jquery-3.5.1.min.js"></script>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat = "server" ID = "script_m"
            >
        </asp:ScriptManager>
    </form>
    <div 
           onclick = "get_unique();"
    >
    get unique
    </div>
    <div
           id = "content";
    >
    </div>
</body>
</html>

<script type ="text/javascript"
    >
    function get_unique()
    {
    nomad_ecommerce_query.service.unique_prices(
                                  unique_prices_);
    }
                           
    function unique_prices_(r)
    {
        $("#content"
         ).html(r);
    }
</script>