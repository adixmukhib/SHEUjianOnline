<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SHEUjianOnline.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 50%;
        }
        .auto-style3 {
            width: 144px;
        }
        .auto-style4 {
            width: 73px;
        }
    </style>
</head>
<body style="width: 892px">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label4" runat="server" Text="Ujian Online Induksi Pintar"></asp:Label>
    </div>
    <div>
    <table style="width:50%" border="1">
        <tr>
             <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Induksi Pintar Soal"></asp:Label>
            </td>
            <td style="width:50%">
                <asp:Button ID="ButtonSoal" runat="server" Text="Kerjakan" OnClick="ButtonSoal_Click" />
            </td>
        </tr>
    </table>
    <table style="width:50%" border="1">
        <tr>
             <td style="width:50%">
                <asp:Label ID="Label1" runat="server" Text="Induksi Pintar Operator"></asp:Label>
            </td>
            <td style="width:50%">
                <asp:Button ID="ButtonOperator" runat="server" Text="Kerjakan" OnClick="ButtonOperator_Click" />
            </td>
        </tr>
    </table>
        <table style="width:50%" border="1">
        <tr>
             <td class="auto-style3" style="width:50%">
                <asp:Label ID="Label2" runat="server" Text="Induksi Pintar Mekanik"></asp:Label>
            </td>
            <td class="auto-style4" style="width:50%">
                <asp:Button ID="ButtonMekanik" runat="server" Text="Kerjakan" OnClick="ButtonMekanik_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
