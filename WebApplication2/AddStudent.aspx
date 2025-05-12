<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="WebApplication2.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name: <asp:TextBox ID="txtName" runat="server" Height="22px" Width="128px"></asp:TextBox>
            <br />
            Roll no:<asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
            <br />
            Course:<asp:TextBox ID="txtCourse" runat="server"></asp:TextBox>
            <br />
            Age:<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Student" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
