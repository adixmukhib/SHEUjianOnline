<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUjian.aspx.cs" Inherits="SHEUjianOnline.LoginUjian" MasterPageFile="~/Ujian.Master" %>


<asp:Content ID="LoginContent" ContentPlaceHolderID="UjianContent" runat="server">

<div style="max-width: 400px;">
    <h2 class="form-signin-heading">Login Ujian Induksi Pintar</h2>
    <label for="txtUsername">
        Username</label>
    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username" />
     <label for="txtPassword">
        Password</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
        placeholder="Enter Password" />
    <br />
    <asp:DropDownList ID="ddlAkses" runat="server" OnSelectedIndexChanged="ddlAkses_SelectedIndexChanged" Height="26px" Width="126px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnClick" Class="btn btn-primary" />

</div>

 </asp:Content>
