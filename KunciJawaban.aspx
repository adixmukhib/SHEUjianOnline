<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KunciJawaban.aspx.cs" Inherits="SHEUjianOnline.KunciJawaban" MasterPageFile="~/Ujian.Master" %>

<asp:Content ID="KunciJawabanContent" ContentPlaceHolderID="UjianContent" runat="server">
    <div>
        
    <h3 class="form-signin-heading">Kunci Jawaban Ujian Induksi Pintar</h3>
        <asp:Label ID="LblKunci" runat="server" Text=""></asp:Label>
        <br />

        <asp:Label ID="LblGenerateID" runat="server" Text="0"></asp:Label>
        <br />
        <asp:Button ID="Btn_Show" runat="server" OnClick="Btn_Show_Click" Text="Show" Width="77px" />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="table">
            <Columns>
                <asp:BoundField DataField="id_soal" HeaderText="id_soal" SortExpression="id_soal" />
                <asp:BoundField DataField="deskripsi_jawaban" HeaderText="deskripsi_jawaban" SortExpression="deskripsi_jawaban" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_SHE %>" SelectCommand="cusp_Tampil_Kunci_Jawaban" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="LblGenerateID" Name="generatedID" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
 
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="table">
            <Columns>
                <asp:BoundField DataField="nomor" HeaderText="nomor" SortExpression="nomor" />
                <asp:BoundField DataField="id_soal" HeaderText="id_soal" SortExpression="id_soal" />
                <asp:BoundField DataField="id_jawaban" HeaderText="id_jawaban" SortExpression="id_jawaban" />
                <asp:BoundField DataField="GenerateID" HeaderText="GenerateID" SortExpression="GenerateID" />
                <asp:BoundField DataField="right_answer" HeaderText="right_answer" SortExpression="right_answer" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_SHE %>" SelectCommand="SELECT * FROM [vw_nilai_evaluasi]">
        </asp:SqlDataSource>

</asp:Content>