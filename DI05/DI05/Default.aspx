<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DI05.Default" %>

<%@ Register Src="UserControl1.ascx" TagName="UserControl1" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblEmail1" runat="server"></asp:Label>
        <br />
        <uc1:UserControl1 ID="UserControl11" runat="server" />
    </div>
    </form>
</body>
</html>
