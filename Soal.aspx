﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Soal.aspx.cs" Inherits="SHEUjianOnline.Soal" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %> 
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <rsweb:ReportViewer ID="Report" runat="server" Height="98%" ProcessingMode="Remote" ShowParameterPrompts="false"
                Width="100%">
         </rsweb:ReportViewer>
    </div>
    </form>
</body>

</html>
