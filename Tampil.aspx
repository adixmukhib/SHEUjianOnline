
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tampil.aspx.cs" Inherits="SHEUjianOnline.Tampil" MasterPageFile="~/Ujian.Master" %>
  
    
<asp:Content ID="TampilContent" ContentPlaceHolderID="UjianContent" runat="server"> 
    <asp:Label ID="LblGenerateID" runat="server" OnDataBinding="Page_Load" Text="gid" Visible="false"></asp:Label>

    <div class="btn btn-primary btn-lg" style="background-size:auto">
        <asp:ScriptManager ID="sm" runat="server" />
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
            <asp:Label ID="Lbl_timer" runat="server" postback="true" Height="15px" Width="80px"/>
            <asp:Timer ID="mytimer" runat="server" Interval="1000" OnTick="my_timer_tick">

            </asp:Timer>        
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </div>

    <div class="row">
      <div class="col-sm-12 col-md-8" style="padding-top:3%; top: 0px; left: 0px; height: 205px;">
        <div class="thumbnail">
          <div class="caption">
           
           
            <p>
                <asp:Label ID="Lbl_nomor" runat="server" CssClass="thumbnail" Font-Names="Century Gothic" Font-Size="Medium" postback="true" OnDataBinding="Page_Load" Width="18px"></asp:Label>
        
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("image_url") %>">' Height="250px" Width="500px" />
        
                <asp:Label ID="Lbl_Soal" runat="server" Text="Kerjakan sekarang ??" CssClass="thumbnail" Font-Names="Century Gothic" Font-Size="Medium" postback="true"  Visible="true" OnDataBinding="Page_Load"></asp:Label>
            </p>
            <p>
                <asp:RadioButtonList ID="Rbl_jawabanA" DataSourceID="SqlDataSource1" DataTextField="deskripsi_jawaban" DataValueField="id_jawaban" runat="server" Height="32px" class="caption" Font-Bold="False" Font-Names="Century Gothic" Font-Size="Small" Width="859px"></asp:RadioButtonList>
            </p>
            <p>
               <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Submit" Width="80px" Class="btn btn-primary" Visible="false" />
               <asp:Button ID="Btn_AnswerKey" runat="server" OnClick="Btn_AnswerKey_Click" Text="AnswerKey" class="btn btn-default" Visible="false" />
            </p>
              <p>
               <asp:Button ID="Btn_Pilih" runat="server" OnClick="Btn_Pilih_Click" Text="Pilih" Width="80px" Class="btn btn-primary" />
              </p>


        </div>
            <p>&nbsp;</p>
            <asp:Label ID="LblURL" runat="server" Text="" Visible="false" ></asp:Label>
        </div>
            

    </div>
    </div>
       
        
        <br />
    
        <asp:Label ID="LblIdSoal" runat="server" OnDataBinding="Page_Load" Text="" Visible="false"></asp:Label>
   

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_SHE %>" SelectCommand="SELECT abc+'.'+' '+ deskripsi_jawaban as deskripsi_jawaban, [id_jawaban] FROM [tb_soal_Generate] WHERE (([id_soal] = @id_soal) AND ([GenerateID] = @GenerateID))" OnSelecting="SqlDataSource1_Selecting">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="no" Name="id_soal" QueryStringField="no" Type="Int32" />
                <asp:QueryStringParameter DefaultValue="s_str_generatedID" Name="GenerateID" QueryStringField="s_str_generatedID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>


    
        
</asp:Content>
