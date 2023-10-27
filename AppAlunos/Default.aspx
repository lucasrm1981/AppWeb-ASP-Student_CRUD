<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppAlunos.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label></td>
                <td><asp:TextBox ID="txbId" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txbName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Last Name:</td>
                <td><asp:TextBox ID="txbLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><asp:TextBox ID="txbCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Department:</td>
                <td><asp:TextBox ID="txbDepartment" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnOcultarId" runat="server" Text="Ocultar Id" OnClick="btnOcultarId_Click" />
                    <asp:Button ID="btnExibirId" runat="server" Text="Exibir Id" OnClick="btnExibirId_Click" />

                </td>
            </tr>
        </table>
        <asp:GridView ID="grvStudents" runat="server"></asp:GridView>
    </form>
</body>
</html>
