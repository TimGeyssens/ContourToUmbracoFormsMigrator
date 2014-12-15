<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContourToForms.ascx.cs" Inherits="Umbraco.Forms.Migration.ContourToForms" %>
<asp:TextBox ID="TextBox1" runat="server" Height="112px" TextMode="MultiLine" Width="250px" placeholder="Connectionstring"></asp:TextBox>
<br />
<br/>
<asp:Button ID="Button1" runat="server" Text="Start Migration" OnClick="Button1_Click" />
<p><asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </p>
