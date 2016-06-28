<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kontrolki.aspx.cs" Inherits="ASPSTART.Kontrolki" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 80px">
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Dopisz" OnClick="Button1_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="" Width="60px"></asp:Label>
        </div>
        
    
    </div>
    </form>
</body>
</html>
